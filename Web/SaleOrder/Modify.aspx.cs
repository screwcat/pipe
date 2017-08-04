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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int SaleOrder_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(SaleOrder_ID);
				}
			}
		}
			
	private void ShowInfo(int SaleOrder_ID)
	{
		ZhangWei.BLL.SaleOrder bll=new ZhangWei.BLL.SaleOrder();
		ZhangWei.Model.SaleOrder model=bll.GetModel(SaleOrder_ID);
		this.lblSaleOrder_ID.Text=model.SaleOrder_ID.ToString();
		this.txtWriteDate.Text=model.WriteDate.ToString();
		this.txtInsureDate.Text=model.InsureDate.ToString();
		this.txtEndDate.Text=model.EndDate.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtCustomer_ID.Text=model.Customer_ID.ToString();
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int SaleOrder_ID=int.Parse(this.lblSaleOrder_ID.Text);
			DateTime WriteDate=DateTime.Parse(this.txtWriteDate.Text);
			DateTime InsureDate=DateTime.Parse(this.txtInsureDate.Text);
			DateTime EndDate=DateTime.Parse(this.txtEndDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int Customer_ID=int.Parse(this.txtCustomer_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);


			ZhangWei.Model.SaleOrder model=new ZhangWei.Model.SaleOrder();
			model.SaleOrder_ID=SaleOrder_ID;
			model.WriteDate=WriteDate;
			model.InsureDate=InsureDate;
			model.EndDate=EndDate;
			model.Dept_ID=Dept_ID;
			model.Customer_ID=Customer_ID;
			model.Employee_ID=Employee_ID;

			ZhangWei.BLL.SaleOrder bll=new ZhangWei.BLL.SaleOrder();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
