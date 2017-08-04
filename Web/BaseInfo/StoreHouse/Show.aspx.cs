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
namespace ZhangWei.Web.StoreHouse
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
					int StoreHouse_ID=(Convert.ToInt32(strid));
					ShowInfo(StoreHouse_ID);
				}
			}
		}
		
	private void ShowInfo(int StoreHouse_ID)
	{
		ZhangWei.BLL.StoreHouse bll=new ZhangWei.BLL.StoreHouse();
		ZhangWei.Model.StoreHouse model=bll.GetModel(StoreHouse_ID);
		this.lblStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.lblAddress.Text=model.Address;
		this.lblPhone.Text=model.Phone;
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();
		this.lblCreateDate.Text=model.CreateDate.ToString();

	}


    }
}
