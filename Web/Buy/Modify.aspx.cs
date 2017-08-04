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
namespace ZhangWei.Web.Buy
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Buy_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Buy_ID);
				}
			}
		}
			
	private void ShowInfo(int Buy_ID)
	{
		ZhangWei.BLL.Buy bll=new ZhangWei.BLL.Buy();
		ZhangWei.Model.Buy model=bll.GetModel(Buy_ID);
		this.lblBuy_ID.Text=model.Buy_ID.ToString();
		this.txtComeDate.Text=model.ComeDate.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtComeDate.Text))
			{
				strErr+="ComeDate格式错误！\\n";	
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
			int Buy_ID=int.Parse(this.lblBuy_ID.Text);
			DateTime ComeDate=DateTime.Parse(this.txtComeDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);


			ZhangWei.Model.Buy model=new ZhangWei.Model.Buy();
			model.Buy_ID=Buy_ID;
			model.ComeDate=ComeDate;
			model.Dept_ID=Dept_ID;
			model.Employee_ID=Employee_ID;

			ZhangWei.BLL.Buy bll=new ZhangWei.BLL.Buy();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
