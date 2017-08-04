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
namespace ZhangWei.Web.Dept_Customer
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
		ZhangWei.BLL.Dept_Customer bll=new ZhangWei.BLL.Dept_Customer();
		ZhangWei.Model.Dept_Customer model=bll.GetModel();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtCustomer_ID.Text=model.Customer_ID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCustomer_ID.Text))
			{
				strErr+="Customer_ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int Customer_ID=int.Parse(this.txtCustomer_ID.Text);


			ZhangWei.Model.Dept_Customer model=new ZhangWei.Model.Dept_Customer();
			model.Dept_ID=Dept_ID;
			model.Customer_ID=Customer_ID;

			ZhangWei.BLL.Dept_Customer bll=new ZhangWei.BLL.Dept_Customer();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
