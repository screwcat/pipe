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
namespace ZhangWei.Web.ProductList
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ProductList_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ProductList_ID);
				}
			}
		}
			
	private void ShowInfo(int ProductList_ID)
	{
		ZhangWei.BLL.ProductList bll=new ZhangWei.BLL.ProductList();
		ZhangWei.Model.ProductList model=bll.GetModel(ProductList_ID);
		this.txtProductClass_ID.Text=model.ProductClass_ID.ToString();
		this.lblProductList_ID.Text=model.ProductList_ID.ToString();
		this.txtName.Text=model.Name;
		this.txtEmployee_ID.Text=model.Employee_ID.ToString();
		this.txtCreateDate.Text=model.CreateDate.ToString();
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtProductClass_ID.Text))
			{
				strErr+="ProductClass_ID格式错误！\\n";	
			}
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
			int ProductClass_ID=int.Parse(this.txtProductClass_ID.Text);
			int ProductList_ID=int.Parse(this.lblProductList_ID.Text);
			string Name=this.txtName.Text;
			int Employee_ID=int.Parse(this.txtEmployee_ID.Text);
			DateTime CreateDate=DateTime.Parse(this.txtCreateDate.Text);
			string Remark=this.txtRemark.Text;


			ZhangWei.Model.ProductList model=new ZhangWei.Model.ProductList();
			model.ProductClass_ID=ProductClass_ID;
			model.ProductList_ID=ProductList_ID;
			model.Name=Name;
			model.Employee_ID=Employee_ID;
			model.CreateDate=CreateDate;
			model.Remark=Remark;

			ZhangWei.BLL.ProductList bll=new ZhangWei.BLL.ProductList();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
