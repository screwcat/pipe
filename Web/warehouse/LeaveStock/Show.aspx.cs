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
namespace ZhangWei.Web.LeaveStock
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
					int LeaveStock_ID=(Convert.ToInt32(strid));
					ShowInfo(LeaveStock_ID);
				}
			}
		}
		
	private void ShowInfo(int LeaveStock_ID)
	{
		ZhangWei.BLL.LeaveStock bll=new ZhangWei.BLL.LeaveStock();
		ZhangWei.Model.LeaveStock model=bll.GetModel(LeaveStock_ID);
		this.lblLeaveStock_ID.Text=model.LeaveStock_ID.ToString();
		this.lblLeaveDate.Text=model.LeaveDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.lblToStoreHouse_ID.Text=model.ToStoreHouse_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();

	}


    }
}
