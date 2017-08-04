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
namespace ZhangWei.Web.Customer
{
    public partial class Add : UserPageBass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="名称不能为空！\\n";	
			}
            //if(this.txtAddress.Text.Trim().Length==0)
            //{
            //    strErr+="Address不能为空！\\n";	
            //}
            //if(this.txtPhone.Text.Trim().Length==0)
            //{
            //    strErr+="Phone不能为空！\\n";	
            //}
            //if(this.txtFax.Text.Trim().Length==0)
            //{
            //    strErr+="Fax不能为空！\\n";	
            //}
            //if(this.txtPostalCode.Text.Trim().Length==0)
            //{
            //    strErr+="PostalCode不能为空！\\n";	
            //}
            //if(this.txtConstactPerson.Text.Trim().Length==0)
            //{
            //    strErr+="ConstactPerson不能为空！\\n";	
            //}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			string Address=this.txtAddress.Text;
			string Phone=this.txtPhone.Text;
			string Fax=this.txtFax.Text;
			string PostalCode=this.txtPostalCode.Text;
			string ConstactPerson=this.txtConstactPerson.Text;

			ZhangWei.Model.Customer model=new ZhangWei.Model.Customer();
			model.Name=Name;
			model.Address=Address;
			model.Phone=Phone;
			model.Fax=Fax;
			model.PostalCode=PostalCode;
			model.ConstactPerson=ConstactPerson;

			ZhangWei.BLL.Customer bll=new ZhangWei.BLL.Customer();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
