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
namespace ZhangWei.Web.StockPile
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int StockPile_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(StockPile_ID);
				}
			}
		}
			
	private void ShowInfo(int StockPile_ID)
	{
		ZhangWei.BLL.StockPile bll=new ZhangWei.BLL.StockPile();
		ZhangWei.Model.StockPile model=bll.GetModel(StockPile_ID);
		this.lblStockPile_ID.Text=model.StockPile_ID.ToString();
		this.txtDept_ID.Text=model.Dept_ID.ToString();
		this.txtStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.txtProduct_ID.Text=model.Product_ID.ToString();
		this.txtFirstEnterDate.Text=model.FirstEnterDate.ToString();
		this.txtLastLeaveDate.Text=model.LastLeaveDate.ToString();
		this.txtQuantity.Text=model.Quantity.ToString();
		this.txtPrice.Text=model.Price.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtDept_ID.Text))
			{
				strErr+="Dept_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStoreHouse_ID.Text))
			{
				strErr+="StoreHouse_ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProduct_ID.Text))
			{
				strErr+="Product_ID格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtFirstEnterDate.Text))
			{
				strErr+="FirstEnterDate格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtLastLeaveDate.Text))
			{
				strErr+="LastLeaveDate格式错误！\\n";	
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
			int StockPile_ID=int.Parse(this.lblStockPile_ID.Text);
			int Dept_ID=int.Parse(this.txtDept_ID.Text);
			int StoreHouse_ID=int.Parse(this.txtStoreHouse_ID.Text);
			int Product_ID=int.Parse(this.txtProduct_ID.Text);
			DateTime FirstEnterDate=DateTime.Parse(this.txtFirstEnterDate.Text);
			DateTime LastLeaveDate=DateTime.Parse(this.txtLastLeaveDate.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			decimal Price=decimal.Parse(this.txtPrice.Text);


			ZhangWei.Model.StockPile model=new ZhangWei.Model.StockPile();
			model.StockPile_ID=StockPile_ID;
			model.Dept_ID=Dept_ID;
			model.StoreHouse_ID=StoreHouse_ID;
			model.Product_ID=Product_ID;
			model.FirstEnterDate=FirstEnterDate;
			model.LastLeaveDate=LastLeaveDate;
			model.Quantity=Quantity;
			model.Price=Price;

			ZhangWei.BLL.StockPile bll=new ZhangWei.BLL.StockPile();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
