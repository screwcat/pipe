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
namespace ZhangWei.Web.Buy
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
					int Buy_ID=(Convert.ToInt32(strid));
					ShowInfo(Buy_ID);
				}
			}
		}
		
	private void ShowInfo(int Buy_ID)
	{
		ZhangWei.BLL.Buy bll=new ZhangWei.BLL.Buy();
		ZhangWei.Model.Buy model=bll.GetModel(Buy_ID);
		this.lblBuy_ID.Text=model.Buy_ID.ToString();
		this.lblComeDate.Text=model.ComeDate.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();

	}


    }
}
