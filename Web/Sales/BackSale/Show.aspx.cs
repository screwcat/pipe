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
namespace ZhangWei.Web.BackSale
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
					int BackSale_ID=(Convert.ToInt32(strid));
					ShowInfo(BackSale_ID);
				}
			}
		}
		
	private void ShowInfo(int BackSale_ID)
	{
		ZhangWei.BLL.BackSale bll=new ZhangWei.BLL.BackSale();
		ZhangWei.Model.BackSale model=bll.GetModel(BackSale_ID);
		this.lblBackSale_ID.Text=model.BackSale_ID.ToString();
		this.lblBackDate.Text=model.BackDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
