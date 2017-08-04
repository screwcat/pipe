using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.Sales
{
    public partial class SaleDtlModify : System.Web.UI.Page
    {
        DataSet Dept = new BLL.Dept().GetAllList();
        DataSet StoreHouse = new BLL.StoreHouse().GetAllList();
        DataSet Customer = new BLL.Customer().GetAllList();
        BLL.Sale bll_sale = new ZhangWei.BLL.Sale();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList2.DataSource = Dept;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "Dept_ID";
                DropDownList2.DataBind();
                DropDownList1.DataSource = StoreHouse;
                DropDownList1.DataTextField = "Address";
                DropDownList1.DataValueField = "StoreHouse_ID";
                DropDownList1.DataBind();
                DropDownList5.DataSource = Customer;
                DropDownList5.DataTextField = "Name";
                DropDownList5.DataValueField = "Customer_ID";
                DropDownList5.DataBind();

                if (Request.QueryString["Sale_ID"] != null && Request.QueryString["Sale_ID"].Trim() != "")
                {
                    BindData();
                }

            }
            Button5.Attributes.Add("onclick", "return confirm(\"确认修改后的销售信息吗？\")");
        }
        protected void BindData()
        {
            Model.Sale ml_sa = bll_sale.GetModel(Convert.ToInt32(Request.QueryString["Sale_ID"]));
            Model.StoreHouse ml_sh = new BLL.StoreHouse().GetModel(Convert.ToInt32(ml_sa.StoreHouse_ID));
            Model.Customer ml_cu = new BLL.Customer().GetModel(Convert.ToInt32(ml_sa.Customer));
            DataSet ds = new BLL.Sale_Detail().GetDetailAll(Convert.ToInt32(Request.QueryString["Sale_ID"]));
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
            decimal AllTot = 0;
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                decimal price = Convert.ToDecimal(gvr.Cells[5].Text);
                decimal qty = Convert.ToDecimal(gvr.Cells[4].Text);
                decimal RowTot = price * qty;
                gvr.Cells[6].Text = Math.Round(RowTot, 3).ToString();
                AllTot += RowTot;
            }
            this.Label1.Text = Math.Round(AllTot, 3).ToString();
            this.Label2.Text = Maticsoft.Common.Rmb.CmycurD(AllTot);
            string OldId = "";
            string OldPrice = "";
            string OldQty = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                OldId += ds.Tables[0].Rows[i]["Product_ID"] + "|";
                OldPrice += ds.Tables[0].Rows[i]["Price"] + "|";
                OldQty += ds.Tables[0].Rows[i]["Quantity"] + "|";
            }
            this.oldId.Value = OldId.ToString();
            this.oldPrice.Value = OldPrice.ToString();
            this.oldQty.Value = OldQty.ToString();
            this.newId.Value = OldId.ToString();
            this.newPrice.Value = OldPrice.ToString();
            this.newQty.Value = OldQty.ToString();

            this.DropDownList1.SelectedValue = ml_sa.StoreHouse_ID.ToString();
            this.DropDownList2.SelectedValue = ml_sa.Dept_ID.ToString();
            this.DropDownList5.SelectedValue = ml_sa.Customer.ToString();
            this.DropDownList4.Text = ml_sa.Account;
            this.DropDownList6.Text = ml_sa.GatheringWay;
            this.TextBox1.Text = ml_sa.Address;
        }
        protected void Button5_Click(object sender, EventArgs e)
        {

            BackSaleOld();//先退货，库存数恢复

            BLL.Sale_Detail bl_sd = new ZhangWei.BLL.Sale_Detail();
            bl_sd.DeleteSaleDtl(Convert.ToInt32(Request.QueryString["Sale_ID"]));//把修改前的详单数据删了

            SaleAgain();//在重卖
            Maticsoft.Common.MessageBox.Show(this, "更改成功！");
            BindData();//在重新绑定一下数据

        }
        protected void BackSaleOld()
        {
            string Ids = this.oldId.Value.Replace(" ", "").Replace("\r\n", "");
            string Qtys = this.oldQty.Value.Replace(" ", "").Replace("\r\n", "");
            string Prices = this.oldPrice.Value.Replace(" ", "").Replace("\r\n", "");
            string[] ArrIds = Ids.Split(new char[] { '|' });
            string[] ArrQty = Qtys.Split(new char[] { '|' });
            string[] ArrPri = Prices.Split(new char[] { '|' });
            for (int i = 0; i < ArrIds.Length - 1; i++)
            {

                Model.StockPile ml_sp = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]), bll_sale.GetModel(Convert.ToInt32(Request.QueryString["Sale_ID"])).StoreHouse_ID);
                BLL.StockPile bl_sp = new ZhangWei.BLL.StockPile();

                ml_sp.Quantity += Convert.ToDecimal(ArrQty[i]);
                ml_sp.LastLeaveDate = DateTime.Now;
                bl_sp.Update(ml_sp);
            }
        }
        protected void SaleAgain()
        {
            Model.Sale ml_sale = bll_sale.GetModel(Convert.ToInt32(Request.QueryString["Sale_ID"]));
            ml_sale.GatheringWay = this.DropDownList6.SelectedItem.Text;
            ml_sale.Account = this.DropDownList4.SelectedItem.Text;
            ml_sale.Address = this.TextBox1.Text;
            ml_sale.Customer = Convert.ToInt32(DropDownList5.SelectedValue);
            ml_sale.StoreHouse_ID = Convert.ToInt32(DropDownList1.SelectedValue);
            ml_sale.Dept_ID = Convert.ToInt32(DropDownList2.SelectedValue);
            bll_sale.Update(ml_sale);
            string Ids = this.newId.Value.Replace(" ", "").Replace("\r\n", "");
            string Qtys = this.newQty.Value.Replace(" ", "").Replace("\r\n", "");
            string Prices = this.newPrice.Value.Replace(" ", "").Replace("\r\n", "");
            string[] ArrIds = Ids.Split(new char[] { '|' });
            string[] ArrQty = Qtys.Split(new char[] { '|' });
            string[] ArrPri = Prices.Split(new char[] { '|' });
            for (int i = 0; i < ArrIds.Length - 1; i++)
            {
                Model.Sale_Detail ml_sa = new ZhangWei.Model.Sale_Detail();
                BLL.Sale_Detail bl_sd = new ZhangWei.BLL.Sale_Detail();
                ml_sa.Sale_ID = Convert.ToInt32(Request.QueryString["Sale_ID"]);
                ml_sa.Product_ID = Convert.ToInt32(ArrIds[i]);
                //ml_sa.SaleOrder_ID = 0;
                ml_sa.Quantity = Convert.ToDecimal(ArrQty[i]);
                ml_sa.Price = Convert.ToDecimal(ArrPri[i]);
                Model.StockPile ml_sp = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]), Convert.ToInt32(DropDownList1.SelectedValue));
                BLL.StockPile bl_sp = new ZhangWei.BLL.StockPile();
                if (ml_sp == null)
                {
                    Model.Product ml_pr = new BLL.Product().GetModel(Convert.ToInt32(ArrIds[i]));
                    ml_sp = new ZhangWei.Model.StockPile();
                    ml_sp.Product_ID = Convert.ToInt32(ArrIds[i]);
                    ml_sp.Dept_ID = Convert.ToInt32(DropDownList2.SelectedValue);
                    ml_sp.FirstEnterDate = DateTime.Now;
                    ml_sp.LastLeaveDate = DateTime.Now;
                    ml_sp.Price = Convert.ToDecimal(ArrPri[i]);
                    ml_sp.Quantity = 0;
                    ml_sp.StoreHouse_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                    ml_sp.Quantity -= Convert.ToDecimal(ArrQty[i]);
                    bl_sp.Add(ml_sp);
                }
                else
                {
                    ml_sp.Quantity -= Convert.ToDecimal(ArrQty[i]);
                    ml_sp.LastLeaveDate = DateTime.Now;
                    bl_sp.Update(ml_sp);
                }
                bl_sd.Add(ml_sa);
            }
        }
    }
}
