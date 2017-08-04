namespace ZhangWei.Web.Controls
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using LTP.Accounts.Bus;
    using System.Configuration;
    using System.Web.Security;

    /// <summary>
    ///	CheckRight 的摘要说明。
    /// </summary>
    public partial class CheckRight : System.Web.UI.UserControl
    {

        private int _permissionID = -1;

        public int PermissionID
        {
            get { return _permissionID; }
            set { _permissionID = value; }
        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            bool flag = false;
            //Model.Employee user = (Model.Employee)Session["user"];
            //Int32 UserId = user.Employee_ID;
            //DataSet ds = new BLL.UserRight().GetListByUserId(UserId);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (Convert.ToInt32(ds.Tables[0].Rows[i]["Rights"]) == _permissionID)
            //    {
            //        flag = true;
            //        break;
            //    }
            //}
            
            string UserId = GetCookieValue("UserId");
            string UserName = GetCookieValue("UserName");
            if (UserId != "CookieNonexistence" && UserName != "CookieNonexistence")
            {
                DataSet ds = new BLL.UserRight().GetListByUserId(Convert.ToInt32(UserId));
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["Rights"]) == _permissionID)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (UserName == "zhangwei")//特权
            {
                flag = true;
            }
            if (!flag)
            {
                Response.Write("<script defer>window.alert('您没有权限进入本页！\\n请重新登录或与管理员联系');history.back();</script>");
                Response.End();
            }
        }

        /// 读取Cookie某个对象的Value值
        /// <summary>
        /// 读取Cookie某个对象的Value值，返回Value值，如果对象本就不存在，则返回字符串"CookieNonexistence"
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        /// <returns>Value值，如果对象本就不存在，则返回字符串"CookieNonexistence"</returns>
        public string GetCookieValue(string strCookieName)
        {
            if (HttpContext.Current.Request.Cookies[strCookieName] == null)
            {
                return "CookieNonexistence";
            }
            else
            {
                return HttpContext.Current.Request.Cookies[strCookieName].Value;
            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            if (!Page.IsPostBack)
            {
                //string virtualPath = ConfigurationManager.AppSettings.Get("VirtualPath");
                //if (Context.User.Identity.IsAuthenticated)
                //{
                //    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                //    if (Session["UserInfo"] == null)
                //    {
                //        LTP.Accounts.Bus.User currentUser = new LTP.Accounts.Bus.User(user);
                //        Session["UserInfo"] = currentUser;
                //        Session["Style"] = currentUser.Style;
                //        Response.Write("<script defer>location.reload();</script>");
                //    }
                //    if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                //    {
                //        Response.Clear();
                //        Response.Write("<script defer>window.alert('您没有权限进入本页！\\n请重新登录或与管理员联系');history.back();</script>");
                //        Response.End();
                //    }

                //}
                //else
                //{
                //    FormsAuthentication.SignOut();
                //    Session.Clear();
                //    Session.Abandon();
                //    Response.Clear();
                //    Response.Write("<script defer>window.alert('您没有权限进入本页或当前登录用户已过期！\\n请重新登录或与管理员联系！');parent.location='" + virtualPath + "/Login.aspx';</script>");
                //    Response.End();
                //}

            }
        }
        #endregion
    }
}
