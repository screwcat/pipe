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
namespace ZhangWei.Web.BackStock
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int BackStock_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(BackStock_ID);
				}
			}
		}
			
	private void ShowInfo(int BackStock_ID)
	{
		ZhangWei.BLL.BackStock bll=new ZhangWei.BLL.BackStock();
		ZhangWei.Model.BackStock model=bll.GetModel(BackStock_ID);
		this.lblBackStock_ID.Text=model.BackStock_ID.ToString();
		this.txtBackDate.Text=model.BackDate.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtBackDate.Text))
			{
				strErr+="BackDate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStoreHouse_ID.Text))
			{
				strErr+="StoreHouse_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEmployee_ID.Text))
			{
				strErr+="Employee_ID格式错误！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="Remark不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int BackStock_ID=int.Parse(this.lblBackStock_ID.Text);
			DateTime BackDate=DateTime.Parse(this.txtBackDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int StoreHouse_ID=int.Parse(this.txtStoreHouse_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);
			string Remark=this.txtRemark.Text;


			ZhangWei.Model.BackStock model=new ZhangWei.Model.BackStock();
			model.BackStock_ID=BackStock_ID;
			model.BackDate=BackDate;
			model.Dept_ID=Dept_ID;
			model.StoreHouse_ID=StoreHouse_ID;
			model.Employee_ID=Employee_ID;
			model.Remark=Remark;

			ZhangWei.BLL.BackStock bll=new ZhangWei.BLL.BackStock();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
