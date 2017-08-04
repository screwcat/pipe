using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.warehouse
{
    public partial class EnterStockEditDtl : System.Web.UI.Page
    {
        BLL.EnterStock bl_es = new ZhangWei.BLL.EnterStock();
        BLL.EnterStock_Detail bl_esd = new ZhangWei.BLL.EnterStock_Detail();
        Int32 EnterStock_ID;
        DataSet StoreHouse = new BLL.StoreHouse().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["EnterStock_ID"] != null && Request.Params["EnterStock_ID"].Trim() != "")
            {
                EnterStock_ID = Convert.ToInt32(Request.Params["EnterStock_ID"].Trim());
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = StoreHouse;
                DropDownList1.DataTextField = "Address";
                DropDownList1.DataValueField = "StoreHouse_ID";
                DropDownList1.DataBind();
                BindData();
                Button5.Attributes.Add("onclick", "return confirm(\"确认修改后的销售信息吗？\")");
            }
        }

        protected void BindData()
        {
            this.Label3.Text = "单号：" + EnterStock_ID;
            //DataSet BuyOrder_Detail = new BLL.BuyOrder_Detail().GetProDetail(EnterStock_ID);
            Model.EnterStock ml_es = bl_es.GetModel(EnterStock_ID);
            this.DropDownList1.SelectedValue = ml_es.StoreHouse_ID.ToString();
            DataSet ds_es = bl_esd.GetEnterStock(EnterStock_ID);
            this.GridView1.DataSource = ds_es;
            this.GridView1.DataBind();
            decimal AllTot = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                decimal price = Convert.ToDecimal(row.Cells[4].Text);
                decimal qty = Convert.ToDecimal(row.Cells[5].Text);
                decimal RowTot = price * qty;
                row.Cells[7].Text = RowTot.ToString();
                AllTot += RowTot;
            }
            this.Label1.Text = AllTot.ToString();
            this.Label2.Text = Maticsoft.Common.Rmb.CmycurD(AllTot);
            string OldId = "";
            string OldPrice = "";
            string OldQty = "";
            for (int i = 0; i < ds_es.Tables[0].Rows.Count; i++)
            {
                OldId += ds_es.Tables[0].Rows[i]["Product_ID"] + "|";
                OldPrice += ds_es.Tables[0].Rows[i]["Price"] + "|";
                OldQty += ds_es.Tables[0].Rows[i]["Quantity"] + "|";
            }
            this.oldId.Value = OldId.ToString();
            this.oldPrice.Value = OldPrice.ToString();
            this.oldQty.Value = OldQty.ToString();
            this.newId.Value = OldId.ToString();
            this.newPrice.Value = OldPrice.ToString();
            this.newQty.Value = OldQty.ToString();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            BackStockOld();

            bl_esd.DeleteEnterStock(EnterStock_ID);

            EnterAgain();

            Maticsoft.Common.MessageBox.Show(this, "更改成功！");

            BindData();
        }

        /// <summary>
        /// 取消原有的入库，把库存减了
        /// </summary>
        protected void BackStockOld()
        {
            string Ids = this.oldId.Value.Replace(" ", "").Replace("\r\n", "");
            string Qtys = this.oldQty.Value.Replace(" ", "").Replace("\r\n", "");
            string Prices = this.oldPrice.Value.Replace(" ", "").Replace("\r\n", "");
            string[] ArrIds = Ids.Split(new char[] { '|' });
            string[] ArrQty = Qtys.Split(new char[] { '|' });
            string[] ArrPri = Prices.Split(new char[] { '|' });
            for (int i = 0; i < ArrIds.Length - 1; i++)
            {

                Model.StockPile ml_sp = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]),bl_es.GetModel(EnterStock_ID).StoreHouse_ID);

                BLL.StockPile bl_sp = new ZhangWei.BLL.StockPile();

                ml_sp.Quantity -= Convert.ToDecimal(ArrQty[i]);
                ml_sp.LastLeaveDate = DateTime.Now;
                bl_sp.Update(ml_sp);
            }
        }

        protected void EnterAgain()//重新入库
        {
            //Model.Sale ml_sale = bll_sale.GetModel(Convert.ToInt32(Request.Params["Sale_ID"]));
            Model.EnterStock ml_es = bl_es.GetModel(EnterStock_ID);
            ml_es.StoreHouse_ID = Convert.ToInt32(DropDownList1.SelectedValue);
            bl_es.Update(ml_es);
            //ml_sale.GatheringWay = this.DropDownList6.SelectedItem.Text;
            //ml_sale.Account = this.DropDownList4.SelectedItem.Text;
            //ml_sale.Address = this.TextBox1.Text;
            //ml_sale.Customer = Convert.ToInt32(DropDownList5.SelectedValue);
            //bll_sale.Update(ml_sale);
            string Ids = this.newId.Value.Replace(" ", "").Replace("\r\n", "");
            string Qtys = this.newQty.Value.Replace(" ", "").Replace("\r\n", "");
            string Prices = this.newPrice.Value.Replace(" ", "").Replace("\r\n", "");
            string[] ArrIds = Ids.Split(new char[] { '|' });
            string[] ArrQty = Qtys.Split(new char[] { '|' });
            string[] ArrPri = Prices.Split(new char[] { '|' });
            for (int i = 0; i < ArrIds.Length - 1; i++)
            {
                Model.EnterStock_Detail ml_esd = new ZhangWei.Model.EnterStock_Detail();
                ml_esd.EnterStock_ID = EnterStock_ID;
                ml_esd.Product_ID = Convert.ToInt32(ArrIds[i]);
                ml_esd.Quantity = Convert.ToDecimal(ArrQty[i]);
                ml_esd.Price = Convert.ToDecimal(ArrPri[i]);
                BLL.Sale_Detail bl_sd = new ZhangWei.BLL.Sale_Detail();
                //ml_sa.Sale_ID = Convert.ToInt32(Request.Params["Sale_ID"]);
                //ml_sa.Product_ID = Convert.ToInt32(ArrIds[i]);
                //ml_sa.SaleOrder_ID = 0;
                //ml_sa.Quantity = Convert.ToDecimal(ArrQty[i]);
                //ml_sa.Price = Convert.ToDecimal(ArrPri[i]);
                Model.StockPile ml_sp = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]), Convert.ToInt32(DropDownList1.SelectedValue));
                BLL.StockPile bl_sp = new ZhangWei.BLL.StockPile();
                if (ml_sp == null)
                {
                    Model.Product ml_pr = new BLL.Product().GetModel(Convert.ToInt32(ArrIds[i]));
                    ml_sp = new ZhangWei.Model.StockPile();
                    ml_sp.Product_ID = Convert.ToInt32(ArrIds[i]);
                    ml_sp.Dept_ID = 1;
                    ml_sp.FirstEnterDate = DateTime.Now;
                    ml_sp.LastLeaveDate = DateTime.Now;
                    ml_sp.Price = Convert.ToDecimal(ArrPri[i]);
                    ml_sp.Quantity = 0;
                    ml_sp.StoreHouse_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                    ml_sp.Quantity += Convert.ToDecimal(ArrQty[i]);
                    bl_sp.Add(ml_sp);
                }
                else
                {
                    ml_sp.Quantity += Convert.ToDecimal(ArrQty[i]);
                    //ml_sp.LastLeaveDate = DateTime.Now;
                    bl_sp.Update(ml_sp);
                }
                bl_esd.Add(ml_esd);
            }
        }

    }
}
