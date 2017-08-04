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
namespace ZhangWei.Web.Customer
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Customer_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Customer_ID);
				}
			}
		}
			
	private void ShowInfo(int Customer_ID)
	{
		ZhangWei.BLL.Customer bll=new ZhangWei.BLL.Customer();
		ZhangWei.Model.Customer model=bll.GetModel(Customer_ID);
		this.lblCustomer_ID.Text=model.Customer_ID.ToString();
		this.txtName.Text=model.Name;
		this.txtAddress.Text=model.Address;
		this.txtPhone.Text=model.Phone;
		this.txtFax.Text=model.Fax;
		this.txtPostalCode.Text=model.PostalCode;
		this.txtConstactPerson.Text=model.ConstactPerson;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="Phone不能为空！\\n";	
			}
			if(this.txtFax.Text.Trim().Length==0)
			{
				strErr+="Fax不能为空！\\n";	
			}
			if(this.txtPostalCode.Text.Trim().Length==0)
			{
				strErr+="PostalCode不能为空！\\n";	
			}
			if(this.txtConstactPerson.Text.Trim().Length==0)
			{
				strErr+="ConstactPerson不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Customer_ID=int.Parse(this.lblCustomer_ID.Text);
			string Name=this.txtName.Text;
			string Address=this.txtAddress.Text;
			string Phone=this.txtPhone.Text;
			string Fax=this.txtFax.Text;
			string PostalCode=this.txtPostalCode.Text;
			string ConstactPerson=this.txtConstactPerson.Text;


			ZhangWei.Model.Customer model=new ZhangWei.Model.Customer();
			model.Customer_ID=Customer_ID;
			model.Name=Name;
			model.Address=Address;
			model.Phone=Phone;
			model.Fax=Fax;
			model.PostalCode=PostalCode;
			model.ConstactPerson=ConstactPerson;

			ZhangWei.BLL.Customer bll=new ZhangWei.BLL.Customer();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
