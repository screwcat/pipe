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
namespace ZhangWei.Web.Dept_Supplier
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSupplier_ID.Text))
			{
				strErr+="Supplier_ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int Supplier_ID=int.Parse(this.txtSupplier_ID.Text);

			ZhangWei.Model.Dept_Supplier model=new ZhangWei.Model.Dept_Supplier();
			model.Dept_ID=Dept_ID;
			model.Supplier_ID=Supplier_ID;

			ZhangWei.BLL.Dept_Supplier bll=new ZhangWei.BLL.Dept_Supplier();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
