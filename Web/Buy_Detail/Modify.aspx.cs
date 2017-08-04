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
namespace ZhangWei.Web.Buy_Detail
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
		ZhangWei.BLL.Buy_Detail bll=new ZhangWei.BLL.Buy_Detail();
		ZhangWei.Model.Buy_Detail model=bll.GetModel();
		this.txtBuy_ID.Text=model.Buy_ID.ToString();
		this.txtProduct_ID.Text=model.Product_ID.ToString();
		this.txtBuyOrder_ID.Text=model.BuyOrder_ID.ToString();
		this.txtQuantity.Text=model.Quantity.ToString();
		this.txtPrice.Text=model.Price.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtBuy_ID.Text))
			{
				strErr+="Buy_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProduct_ID.Text))
			{
				strErr+="Product_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBuyOrder_ID.Text))
			{
				strErr+="BuyOrder_ID格式错误！\\n";	
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
			int Buy_ID=int.Parse(this.txtBuy_ID.Text);
			int Product_ID=int.Parse(this.txtProduct_ID.Text);
			int BuyOrder_ID=int.Parse(this.txtBuyOrder_ID.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			decimal Price=decimal.Parse(this.txtPrice.Text);


			ZhangWei.Model.Buy_Detail model=new ZhangWei.Model.Buy_Detail();
			model.Buy_ID=Buy_ID;
			model.Product_ID=Product_ID;
			model.BuyOrder_ID=BuyOrder_ID;
			model.Quantity=Quantity;
			model.Price=Price;

			ZhangWei.BLL.Buy_Detail bll=new ZhangWei.BLL.Buy_Detail();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
