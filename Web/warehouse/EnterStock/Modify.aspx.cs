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
namespace ZhangWei.Web.EnterStock
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int EnterStock_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(EnterStock_ID);
				}
			}
		}
			
	private void ShowInfo(int EnterStock_ID)
	{
		ZhangWei.BLL.EnterStock bll=new ZhangWei.BLL.EnterStock();
		ZhangWei.Model.EnterStock model=bll.GetModel(EnterStock_ID);
		this.lblEnterStock_ID.Text=model.EnterStock_ID.ToString();
		this.txtEnterDate.Text=model.EnterDate.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtEnterDate.Text))
			{
				strErr+="EnterDate格式错误！\\n";	
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

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int EnterStock_ID=int.Parse(this.lblEnterStock_ID.Text);
			DateTime EnterDate=DateTime.Parse(this.txtEnterDate.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int StoreHouse_ID=int.Parse(this.txtStoreHouse_ID.Text);
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);


			ZhangWei.Model.EnterStock model=new ZhangWei.Model.EnterStock();
			model.EnterStock_ID=EnterStock_ID;
			model.EnterDate=EnterDate;
			model.Dept_ID=Dept_ID;
			model.StoreHouse_ID=StoreHouse_ID;
			model.Employee_ID=Employee_ID;

			ZhangWei.BLL.EnterStock bll=new ZhangWei.BLL.EnterStock();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
