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
namespace ZhangWei.Web.user
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
		
	private void ShowInfo()
	{
		ZhangWei.BLL.user bll=new ZhangWei.BLL.user();
		ZhangWei.Model.user model=bll.GetModel();
		this.lblUser_Id.Text=model.User_Id;
		this.lblUser_Pwd.Text=model.User_Pwd;
		this.lblAgain_Pwd.Text=model.Again_Pwd;
		this.lblBel_Group.Text=model.Bel_Group;
		this.lblDiv_Type.Text=model.Div_Type;
		this.lblUser_Auth.Text=model.User_Auth;
		this.lblAuth_Type.Text=model.Auth_Type;
		this.lblUser_Status.Text=model.User_Status;
		this.lblCreate_User.Text=model.Create_User;
		this.lblCreate_Date.Text=model.Create_Date;
		this.lblCreate_Time.Text=model.Create_Time;
		this.lblAppr_User.Text=model.Appr_User;
		this.lblAppr_Date.Text=model.Appr_Date;
		this.lblAppr_Time.Text=model.Appr_Time;
		this.lblPwd_Date.Text=model.Pwd_Date;
		this.lblErr_Count.Text=model.Err_Count.ToString();
		this.lblUse_eJCIC.Text=model.Use_eJCIC;

	}


    }
}
