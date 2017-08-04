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
namespace ZhangWei.Web.Product_Supplier
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Product_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Product_ID);
				}
			}
		}
			
	private void ShowInfo(int Product_ID)
	{
		ZhangWei.BLL.Product_Supplier bll=new ZhangWei.BLL.Product_Supplier();
		ZhangWei.Model.Product_Supplier model=bll.GetModel(Product_ID);
		this.lblProduct_ID.Text=model.Product_ID.ToString();
		this.txtSupplier_ID.Text=model.Supplier_ID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSupplier_ID.Text))
			{
				strErr+="Supplier_ID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Product_ID=int.Parse(this.lblProduct_ID.Text);
			int Supplier_ID=int.Parse(this.txtSupplier_ID.Text);


			ZhangWei.Model.Product_Supplier model=new ZhangWei.Model.Product_Supplier();
			model.Product_ID=Product_ID;
			model.Supplier_ID=Supplier_ID;

			ZhangWei.BLL.Product_Supplier bll=new ZhangWei.BLL.Product_Supplier();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
