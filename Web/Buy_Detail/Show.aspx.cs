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
namespace ZhangWei.Web.Buy_Detail
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblBuy_ID.Text=model.Buy_ID.ToString();
		this.lblProduct_ID.Text=model.Product_ID.ToString();
		this.lblBuyOrder_ID.Text=model.BuyOrder_ID.ToString();
		this.lblQuantity.Text=model.Quantity.ToString();
		this.lblPrice.Text=model.Price.ToString();

	}


    }
}
