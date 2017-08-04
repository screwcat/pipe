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
namespace ZhangWei.Web.EnterStock
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
					int EnterStock_ID=(Convert.ToInt32(strid));
					ShowInfo(EnterStock_ID);
				}
			}
		}
		
	private void ShowInfo(int EnterStock_ID)
	{
		ZhangWei.BLL.EnterStock bll=new ZhangWei.BLL.EnterStock();
		ZhangWei.Model.EnterStock model=bll.GetModel(EnterStock_ID);
		this.lblEnterStock_ID.Text=model.EnterStock_ID.ToString();
		this.lblEnterDate.Text=model.EnterDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();

	}


    }
}
