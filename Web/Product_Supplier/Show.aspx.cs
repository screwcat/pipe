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
namespace ZhangWei.Web.Product_Supplier
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
					int Product_ID=(Convert.ToInt32(strid));
					ShowInfo(Product_ID);
				}
			}
		}
		
	private void ShowInfo(int Product_ID)
	{
		ZhangWei.BLL.Product_Supplier bll=new ZhangWei.BLL.Product_Supplier();
		ZhangWei.Model.Product_Supplier model=bll.GetModel(Product_ID);
		this.lblProduct_ID.Text=model.Product_ID.ToString();
		this.lblSupplier_ID.Text=model.Supplier_ID.ToString();

	}


    }
}
