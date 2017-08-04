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
namespace ZhangWei.Web.Dept_Supplier
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
		ZhangWei.BLL.Dept_Supplier bll=new ZhangWei.BLL.Dept_Supplier();
		ZhangWei.Model.Dept_Supplier model=bll.GetModel();
		this.lblDept_ID.Text=model.Dept_ID.ToString();
		this.lblSupplier_ID.Text=model.Supplier_ID.ToString();

	}


    }
}
