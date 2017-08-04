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
    public partial class SaleGather : UserPageBass
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
                this.TextBox1.Text = sTemp;
                this.TextBox2.Text = sTemp;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string Begin = TextBox1.Text;
            string End = TextBox2.Text;
            if (this.DropDownList1.SelectedValue == "1")
            {
                this.GridView2.Visible = false;
                this.GridView1.Visible = true;
                DataSet ds = new BLL.Sale_Detail().GetSaleGather(Begin, End);
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
            else
            {
                this.GridView1.Visible = false;
                this.GridView2.Visible = true;
                DataSet ds = new BLL.Sale_Detail().GetGatherByList(Begin, End);
                this.GridView2.DataSource = ds;
                this.GridView2.DataBind();
            }
        }
    }
}
