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
namespace ZhangWei.Web.Dept
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
					int Dept_ID=(Convert.ToInt32(strid));
					ShowInfo(Dept_ID);
				}
			}
		}
		
	private void ShowInfo(int Dept_ID)
	{
		ZhangWei.BLL.Dept bll=new ZhangWei.BLL.Dept();
		ZhangWei.Model.Dept model=bll.GetModel(Dept_ID);
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblName.Text=model.Name;
		this.lblRemark.Text=model.Remark;

	}


    }
}
