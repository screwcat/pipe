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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace ZhangWei.Web.user
{
    public partial class Modify : Page
    {       

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
		this.txtUser_Id.Text=model.User_Id;
		this.txtUser_Pwd.Text=model.User_Pwd;
		this.txtAgain_Pwd.Text=model.Again_Pwd;
		this.txtBel_Group.Text=model.Bel_Group;
		this.txtDiv_Type.Text=model.Div_Type;
		this.txtUser_Auth.Text=model.User_Auth;
		this.txtAuth_Type.Text=model.Auth_Type;
		this.txtUser_Status.Text=model.User_Status;
		this.txtCreate_User.Text=model.Create_User;
		this.txtCreate_Date.Text=model.Create_Date;
		this.txtCreate_Time.Text=model.Create_Time;
		this.txtAppr_User.Text=model.Appr_User;
		this.txtAppr_Date.Text=model.Appr_Date;
		this.txtAppr_Time.Text=model.Appr_Time;
		this.txtPwd_Date.Text=model.Pwd_Date;
		this.txtErr_Count.Text=model.Err_Count.ToString();
		this.txtUse_eJCIC.Text=model.Use_eJCIC;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUser_Id.Text.Trim().Length==0)
			{
				strErr+="User_Id不能为空！\\n";	
			}
			if(this.txtUser_Pwd.Text.Trim().Length==0)
			{
				strErr+="User_Pwd不能为空！\\n";	
			}
			if(this.txtAgain_Pwd.Text.Trim().Length==0)
			{
				strErr+="Again_Pwd不能为空！\\n";	
			}
			if(this.txtBel_Group.Text.Trim().Length==0)
			{
				strErr+="Bel_Group不能为空！\\n";	
			}
			if(this.txtDiv_Type.Text.Trim().Length==0)
			{
				strErr+="Div_Type不能为空！\\n";	
			}
			if(this.txtUser_Auth.Text.Trim().Length==0)
			{
				strErr+="User_Auth不能为空！\\n";	
			}
			if(this.txtAuth_Type.Text.Trim().Length==0)
			{
				strErr+="Auth_Type不能为空！\\n";	
			}
			if(this.txtUser_Status.Text.Trim().Length==0)
			{
				strErr+="User_Status不能为空！\\n";	
			}
			if(this.txtCreate_User.Text.Trim().Length==0)
			{
				strErr+="Create_User不能为空！\\n";	
			}
			if(this.txtCreate_Date.Text.Trim().Length==0)
			{
				strErr+="Create_Date不能为空！\\n";	
			}
			if(this.txtCreate_Time.Text.Trim().Length==0)
			{
				strErr+="Create_Time不能为空！\\n";	
			}
			if(this.txtAppr_User.Text.Trim().Length==0)
			{
				strErr+="Appr_User不能为空！\\n";	
			}
			if(this.txtAppr_Date.Text.Trim().Length==0)
			{
				strErr+="Appr_Date不能为空！\\n";	
			}
			if(this.txtAppr_Time.Text.Trim().Length==0)
			{
				strErr+="Appr_Time不能为空！\\n";	
			}
			if(this.txtPwd_Date.Text.Trim().Length==0)
			{
				strErr+="Pwd_Date不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtErr_Count.Text))
			{
				strErr+="Err_Count格式错误！\\n";	
			}
			if(this.txtUse_eJCIC.Text.Trim().Length==0)
			{
				strErr+="Use_eJCIC不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string User_Id=this.txtUser_Id.Text;
			string User_Pwd=this.txtUser_Pwd.Text;
			string Again_Pwd=this.txtAgain_Pwd.Text;
			string Bel_Group=this.txtBel_Group.Text;
			string Div_Type=this.txtDiv_Type.Text;
			string User_Auth=this.txtUser_Auth.Text;
			string Auth_Type=this.txtAuth_Type.Text;
			string User_Status=this.txtUser_Status.Text;
			string Create_User=this.txtCreate_User.Text;
			string Create_Date=this.txtCreate_Date.Text;
			string Create_Time=this.txtCreate_Time.Text;
			string Appr_User=this.txtAppr_User.Text;
			string Appr_Date=this.txtAppr_Date.Text;
			string Appr_Time=this.txtAppr_Time.Text;
			string Pwd_Date=this.txtPwd_Date.Text;
			decimal Err_Count=decimal.Parse(this.txtErr_Count.Text);
			string Use_eJCIC=this.txtUse_eJCIC.Text;


			ZhangWei.Model.user model=new ZhangWei.Model.user();
			model.User_Id=User_Id;
			model.User_Pwd=User_Pwd;
			model.Again_Pwd=Again_Pwd;
			model.Bel_Group=Bel_Group;
			model.Div_Type=Div_Type;
			model.User_Auth=User_Auth;
			model.Auth_Type=Auth_Type;
			model.User_Status=User_Status;
			model.Create_User=Create_User;
			model.Create_Date=Create_Date;
			model.Create_Time=Create_Time;
			model.Appr_User=Appr_User;
			model.Appr_Date=Appr_Date;
			model.Appr_Time=Appr_Time;
			model.Pwd_Date=Pwd_Date;
			model.Err_Count=Err_Count;
			model.Use_eJCIC=Use_eJCIC;

			ZhangWei.BLL.user bll=new ZhangWei.BLL.user();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
