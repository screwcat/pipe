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
namespace ZhangWei.Web.SaleOrder
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
					int SaleOrder_ID=(Convert.ToInt32(strid));
					ShowInfo(SaleOrder_ID);
				}
			}
		}
		
	private void ShowInfo(int SaleOrder_ID)
	{
		ZhangWei.BLL.SaleOrder bll=new ZhangWei.BLL.SaleOrder();
		ZhangWei.Model.SaleOrder model=bll.GetModel(SaleOrder_ID);
		this.lblSaleOrder_ID.Text=model.SaleOrder_ID.ToString();
		this.lblWriteDate.Text=model.WriteDate.ToString();
		this.lblInsureDate.Text=model.InsureDate.ToString();
		this.lblEndDate.Text=model.EndDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblCustomer_ID.Text=model.Customer_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();

	}


    }
}
