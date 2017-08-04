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
namespace ZhangWei.Web.Employee
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
					int Employee_ID=(Convert.ToInt32(strid));
					ShowInfo(Employee_ID);
				}
			}
		}
		
	private void ShowInfo(int Employee_ID)
	{
		ZhangWei.BLL.Employee bll=new ZhangWei.BLL.Employee();
		ZhangWei.Model.Employee model=bll.GetModel(Employee_ID);
		this.lblEmployee_ID.Text=model.Employee_ID.ToString();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblName.Text=model.Name;
		this.lblDuty.Text=model.Duty;
		this.lblGender.Text=model.Gender;
		this.lblBirthDate.Text=model.BirthDate.ToString();
		this.lblHireDate.Text=model.HireDate.ToString();
		this.lblMatureDate.Text=model.MatureDate.ToString();
		this.lblIdentityCard.Text=model.IdentityCard;
		this.lblAddress.Text=model.Address;
		this.lblPhone.Text=model.Phone;
		this.lblEmail.Text=model.Email;

	}


    }
}
