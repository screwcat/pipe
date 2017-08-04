using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.Report
{
    public partial class CheckStock : System.Web.UI.Page
    {
        DataSet StockHouse = new BLL.StoreHouse().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DropDownList1.DataSource = StockHouse;
                this.DropDownList1.DataTextField = "Address";
                this.DropDownList1.DataValueField = "StoreHouse_ID";
                this.DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new BLL.StockPile().CheckStock(Convert.ToInt32(DropDownList1.SelectedValue));
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        
    }
}
