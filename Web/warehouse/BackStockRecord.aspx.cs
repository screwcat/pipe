using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ZhangWei.Web.warehouse
{
    public partial class BackStockRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new BLL.BackStock().GetList(AspNetPager1.PageSize, 1, "");
                GridView1.DataSource = ds;
                AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
                GridView1.DataBind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            string strWhere = "";
            if (this.TextBox1.Text != "")
            {
                strWhere = "BackStock_ID = " + this.TextBox1.Text;
            }
            DataSet ds = new BLL.BackStock().GetList(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere);
            AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (this.TextBox1.Text != "")
            {
                strWhere = "BackStock_ID = " + this.TextBox1.Text;
            }
            DataSet ds = new BLL.BackStock().GetList(AspNetPager1.PageSize, 1, strWhere);
            AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
