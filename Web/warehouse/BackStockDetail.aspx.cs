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
    public partial class BackStockDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 BackStock_ID = 0;
            if (Request.Params["BackStock_ID"] != null && Request.Params["BackStock_ID"].Trim() != "")
            {
                BackStock_ID = (Convert.ToInt32(Request.Params["BackStock_ID"]));
            }
            DataSet ds = new BLL.BackStock_Detail().GetBackStockDtl(BackStock_ID);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
