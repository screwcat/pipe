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
namespace ZhangWei.Web.Product
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
					int Product_ID=(Convert.ToInt32(strid));
					ShowInfo(Product_ID);
				}
			}
		}
		
	private void ShowInfo(int Product_ID)
	{
		ZhangWei.BLL.Product bll=new ZhangWei.BLL.Product();
		ZhangWei.Model.Product model=bll.GetModel(Product_ID);
		this.lblProduct_ID.Text=model.Product_ID.ToString();
		//this.lblCode.Text=model.Code.ToString();
		this.lblProductList_ID.Text= new BLL.ProductList().GetModel(model.ProductList_ID).Name;
		this.lblName.Text=model.Name;
		this.lblshortname.Text=model.shortname;
		this.lblspell.Text=model.spell;
		this.lbls_spell.Text=model.s_spell;
        this.lblProductSpec_ID.Text = new BLL.ProductSpec().GetModel(model.ProductSpec_ID).Name;
        this.lblProductUnit_ID.Text = new BLL.ProductUnit().GetModel(model.ProductUnit_ID).Name;
		this.lblPrice.Text=model.Price.ToString();
		this.lblOffering_Price.Text=model.Offering_Price.ToString();
        this.lblEmployee_ID.Text = new BLL.Employee().GetModel(model.Employee_ID).Name;
		this.lblCreateDate.Text=model.CreateDate.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
