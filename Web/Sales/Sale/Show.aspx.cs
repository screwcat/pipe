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
namespace ZhangWei.Web.Sale
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
					int Sale_ID=(Convert.ToInt32(strid));
					ShowInfo(Sale_ID);
				}
			}
		}
		
	private void ShowInfo(int Sale_ID)
	{
		ZhangWei.BLL.Sale bll=new ZhangWei.BLL.Sale();
		ZhangWei.Model.Sale model=bll.GetModel(Sale_ID);
		this.lblSale_ID.Text=model.Sale_ID.ToString();
		this.lblSaleDate.Text=model.SaleDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();

	}


    }
}
