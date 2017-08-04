using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web
{
    public partial class mainFrame : UserPageBass
    {
        BLL.HasChecked bl_hc = new ZhangWei.BLL.HasChecked();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = UserModel.Name;
            DateTime dt = DateTime.Now;
            DateTime LastCheckTime = bl_hc.GetModel(bl_hc.GetMaxId() - 1).Month;
            if (dt.Month>LastCheckTime.Month)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "confirmCheck();", true);
            }
            //else
            //{
            //    Response.Write("用户 " + UserModel.Name + " 登录成功，抚顺金牛地暖工程有限公司");
            //}
            
        }
    }
}
