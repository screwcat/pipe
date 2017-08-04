using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.Report
{
    public partial class SaleReport : System.Web.UI.Page
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

                DateTime Begin = Convert.ToDateTime("2000/1/1");
                DateTime End = Convert.ToDateTime(TextBox2.Text).AddDays(1);
                DataSet ds = new BLL.Sale().GetList(AspNetPager2.PageSize, 1, " SaleDate between '" + Begin + "' and '" + End + "'");
                AspNetPager2.RecordCount = 1;
                this.GridView1.DataSource = ds;
                this.GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime Begin = Convert.ToDateTime(TextBox1.Text);
            DateTime End = Convert.ToDateTime(TextBox2.Text).AddDays(1);
            DataSet ds = new BLL.Sale().GetList(AspNetPager2.PageSize, 1, " SaleDate between '" + Begin + "' and '" + End + "'");
            AspNetPager2.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            DateTime Begin = Convert.ToDateTime(TextBox1.Text);
            DateTime End = Convert.ToDateTime(TextBox2.Text).AddDays(1);
            //DataSet ds = new BLL.Sale().GetList(AspNetPager2.PageSize, AspNetPager2.CurrentPageIndex, " SaleDate between '" + Begin + "' and '" + End + "'");
            DataSet ds = new BLL.Sale().GetList(AspNetPager2.PageSize, AspNetPager2.CurrentPageIndex, " TradeNo LIKE '%" + this.TextBox3.Text + "%'");
            AspNetPager2.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new BLL.Sale().GetList(AspNetPager2.PageSize, 1, " TradeNo LIKE '%" + this.TextBox3.Text + "%'");
            AspNetPager2.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }
    }
}
