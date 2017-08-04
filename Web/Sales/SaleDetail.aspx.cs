using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web.Sales
{
    public partial class SaleDetail : UserPageBass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["Sale_ID"] != null && Request.Params["Sale_ID"].Trim() != "")
            {
                Model.Sale ml_sa = new BLL.Sale().GetModel(Convert.ToInt32(Request.Params["Sale_ID"]));
                this.Label10.Text = ml_sa.SaleDate.ToString("yyyy-M-d H:mm:ss");
                this.Label11.Text = ml_sa.TradeNo.ToString();
                Model.StoreHouse ml_sh = new BLL.StoreHouse().GetModel(Convert.ToInt32(ml_sa.StoreHouse_ID));
                this.Label12.Text = ml_sh.Address;

                this.Label13.Text = "100";
                this.Label14.Text = ml_sa.GatheringWay;
                this.Label15.Text = ml_sa.Account;
                this.Label16.Text = "";
                this.Label17.Text = ml_sa.Address;
                Model.Customer ml_cu = new BLL.Customer().GetModel(Convert.ToInt32(ml_sa.Customer));
                this.Label18.Text = ml_cu.Name;
                this.Label19.Text = new BLL.Employee().GetModel(ml_sa.Employee_ID).Name;
                //Label1.Text = Request.Params["Sale_ID"].Trim();
                DataSet ds = new BLL.Sale_Detail().GetDetailAll(Convert.ToInt32(Request.Params["Sale_ID"]));
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
            decimal TotalPrice = 0;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label LB1 = (Label)item.FindControl("Label5");//单价
                Label LB2 = (Label)item.FindControl("Label4");//数量
                Label LB3 = (Label)item.FindControl("Label6");//合计
                LB3.Text = Math.Round((Convert.ToDecimal(LB1.Text) * Convert.ToDecimal(LB2.Text)),3).ToString();
                TotalPrice += Convert.ToDecimal(LB3.Text);
            }
            this.TotalPrice.Text = Math.Round((Convert.ToDecimal(TotalPrice)),3).ToString();
            Label9.Text = Maticsoft.Common.Rmb.CmycurD(TotalPrice);
        }

    }
}
