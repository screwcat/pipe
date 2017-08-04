using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace ZhangWei.Web.ProductList
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ProductList_ID=(Convert.ToInt32(strid));
					ShowInfo(ProductList_ID);
				}
			}
		}
		
	private void ShowInfo(int ProductList_ID)
	{
		ZhangWei.BLL.ProductList bll=new ZhangWei.BLL.ProductList();
		ZhangWei.Model.ProductList model=bll.GetModel(ProductList_ID);
		this.lblProductClass_ID.Text=model.ProductClass_ID.ToString();
		this.lblProductList_ID.Text=model.ProductList_ID.ToString();
		this.lblName.Text=model.Name;
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();
		this.lblCreateDate.Text=model.CreateDate.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
