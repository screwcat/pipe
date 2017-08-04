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
namespace ZhangWei.Web.BackStock
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
					int BackStock_ID=(Convert.ToInt32(strid));
					ShowInfo(BackStock_ID);
				}
			}
		}
		
	private void ShowInfo(int BackStock_ID)
	{
		ZhangWei.BLL.BackStock bll=new ZhangWei.BLL.BackStock();
		ZhangWei.Model.BackStock model=bll.GetModel(BackStock_ID);
		this.lblBackStock_ID.Text=model.BackStock_ID.ToString();
		this.lblBackDate.Text=model.BackDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
