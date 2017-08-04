using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.warehouse
{
    public partial class EnterStockRecord : System.Web.UI.Page
    {
        ZhangWei.BLL.EnterStock bll = new ZhangWei.BLL.EnterStock();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        public void BindData()
        {


            DataSet ds = new DataSet();

            ds = bll.GetList(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, "");
            AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strWhere = "";
            if (this.TextBox1.Text!="")
            {
                strWhere = "EnterStock_ID = " + this.TextBox1.Text;
            }
            ds = bll.GetList(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, strWhere);
            AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string strWhere = "";
            if (this.TextBox1.Text != "")
            {
                strWhere = "EnterStock_ID = " + this.TextBox1.Text;
            }
            ds = bll.GetList(AspNetPager1.PageSize, 1, strWhere);
            AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
