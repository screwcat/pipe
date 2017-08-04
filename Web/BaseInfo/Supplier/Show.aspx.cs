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
namespace ZhangWei.Web.Supplier
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
					int Supplier_ID=(Convert.ToInt32(strid));
					ShowInfo(Supplier_ID);
				}
			}
		}
		
	private void ShowInfo(int Supplier_ID)
	{
		ZhangWei.BLL.Supplier bll=new ZhangWei.BLL.Supplier();
		ZhangWei.Model.Supplier model=bll.GetModel(Supplier_ID);
		this.lblSupplier_ID.Text=model.Supplier_ID.ToString();
		this.lblName.Text=model.Name;
		this.lblAddress.Text=model.Address;
		this.lblPhone.Text=model.Phone;
		this.lblFax.Text=model.Fax;
		this.lblPostalCode.Text=model.PostalCode;
		this.lblConstactPerson.Text=model.ConstactPerson;

	}


    }
}
