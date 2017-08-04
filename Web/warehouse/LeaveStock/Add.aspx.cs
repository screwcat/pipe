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
namespace ZhangWei.Web.LeaveStock
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtLeaveDate.Text))
			{
				strErr+="LeaveDate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStoreHouse_ID.Text))
			{
				strErr+="StoreHouse_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtToStoreHouse_ID.Text))
			{
				strErr+="ToStoreHouse_ID格式错误！\\n";	
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
			DateTime LeaveDate=DateTime.Parse(this.txtLeaveDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int StoreHouse_ID=int.Parse(this.txtStoreHouse_ID.Text);
			int ToStoreHouse_ID=int.Parse(this.txtToStoreHouse_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);

			ZhangWei.Model.LeaveStock model=new ZhangWei.Model.LeaveStock();
			model.LeaveDate=LeaveDate;
			model.Dept_ID=Dept_ID;
			model.StoreHouse_ID=StoreHouse_ID;
			model.ToStoreHouse_ID=ToStoreHouse_ID;
			model.Employee_ID=Employee_ID;

			ZhangWei.BLL.LeaveStock bll=new ZhangWei.BLL.LeaveStock();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
