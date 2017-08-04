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
using Maticsoft.Web.LocalCass;
namespace ZhangWei.Web.ProductSpec
{
    public partial class Show : UserPageBass
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int ProductSpec_ID=(Convert.ToInt32(strid));
					ShowInfo(ProductSpec_ID);
				}
			}
		}
		
	private void ShowInfo(int ProductSpec_ID)
	{
		ZhangWei.BLL.ProductSpec bll=new ZhangWei.BLL.ProductSpec();
		ZhangWei.Model.ProductSpec model=bll.GetModel(ProductSpec_ID);
		this.lblProductSpec_ID.Text=model.ProductSpec_ID.ToString();
		this.lblName.Text=model.Name;
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();
		this.lblCreateDate.Text=model.CreateDate.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
