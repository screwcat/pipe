using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.Sales
{
    public partial class BackSaleDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["BackSale_ID"] != null && Request.Params["BackSale_ID"].Trim() != "")
            {
                Model.BackSale ml_bs = new BLL.BackSale().GetModel(Convert.ToInt32(Request.Params["BackSale_ID"]));
                this.Label10.Text = ml_bs.BackDate.ToString();
                this.Label11.Text = new BLL.StoreHouse().GetModel(ml_bs.StoreHouse_ID).Address;
                this.Label20.Text = ml_bs.Remark;
                this.Label19.Text = new BLL.Employee().GetModel(ml_bs.Employee_ID).Name;
                this.Label21.Text = ml_bs.Address;
                this.Label22.Text = ml_bs.GatheringWay;
                this.Label23.Text = ml_bs.Account;
                this.Label24.Text = new BLL.Customer().GetModel(Convert.ToInt32(ml_bs.Customer)).Name;
                DataSet ds = new BLL.BackSale_Detail().GetBackSaleDef(Convert.ToInt32(Request.Params["BackSale_ID"]));
                //GridView1.DataSource = ds;
                //GridView1.DataBind();
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                decimal AllTot = 0;
                //foreach (GridViewRow gvr in GridView1.Rows)
                //{
                //    decimal price = Convert.ToDecimal(gvr.Cells[6].Text);
                //    decimal qty = Convert.ToDecimal(gvr.Cells[7].Text);
                //    decimal RowTot = price * qty;
                //    gvr.Cells[8].Text = RowTot.ToString();
                //    AllTot += RowTot;
                //}
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    Label LB1 = (Label)item.FindControl("Label5");//单价
                    Label LB2 = (Label)item.FindControl("Label4");//数量
                    Label LB3 = (Label)item.FindControl("Label6");//合计
                    decimal RowTot = Math.Round((Convert.ToDecimal(LB1.Text) * Convert.ToDecimal(LB2.Text)), 3);
                    LB3.Text = RowTot.ToString();
                    AllTot += RowTot;
                }
                //this.Label1.Text = AllTot.ToString();
                //this.Label2.Text = Maticsoft.Common.Rmb.CmycurD(AllTot);
                this.TotalPrice.Text = AllTot.ToString();
                this.Label9.Text = Maticsoft.Common.Rmb.CmycurD(AllTot);
            }
        }

        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{

        //}
    }
}
