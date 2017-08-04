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
using Maticsoft.Web.LocalCass;
namespace ZhangWei.Web.ProductSpec
{
    public partial class Modify : UserPageBass
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ProductSpec_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ProductSpec_ID);
				}
			}
		}
			
	private void ShowInfo(int ProductSpec_ID)
	{
		ZhangWei.BLL.ProductSpec bll=new ZhangWei.BLL.ProductSpec();
		ZhangWei.Model.ProductSpec model=bll.GetModel(ProductSpec_ID);
		this.lblProductSpec_ID.Text=model.ProductSpec_ID.ToString();
		this.txtName.Text=model.Name;
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();
		this.txtCreateDate.Text=model.CreateDate.ToString();
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtEmployee_ID.Text))
			{
				strErr+="Employee_ID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCreateDate.Text))
			{
				strErr+="CreateDate格式错误！\\n";	
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
			int ProductSpec_ID=int.Parse(this.lblProductSpec_ID.Text);
			string Name=this.txtName.Text;
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);
			DateTime CreateDate=DateTime.Parse(this.txtCreateDate.Text);
			string Remark=this.txtRemark.Text;


			ZhangWei.Model.ProductSpec model=new ZhangWei.Model.ProductSpec();
			model.ProductSpec_ID=ProductSpec_ID;
			model.Name=Name;
			model.Employee_ID=Employee_ID;
			model.CreateDate=CreateDate;
			model.Remark=Remark;

			ZhangWei.BLL.ProductSpec bll=new ZhangWei.BLL.ProductSpec();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
