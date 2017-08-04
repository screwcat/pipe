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
namespace ZhangWei.Web.sysdiagrams
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
					int diagram_id=(Convert.ToInt32(strid));
					ShowInfo(diagram_id);
				}
			}
		}
		
	private void ShowInfo(int diagram_id)
	{
		ZhangWei.BLL.sysdiagrams bll=new ZhangWei.BLL.sysdiagrams();
		ZhangWei.Model.sysdiagrams model=bll.GetModel(diagram_id);
		this.lblname.Text=model.name;
		this.lblprincipal_id.Text=model.principal_id.ToString();
		this.lbldiagram_id.Text=model.diagram_id.ToString();
		this.lblversion.Text=model.version.ToString();
		this.lbldefinition.Text=model.definition.ToString();

	}


    }
}
