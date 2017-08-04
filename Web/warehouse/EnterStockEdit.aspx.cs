using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.warehouse
{
    public partial class EnterStockEdit : System.Web.UI.Page
    {
        //ZhangWei.BLL.BuyOrder bll = new ZhangWei.BLL.BuyOrder();
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
            BindData();
        }
    }
}
