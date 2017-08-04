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
using Maticsoft.Web.LocalCass;
namespace ZhangWei.Web.EUser
{
    public partial class Show : UserPageBass
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int UserId=(Convert.ToInt32(strid));
					ShowInfo(UserId);
				}
			}
		}
		
	private void ShowInfo(int UserId)
	{
		ZhangWei.BLL.EUser bll=new ZhangWei.BLL.EUser();
		ZhangWei.Model.EUser model=bll.GetModel(UserId);
		this.lblUserId.Text=model.UserId.ToString();
		this.lblUserName.Text=model.UserName;
		this.lblPassWord.Text=model.PassWord;
		this.lblEmail.Text=model.Email;
		this.lblName.Text=model.Name;
		this.lblSex.Text=model.Sex;
		this.lblAge.Text=model.Age.ToString();
		this.lblID_Card.Text=model.ID_Card;
		this.lblPhone.Text=model.Phone;
		this.lblMobilPhone.Text=model.MobilPhone;
		this.lblAddress.Text=model.Address;
		this.lblPostalcode.Text=model.Postalcode;
		this.lblWork.Text=model.Work;
		this.lblIncome.Text=model.Income.ToString();
		this.lblIntegral.Text=model.Integral.ToString();
		this.lblCreateTime.Text=model.CreateTime.ToString();
		this.lblLaseLogin.Text=model.LaseLogin.ToString();

	}


    }
}
