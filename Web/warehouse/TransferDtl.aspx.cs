using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.warehouse
{
    public partial class TransferDtl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 LeaveStock_ID = 0;
            if (Request.Params["LeaveStock_ID"] != null && Request.Params["LeaveStock_ID"].Trim() != "")
            {
                LeaveStock_ID = (Convert.ToInt32(Request.Params["LeaveStock_ID"]));
            }
            Model.LeaveStock ml_ls = new BLL.LeaveStock().GetModel(LeaveStock_ID);
            this.Label1.Text = ml_ls.LeaveStock_ID.ToString();
            this.Label2.Text = (new BLL.Employee().GetModel(ml_ls.Employee_ID)).Name;
            this.Label3.Text = ml_ls.LeaveDate.ToString();
            DataSet ds = new BLL.LeaveStock_Detail().GetTransferDtl(LeaveStock_ID);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            decimal AllTot = 0;
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                decimal price = Convert.ToDecimal(gvr.Cells[7].Text);
                decimal qty = Convert.ToDecimal(gvr.Cells[8].Text);
                decimal RowTot = price * qty;
                gvr.Cells[9].Text = RowTot.ToString();
                AllTot += RowTot;
            }
            this.Label4.Text = AllTot.ToString();
            this.Label5.Text = Maticsoft.Common.Rmb.CmycurD(AllTot);
        }
    }
}
