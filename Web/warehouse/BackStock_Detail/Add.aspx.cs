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
namespace ZhangWei.Web.BackStock_Detail
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtBackStock_ID.Text))
			{
				strErr+="BackStock_ID格式错误！\\n";	
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
			int BackStock_ID=int.Parse(this.txtBackStock_ID.Text);
			int Product_ID=int.Parse(this.txtProduct_ID.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			decimal Price=decimal.Parse(this.txtPrice.Text);

			ZhangWei.Model.BackStock_Detail model=new ZhangWei.Model.BackStock_Detail();
			model.BackStock_ID=BackStock_ID;
			model.Product_ID=Product_ID;
			model.Quantity=Quantity;
			model.Price=Price;

			ZhangWei.BLL.BackStock_Detail bll=new ZhangWei.BLL.BackStock_Detail();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
