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
namespace ZhangWei.Web.Sale_Detail
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
		ZhangWei.BLL.Sale_Detail bll=new ZhangWei.BLL.Sale_Detail();
		ZhangWei.Model.Sale_Detail model=bll.GetModel();
		this.txtSale_ID.Text=model.Sale_ID.ToString();
		this.txtProduct_ID.Text=model.Product_ID.ToString();
		this.txtSaleOrder_ID.Text=model.SaleOrder_ID.ToString();
		this.txtQuantity.Text=model.Quantity.ToString();
		this.txtPrice.Text=model.Price.ToString();
		this.txtDiscount.Text=model.Discount.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSale_ID.Text))
			{
				strErr+="Sale_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProduct_ID.Text))
			{
				strErr+="Product_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSaleOrder_ID.Text))
			{
				strErr+="SaleOrder_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQuantity.Text))
			{
				strErr+="Quantity格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtPrice.Text))
			{
				strErr+="Price格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDiscount.Text))
			{
				strErr+="Discount格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Sale_ID=int.Parse(this.txtSale_ID.Text);
			int Product_ID=int.Parse(this.txtProduct_ID.Text);
			int SaleOrder_ID=int.Parse(this.txtSaleOrder_ID.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			decimal Price=decimal.Parse(this.txtPrice.Text);
			int Discount=int.Parse(this.txtDiscount.Text);


			ZhangWei.Model.Sale_Detail model=new ZhangWei.Model.Sale_Detail();
			model.Sale_ID=Sale_ID;
			model.Product_ID=Product_ID;
			model.SaleOrder_ID=SaleOrder_ID;
			model.Quantity=Quantity;
			model.Price=Price;
			model.Discount=Discount;

			ZhangWei.BLL.Sale_Detail bll=new ZhangWei.BLL.Sale_Detail();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
