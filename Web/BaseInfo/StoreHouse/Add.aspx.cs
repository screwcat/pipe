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
namespace ZhangWei.Web.StoreHouse
{
    public partial class Add : Page
    {
        DataSet Employee = new BLL.Employee().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Employee;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Employee_ID";
                DropDownList1.DataBind();
            }
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="Phone不能为空！\\n";	
			}
            //if(!PageValidate.IsNumber(txtEmployee_ID.Text))
            //{
            //    strErr+="Employee_ID格式错误！\\n";	
            //}
            //if(!PageValidate.IsDateTime(txtCreateDate.Text))
            //{
            //    strErr+="CreateDate格式错误！\\n";	
            //}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Address=this.txtAddress.Text;
			string Phone=this.txtPhone.Text;
			int Employee_ID=int.Parse(this.DropDownList1.SelectedValue);
			DateTime CreateDate=DateTime.Now;

			ZhangWei.Model.StoreHouse model=new ZhangWei.Model.StoreHouse();
			model.Address=Address;
			model.Phone=Phone;
			model.Employee_ID=Employee_ID;
			model.CreateDate=CreateDate;

			ZhangWei.BLL.StoreHouse bll=new ZhangWei.BLL.StoreHouse();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
