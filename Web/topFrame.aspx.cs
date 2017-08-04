using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;
using Maticsoft.Web.LocalCass;

namespace Maticsoft.Web
{
    public partial class leftFrame : UserPageBass
    {
        private static ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
        private static string ChineseNumber = "〇一二三四五六七八九";
        public const string CelestialStem = "甲乙丙丁戊己庚辛壬癸";
        public const string TerrestrialBranch = "子丑寅卯辰巳午未申酉戌亥";
        public static readonly string[] ChineseDayName = new string[] {
            "初一","初二","初三","初四","初五","初六","初七","初八","初九","初十",
            "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十",
            "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十"};
        public static readonly string[] ChineseMonthName = new string[] { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二" };
        public static readonly string[] week = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString() + " "+getWeek(Convert.ToInt32(DateTime.Now.DayOfWeek));
            Label2.Text = GetChineseDate(DateTime.Now);
            Label3.Text = UserModel.Name;
            if (!IsPostBack)
            {
                Button1.Attributes.Add("onclick", "return confirm(\"确定退出当前用户吗？\")");
            }
        }
        private void Transform(DateTime dt)
        {

        }
        /// <summary>
        /// 获取一个公历日期对应的完整的农历日期
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历日期</returns>
        public string GetChineseDate(DateTime time)
        {
            string strY = GetYear(time);
            string strM = GetMonth(time);
            string strD = GetDay(time);
            string strSB = GetStemBranch(time);
            string strDate = strY + "(" + strSB + ")年 " + strM + "月 " + strD;
            return strDate;
        }
        /// <summary>
        /// 获取一个公历日期的农历干支纪年
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历干支纪年</returns>
        public string GetStemBranch(DateTime time)
        {
            int sexagenaryYear = calendar.GetSexagenaryYear(time);
            string stemBranch = CelestialStem.Substring(sexagenaryYear % 10 - 1, 1) + TerrestrialBranch.Substring(sexagenaryYear % 12 - 1, 1);
            return stemBranch;
        }

        /// <summary>
        /// 获取一个公历日期的农历年份
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历年份</returns>
        public string GetYear(DateTime time)
        {
            StringBuilder sb = new StringBuilder();
            int year = calendar.GetYear(time);
            int d;
            do
            {
                d = year % 10;
                sb.Insert(0, ChineseNumber[d]);
                year = year / 10;
            } while (year > 0);
            return sb.ToString();
        }


        /// <summary>
        /// 获取一个公历日期的农历月份
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历月份</returns>
        public string GetMonth(DateTime time)
        {
            int month = calendar.GetMonth(time);
            int year = calendar.GetYear(time);
            int leap = 0;

            //正月不可能闰月
            for (int i = 3; i <= month; i++)
            {
                if (calendar.IsLeapMonth(year, i))
                {
                    leap = i;
                    break; //一年中最多有一个闰月
                }

            }
            if (leap > 0) month--;
            return (leap == month + 1 ? "闰" : "") + ChineseMonthName[month - 1];
        }


        /// <summary>
        /// 获取一个公历日期的农历日
        /// </summary>
        /// <param name="time">一个公历日期</param>
        /// <returns>农历日</returns>
        public string GetDay(DateTime time)
        {
            return ChineseDayName[calendar.GetDayOfMonth(time) - 1];
        }
        public string getWeek(int day)
        {
            //day = 1;
            return week[day];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //设置cookie值为无效,这样如果下面的删除cookie方法无效,也可以保证cookie值是无效的
            SetCookie("UserId", 0, "CookieNonexistence");
            SetCookie("UserName", 0, "CookieNonexistence");
            SetCookie("PassWord", 0, "CookieNonexistence");
            //删除cookie,希望不要失败.(也有可能是缓存造成的页面显示效果不一致)
            DelCookie("UserId");
            DelCookie("UserName");
            DelCookie("PassWord");
            Response.Write("<script>top.location.href=\"/login.aspx\"</script>");
            Response.End();
        }

        /// 创建COOKIE对象并赋Value值
        /// <summary>
        /// 创建COOKIE对象并赋Value值，修改COOKIE的Value值也用此方法，因为对COOKIE修改必须重新设Expires
        /// </summary>
        /// <param name="strCookieName">COOKIE对象名</param>
        /// <param name="iExpires">COOKIE对象有效时间（秒数），1表示永久有效，0和负数都表示不设有效时间，大于等于2表示具体有效秒数，31536000秒=1年=(60*60*24*365)</param>
        /// <param name="strValue">COOKIE对象Value值</param>
        public void SetCookie(string strCookieName, int iExpires, string strValue)
        {
            HttpCookie objCookie = new HttpCookie(strCookieName.Trim());
            objCookie.Value = strValue.Trim();
            if (iExpires > 0)
            {
                if (iExpires == 1)
                {
                    objCookie.Expires = DateTime.MaxValue;
                }
                else
                {
                    objCookie.Expires = DateTime.Now.AddSeconds(iExpires);
                }
            }
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// 删除COOKIE对象
        /// <summary>
        /// 删除COOKIE对象
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        public void DelCookie(string strCookieName)
        {
            HttpCookie objCookie = new HttpCookie(strCookieName.Trim());
            objCookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

    }
}
