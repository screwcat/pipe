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
namespace ZhangWei.Web.SaleOrder
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtWriteDate.Text))
			{
				strErr+="WriteDate格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtInsureDate.Text))
			{
				strErr+="InsureDate格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtEndDate.Text))
			{
				strErr+="EndDate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCustomer_ID.Text))
			{
				strErr+="Customer_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEmployee_ID.Text))
			{
				strErr+="Employee_ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			DateTime WriteDate=DateTime.Parse(this.txtWriteDate.Text);
			DateTime InsureDate=DateTime.Parse(this.txtInsureDate.Text);
			DateTime EndDate=DateTime.Parse(this.txtEndDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int Customer_ID=int.Parse(this.txtCustomer_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);

			ZhangWei.Model.SaleOrder model=new ZhangWei.Model.SaleOrder();
			model.WriteDate=WriteDate;
			model.InsureDate=InsureDate;
			model.EndDate=EndDate;
			model.Dept_ID=Dept_ID;
			model.Customer_ID=Customer_ID;
			model.Employee_ID=Employee_ID;

			ZhangWei.BLL.SaleOrder bll=new ZhangWei.BLL.SaleOrder();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
