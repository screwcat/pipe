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
namespace ZhangWei.Web.EnterStock_Detail
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtEnterStock_ID.Text))
			{
				strErr+="EnterStock_ID格式错误！\\n";	
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
			if(this.txtInvoiceNum.Text.Trim().Length==0)
			{
				strErr+="InvoiceNum不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int EnterStock_ID=int.Parse(this.txtEnterStock_ID.Text);
			int Product_ID=int.Parse(this.txtProduct_ID.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			decimal Price=decimal.Parse(this.txtPrice.Text);
			bool HaveInvoice=this.chkHaveInvoice.Checked;
			string InvoiceNum=this.txtInvoiceNum.Text;

			ZhangWei.Model.EnterStock_Detail model=new ZhangWei.Model.EnterStock_Detail();
			model.EnterStock_ID=EnterStock_ID;
			model.Product_ID=Product_ID;
			model.Quantity=Quantity;
			model.Price=Price;
			model.HaveInvoice=HaveInvoice;
			model.InvoiceNum=InvoiceNum;

			ZhangWei.BLL.EnterStock_Detail bll=new ZhangWei.BLL.EnterStock_Detail();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
