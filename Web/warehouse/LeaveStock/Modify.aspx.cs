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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int LeaveStock_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(LeaveStock_ID);
				}
			}
		}
			
	private void ShowInfo(int LeaveStock_ID)
	{
		ZhangWei.BLL.LeaveStock bll=new ZhangWei.BLL.LeaveStock();
		ZhangWei.Model.LeaveStock model=bll.GetModel(LeaveStock_ID);
		this.lblLeaveStock_ID.Text=model.LeaveStock_ID.ToString();
		this.txtLeaveDate.Text=model.LeaveDate.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.txtToStoreHouse_ID.Text=model.ToStoreHouse_ID.ToString();
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int LeaveStock_ID=int.Parse(this.lblLeaveStock_ID.Text);
			DateTime LeaveDate=DateTime.Parse(this.txtLeaveDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int StoreHouse_ID=int.Parse(this.txtStoreHouse_ID.Text);
			int ToStoreHouse_ID=int.Parse(this.txtToStoreHouse_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);


			ZhangWei.Model.LeaveStock model=new ZhangWei.Model.LeaveStock();
			model.LeaveStock_ID=LeaveStock_ID;
			model.LeaveDate=LeaveDate;
			model.Dept_ID=Dept_ID;
			model.StoreHouse_ID=StoreHouse_ID;
			model.ToStoreHouse_ID=ToStoreHouse_ID;
			model.Employee_ID=Employee_ID;

			ZhangWei.BLL.LeaveStock bll=new ZhangWei.BLL.LeaveStock();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
