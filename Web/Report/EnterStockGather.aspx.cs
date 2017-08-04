using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.Report
{
    public partial class EnterStockGather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sYear = DateTime.Now.Year.ToString();
                string sMonth = DateTime.Now.Month.ToString();
                string sDay = DateTime.Now.Day.ToString();
                if (sMonth.Length == 1) { sMonth = "0" + sMonth; }
                if (sDay.Length == 1) { sDay = "0" + sDay; }
                string sTemp = sYear + "-" + sMonth + "-" + sDay;
                this.TextBox1.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                this.TextBox2.Text = sTemp;
                this.Label2.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Begin = TextBox1.Text;
            string End = TextBox2.Text;
            if (this.DropDownList1.SelectedValue == "1")
            {
                DataSet ds = new BLL.EnterStock().EnterStockGather(Begin, End);
                this.GridView1.Visible = true;
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
                this.GridView2.Visible = false;
                this.Label2.Visible = false;
            }
            else
            {
                DataSet ds = new BLL.EnterStock().GetGatherByList(Begin, End);
                this.GridView2.Visible = true;
                this.Label2.Visible = true;
                this.GridView2.DataSource = ds;
                this.GridView2.DataBind();
                decimal AllTot = 0;
                foreach (GridViewRow row in GridView2.Rows)
                {
                    AllTot += Convert.ToDecimal(row.Cells[3].Text);
                }
                this.Label2.Text = "合计：" + AllTot;
                this.GridView1.Visible = false;
            }
            
        }
    }
}
