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
namespace ZhangWei.Web.Employee
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Employee_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Employee_ID);
				}
			}
		}
			
	private void ShowInfo(int Employee_ID)
	{
		ZhangWei.BLL.Employee bll=new ZhangWei.BLL.Employee();
		ZhangWei.Model.Employee model=bll.GetModel(Employee_ID);
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtName.Text=model.Name;
		this.txtDuty.Text=model.Duty;
		this.txtGender.Text=model.Gender;
		this.txtBirthDate.Text=model.BirthDate.ToString();
		this.txtHireDate.Text=model.HireDate.ToString();
		this.txtMatureDate.Text=model.MatureDate.ToString();
		this.txtIdentityCard.Text=model.IdentityCard;
		this.txtAddress.Text=model.Address;
		this.txtPhone.Text=model.Phone;
		this.txtEmail.Text=model.Email;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtDuty.Text.Trim().Length==0)
			{
				strErr+="Duty不能为空！\\n";	
			}
			if(this.txtGender.Text.Trim().Length==0)
			{
				strErr+="Gender不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtBirthDate.Text))
			{
				strErr+="BirthDate格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtHireDate.Text))
			{
				strErr+="HireDate格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtMatureDate.Text))
			{
				strErr+="MatureDate格式错误！\\n";	
			}
			if(this.txtIdentityCard.Text.Trim().Length==0)
			{
				strErr+="IdentityCard不能为空！\\n";	
			}
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="Phone不能为空！\\n";	
			}
			if(this.txtEmail.Text.Trim().Length==0)
			{
				strErr+="Email不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Employee_ID=int.Parse(this.lblEmployee_ID.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			string Name=this.txtName.Text;
			string Duty=this.txtDuty.Text;
			string Gender=this.txtGender.Text;
			DateTime BirthDate=DateTime.Parse(this.txtBirthDate.Text);
			DateTime HireDate=DateTime.Parse(this.txtHireDate.Text);
			DateTime MatureDate=DateTime.Parse(this.txtMatureDate.Text);
			string IdentityCard=this.txtIdentityCard.Text;
			string Address=this.txtAddress.Text;
			string Phone=this.txtPhone.Text;
			string Email=this.txtEmail.Text;


			ZhangWei.Model.Employee model=new ZhangWei.Model.Employee();
			model.Employee_ID=Employee_ID;
			model.Dept_ID=Dept_ID;
			model.Name=Name;
			model.Duty=Duty;
			model.Gender=Gender;
			model.BirthDate=BirthDate;
			model.HireDate=HireDate;
			model.MatureDate=MatureDate;
			model.IdentityCard=IdentityCard;
			model.Address=Address;
			model.Phone=Phone;
			model.Email=Email;

			ZhangWei.BLL.Employee bll=new ZhangWei.BLL.Employee();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
