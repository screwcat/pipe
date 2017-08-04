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
using Maticsoft.Web.LocalCass;
namespace ZhangWei.Web.EUser
{
    public partial class Add : UserPageBass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="UserName不能为空！\\n";	
			}
			if(this.txtPassWord.Text.Trim().Length==0)
			{
				strErr+="PassWord不能为空！\\n";	
			}
			if(this.txtEmail.Text.Trim().Length==0)
			{
				strErr+="Email不能为空！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtSex.Text.Trim().Length==0)
			{
				strErr+="Sex不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAge.Text))
			{
				strErr+="Age格式错误！\\n";	
			}
			if(this.txtID_Card.Text.Trim().Length==0)
			{
				strErr+="ID_Card不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="Phone不能为空！\\n";	
			}
			if(this.txtMobilPhone.Text.Trim().Length==0)
			{
				strErr+="MobilPhone不能为空！\\n";	
			}
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtPostalcode.Text.Trim().Length==0)
			{
				strErr+="Postalcode不能为空！\\n";	
			}
			if(this.txtWork.Text.Trim().Length==0)
			{
				strErr+="Work不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtIncome.Text))
			{
				strErr+="Income格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtIntegral.Text))
			{
				strErr+="Integral格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCreateTime.Text))
			{
				strErr+="CreateTime格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtLaseLogin.Text))
			{
				strErr+="LaseLogin格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string UserName=this.txtUserName.Text;
			string PassWord=this.txtPassWord.Text;
			string Email=this.txtEmail.Text;
			string Name=this.txtName.Text;
			string Sex=this.txtSex.Text;
			int Age=int.Parse(this.txtAge.Text);
			string ID_Card=this.txtID_Card.Text;
			string Phone=this.txtPhone.Text;
			string MobilPhone=this.txtMobilPhone.Text;
			string Address=this.txtAddress.Text;
			string Postalcode=this.txtPostalcode.Text;
			string Work=this.txtWork.Text;
			decimal Income=decimal.Parse(this.txtIncome.Text);
			int Integral=int.Parse(this.txtIntegral.Text);
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
			DateTime LaseLogin=DateTime.Parse(this.txtLaseLogin.Text);

			ZhangWei.Model.EUser model=new ZhangWei.Model.EUser();
			model.UserName=UserName;
			model.PassWord=PassWord;
			model.Email=Email;
			model.Name=Name;
			model.Sex=Sex;
			model.Age=Age;
			model.ID_Card=ID_Card;
			model.Phone=Phone;
			model.MobilPhone=MobilPhone;
			model.Address=Address;
			model.Postalcode=Postalcode;
			model.Work=Work;
			model.Income=Income;
			model.Integral=Integral;
			model.CreateTime=CreateTime;
			model.LaseLogin=LaseLogin;

			ZhangWei.BLL.EUser bll=new ZhangWei.BLL.EUser();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
