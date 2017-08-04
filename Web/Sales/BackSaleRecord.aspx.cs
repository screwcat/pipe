using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.Sales
{
    public partial class BackSaleRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new BLL.BackSale().GetList(AspNetPager1.PageSize, 1, "");
                AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataSet ds = new BLL.BackSale().GetList(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, "");
            AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
