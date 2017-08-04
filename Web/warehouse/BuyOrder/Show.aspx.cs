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
namespace ZhangWei.Web.BuyOrder
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
					int BuyOrder_ID=(Convert.ToInt32(strid));
					ShowInfo(BuyOrder_ID);
				}
			}
		}
		
	private void ShowInfo(int BuyOrder_ID)
	{
		ZhangWei.BLL.BuyOrder bll=new ZhangWei.BLL.BuyOrder();
		ZhangWei.Model.BuyOrder model=bll.GetModel(BuyOrder_ID);
		this.lblBuyOrder_ID.Text=model.BuyOrder_ID.ToString();
		this.lblWriteDate.Text=model.WriteDate.ToString();
		this.lblInsureDate.Text=model.InsureDate.ToString();
		this.lblEndDate.Text=model.EndDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblSupplier_ID.Text=model.Supplier_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();

	}


    }
}
