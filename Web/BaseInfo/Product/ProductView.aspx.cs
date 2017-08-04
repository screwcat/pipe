using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace ZhangWei.Web.BaseInfo.Product
{
    public partial class ProductView : System.Web.UI.Page
    {
        //public Int32 selected;
        //DataSet ProductList = new BLL.ProductList().GetAllList();
        DataSet ProductClass = new BLL.ProductClass().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            //selected = Convert.ToInt32(Session["selected"]);
            if (!IsPostBack)
            {
                
                DropDownList2.DataSource = ProductClass;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "ProductClass_ID";
                DropDownList2.DataBind();
                AspNetPager1.PageSize = 10;
                DataSet ds = new BLL.Product().GetListFromView(10, AspNetPager1.CurrentPageIndex, GetComm());
                AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataSet ds = new BLL.Product().GetListFromView(10, AspNetPager1.CurrentPageIndex, GetComm());
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        public string GetComm()
        {
            StringBuilder str = new StringBuilder();
            if (TextBox1.Text != "")
            {
                str.Append("Product_ID = " + TextBox1.Text);
            }
            if (TextBox2.Text != "")
            {
                str.Append(" and Name like '%" + TextBox2.Text + "%'");
            }
            if (TextBox4.Text != "")
            {
                str.Append(" and spell like '%" + TextBox4.Text + "%'");
            }
            if (TextBox3.Text != "")
            {
                str.Append(" and s_spell like '%" + TextBox3.Text + "%'");
            }
            if (Request.Form["proList"] != "0" & Request.Form["proList"] != null)
            {
                str.Append(" and ProductList_ID = " + Request.Form["proList"]);
                HiddenField1.Value = Request.Form["proList"];
            }
            string comm = str.ToString();
            if (comm.TrimStart().StartsWith("and"))
            {
                comm = comm.Substring(4);
            }
            return comm;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new BLL.Product().GetListFromView(10, 1, GetComm());
            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["Total"]);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }
}