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
namespace ZhangWei.Web.StockPile
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int StockPile_ID=(Convert.ToInt32(strid));
					ShowInfo(StockPile_ID);
				}
			}
		}
		
	private void ShowInfo(int StockPile_ID)
	{
		ZhangWei.BLL.StockPile bll=new ZhangWei.BLL.StockPile();
		ZhangWei.Model.StockPile model=bll.GetModel(StockPile_ID);
		this.lblStockPile_ID.Text=model.StockPile_ID.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblStoreHouse_ID.Text=model.StoreHouse_ID.ToString();
		this.lblProduct_ID.Text=model.Product_ID.ToString();
		this.lblFirstEnterDate.Text=model.FirstEnterDate.ToString();
		this.lblLastLeaveDate.Text=model.LastLeaveDate.ToString();
		this.lblQuantity.Text=model.Quantity.ToString();
		this.lblPrice.Text=model.Price.ToString();

	}


    }
}
