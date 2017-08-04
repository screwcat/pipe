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
namespace ZhangWei.Web.Dept
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Dept_ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Dept_ID);
				}
			}
		}
			
	private void ShowInfo(int Dept_ID)
	{
		ZhangWei.BLL.Dept bll=new ZhangWei.BLL.Dept();
		ZhangWei.Model.Dept model=bll.GetModel(Dept_ID);
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.txtName.Text=model.Name;
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="Remark不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Dept_ID=int.Parse(this.lblDept_ID.Text);
			string Name=this.txtName.Text;
			string Remark=this.txtRemark.Text;


			ZhangWei.Model.Dept model=new ZhangWei.Model.Dept();
			model.Dept_ID=Dept_ID;
			model.Name=Name;
			model.Remark=Remark;

			ZhangWei.BLL.Dept bll=new ZhangWei.BLL.Dept();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
