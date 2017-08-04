using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web.warehouse
{
    public partial class ShowBuyOrderDetail : UserPageBass
    {
        DataSet Dept = new BLL.Dept().GetAllList();
        //DataSet Supplier = new BLL.Supplier().GetAllList();
        DataSet Employee = new BLL.Employee().GetAllList();
        DataSet StoreHouse = new BLL.StoreHouse().GetAllList();
        Int32 BuyOrder_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                BuyOrder_ID = (Convert.ToInt32(Request.Params["id"]));
                ShowInfo(BuyOrder_ID);
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Dept;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Dept_ID";
                DropDownList1.DataBind();
                //DropDownList2.DataSource = Supplier;
                //DropDownList2.DataTextField = "Name";
                //DropDownList2.DataValueField = "Supplier_ID";
                //DropDownList2.DataBind();
                DropDownList3.DataSource = Employee;
                DropDownList3.DataTextField = "Name";
                DropDownList3.DataValueField = "Employee_ID";
                DropDownList3.DataBind();
                DropDownList4.DataSource = StoreHouse;
                DropDownList4.DataTextField = "Address";
                DropDownList4.DataValueField = "StoreHouse_ID";
                DropDownList4.DataBind();
            }
            DataSet BuyOrder_Detail = new BLL.BuyOrder_Detail().GetProDetail(BuyOrder_ID);
            Repeater1.DataSource = BuyOrder_Detail;
            Repeater1.DataBind();
            decimal TotalPrice = 0;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label LB1 = (Label)item.FindControl("Label5");//单价
                Label LB2 = (Label)item.FindControl("Label6");//数量
                Label LB3 = (Label)item.FindControl("Label7");//合计
                LB3.Text = (Convert.ToDecimal(LB1.Text) * Convert.ToDecimal(LB2.Text)).ToString();
                TotalPrice += Convert.ToDecimal(LB3.Text);
            }
            Label8.Text = TotalPrice.ToString();
            Label9.Text = Maticsoft.Common.Rmb.CmycurD(TotalPrice);
        }
        private void ShowInfo(int BuyOrder_ID)
        {
            ZhangWei.BLL.BuyOrder bll = new ZhangWei.BLL.BuyOrder();
            ZhangWei.Model.BuyOrder model = bll.GetModel(BuyOrder_ID);
            this.lblBuyOrder_ID.Text = "（合同编号：" + model.BuyOrder_ID.ToString() + "）";
            this.txtWriteDate.Text = model.WriteDate.ToString();
            this.txtInsureDate.Text = model.InsureDate.ToString();
            this.txtEndDate.Text = model.EndDate.ToString();
            //this.txtDept_ID.Text = model.Dept_ID.ToString();
            //this.txtSupplier_ID.Text = model.Supplier_ID.ToString();
            //this.txtEmployee_ID.Text = model.Employee_ID.ToString();
            DropDownList1.SelectedValue = model.Dept_ID.ToString();
            //DropDownList2.SelectedValue = model.Supplier_ID.ToString();
            DropDownList3.SelectedValue = model.Employee_ID.ToString();
            Button1.Attributes.Add("onclick", "return confirm(\"确认入库吗？\")");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.BuyOrder bl_bo = new BLL.BuyOrder();
            Model.BuyOrder ml_bo = bl_bo.GetModel(BuyOrder_ID);
            if (!ml_bo.Produced)//字段值为false，表示已经入过库
            {
                Maticsoft.Common.MessageBox.Show(this, "该单号已经入库，不能重复操作！");
                return;
            }
            if (DropDownList4.SelectedValue=="0")
            {
                Maticsoft.Common.MessageBox.Show(this, "请选择仓库！");
                return;
            }
            Model.EnterStock ET = new Model.EnterStock();
            ET.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
            ET.Employee_ID = Convert.ToInt32(DropDownList3.SelectedValue);
            ET.StoreHouse_ID = Convert.ToInt32(DropDownList4.SelectedValue);
            ET.EnterDate = DateTime.Now;
            Int32 ETId = new BLL.EnterStock().Add(ET);
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label LB1 = (Label)item.FindControl("Label5");//单价
                Label LB2 = (Label)item.FindControl("Label6");//数量
                Label LB3 = (Label)item.FindControl("Label7");//合计
                Label LB4 = (Label)item.FindControl("Label1");//商品编号
                Int32 pro_id = Convert.ToInt32(LB4.Text);
                decimal pro_qty = Convert.ToDecimal(LB2.Text);
                Model.EnterStock_Detail esd = new Model.EnterStock_Detail();
                esd.EnterStock_ID = ETId;
                esd.Product_ID = pro_id;
                esd.Quantity = pro_qty;
                esd.Price = Convert.ToDecimal(LB1.Text);
                esd.HaveInvoice = false;
                esd.InvoiceNum = "0000";
                BLL.EnterStock_Detail bll_esd = new BLL.EnterStock_Detail();
                bll_esd.Add(esd);
                //Model.StockPile sp = new Model.StockPile();
                BLL.StockPile bll_sp = new BLL.StockPile();
                Model.StockPile sp = bll_sp.GetModelByProId(pro_id,Convert.ToInt32(DropDownList4.SelectedValue));
                if (sp == null)
                {
                    sp = new Model.StockPile();
                    sp.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                    sp.StoreHouse_ID = Convert.ToInt32(DropDownList4.SelectedValue);
                    sp.Product_ID = pro_id;
                    sp.FirstEnterDate = DateTime.Now;
                    sp.LastLeaveDate = DateTime.Now;
                    sp.Quantity = pro_qty;
                    sp.Price = Convert.ToDecimal(LB1.Text);
                    bll_sp.Add(sp);
                }
                else
                {
                    sp.Quantity += pro_qty;
                    bll_sp.Update(sp);
                }
                ml_bo.Produced = false;
                bl_bo.Update(ml_bo);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "入库已完成！", "/warehouse/BuyOrder/List.aspx");
            }
        }
    }
}