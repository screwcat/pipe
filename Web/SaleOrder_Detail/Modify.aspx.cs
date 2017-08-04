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
namespace ZhangWei.Web.SaleOrder_Detail
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
			
	private void ShowInfo()
	{
		ZhangWei.BLL.SaleOrder_Detail bll=new ZhangWei.BLL.SaleOrder_Detail();
		ZhangWei.Model.SaleOrder_Detail model=bll.GetModel();
		this.txtSaleOrder_ID.Text=model.SaleOrder_ID.ToString();
		this.txtProduct_ID.Text=model.Product_ID.ToString();
		this.txtQuantity.Text=model.Quantity.ToString();
		this.txtPrice.Text=model.Price.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSaleOrder_ID.Text))
			{
				strErr+="SaleOrder_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProduct_ID.Text))
			{
				strErr+="Product_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQuantity.Text))
			{
				strErr+="Quantity格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtPrice.Text))
			{
				strErr+="Price格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SaleOrder_ID=int.Parse(this.txtSaleOrder_ID.Text);
			int Product_ID=int.Parse(this.txtProduct_ID.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			decimal Price=decimal.Parse(this.txtPrice.Text);


			ZhangWei.Model.SaleOrder_Detail model=new ZhangWei.Model.SaleOrder_Detail();
			model.SaleOrder_ID=SaleOrder_ID;
			model.Product_ID=Product_ID;
			model.Quantity=Quantity;
			model.Price=Price;

			ZhangWei.BLL.SaleOrder_Detail bll=new ZhangWei.BLL.SaleOrder_Detail();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
