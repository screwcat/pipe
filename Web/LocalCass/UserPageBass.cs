using System;
using System.Collections.Generic;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Maticsoft.Web.LocalCass
{
    public class UserPageBass : System.Web.UI.Page
    {
        public ZhangWei.Model.Employee UserModel = new ZhangWei.Model.Employee();
        public string UserId = string.Empty;
        protected override void OnPreLoad(EventArgs e)
        {
            string UserName = GetCookieValue("UserName");
            string PassWord = GetCookieValue("PassWord");
            UserId = GetCookieValue("UserId");

            if (UserName == "CookieNonexistence" || PassWord == "CookieNonexistence" || UserId == "CookieNonexistence")
            {
                //用户信息为空，转到登陆页
                Response.Write("<script>top.location.href=\"/login.aspx\"</script>");
                Response.End();
            }
            else
            {
                Regex reg = new Regex("^[A-Za-z0-9]+$");
                if (reg.IsMatch(PassWord))
                {
                    ChecPersonalkUser(UserName, PassWord);
                }
                else
                {
                    //用户信息为空，转到登陆页
                    Response.Write("<script>top.location.href=\"/login.aspx\"</script>");
                    Response.End();
                }
            }
            if (Convert.ToDateTime(GetTxt())<DateTime.Now)
            {
                Response.Write("<script>top.location.href=\"/terminate.aspx\"</script>");
                Response.End();
            }

            //if (Session["user"] == null)
            //{
            //    UserCookie = Request.Cookies["CookieUser"];
            //    if (UserCookie == null )
            //    {
            //        Response.Write("<script>top.location.href=\"/login.aspx\"</script>");
            //    }
            //    else
            //    {
            //        UserModel = new ZhangWei.BLL.Employee().GetModel(Convert.ToInt32(UserCookie.Values["UserId"]));
            //        Session["user"] = UserModel;
            //    }
            //}
            //else
            //{
            //    UserModel = (ZhangWei.Model.Employee)Session["user"];
            //}
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

        /// <summary>
        /// 验证个人用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">用户密码</param>
        private void ChecPersonalkUser(string userName, string userPwd)
        {
            //ZhangWei.BLL.Employee bll = new ZhangWei.BLL.Employee();
            //ZhangWei.Model.Employee model = new ZhangWei.Model.Employee();
            ZhangWei.Model.Employee user = new ZhangWei.BLL.Employee().GetModelByUN(userName);
            if (user == null)
            {
                Response.Write("<script>top.location.href=\"/login.aspx\"</script>");
            }
            else
            {
                if (user.PassWord == userPwd)
                {
                    UserModel = user;
                }
                else
                {
                    Response.Write("<script>top.location.href=\"/login.aspx\"</script>");
                }
            }
        }


        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    Response.Buffer = true;
        //    Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
        //    Response.Expires = 0;
        //    Response.CacheControl = "no-cache";
        //    Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        //}
        public string GetTxt()
        {
            string path = Server.MapPath("/Txt/EffTime.txt");
            StreamReader objReader = new StreamReader(path, UnicodeEncoding.GetEncoding("GB2312"));
            string message = "";
            string sLine = "";
            while (sLine != null)
            {
                message += sLine;
                sLine = objReader.ReadLine();
            }
            objReader.Close();
            message = Maticsoft.Common.DEncrypt.DEncrypt.Decrypt(message, "bnbnbn");
            return message;
        }
    }
}
