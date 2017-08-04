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
namespace ZhangWei.Web.Sale
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Sale_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Sale_ID);
				}
			}
		}
			
	private void ShowInfo(int Sale_ID)
	{
		ZhangWei.BLL.Sale bll=new ZhangWei.BLL.Sale();
		ZhangWei.Model.Sale model=bll.GetModel(Sale_ID);
		this.lblSale_ID.Text=model.Sale_ID.ToString();
		this.txtSaleDate.Text=model.SaleDate.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtSaleDate.Text))
			{
				strErr+="SaleDate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
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
			int Sale_ID=int.Parse(this.lblSale_ID.Text);
			DateTime SaleDate=DateTime.Parse(this.txtSaleDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);


			ZhangWei.Model.Sale model=new ZhangWei.Model.Sale();
			model.Sale_ID=Sale_ID;
			model.SaleDate=SaleDate;
			model.Dept_ID=Dept_ID;
			model.Employee_ID=Employee_ID;

			ZhangWei.BLL.Sale bll=new ZhangWei.BLL.Sale();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
