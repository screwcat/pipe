using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Text;
using System.Data;

namespace Maticsoft.Web.Ajax
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Ajax : IHttpHandler, IReadOnlySessionState
    {
        HttpContext myContext;
        public void ProcessRequest(HttpContext context)
        {
            myContext = context;
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["Command"] == null)
            {
                context.Response.Write("pipe【error】:code=-2,msg=没有命令，不知道要做什么");
            }
            else
            {
                switch (context.Request.QueryString["Command"].ToString())
                {
                    case "test":
                        context.Response.Write("sucseesful");
                        break;
                    case "CheckLogin":
                        context.Response.Write(CheckLogin(context.Request.QueryString["UserName"], context.Request.QueryString["PassWord"], Convert.ToInt32(context.Request.QueryString["cookieTime"])));
                        break;
                    case "ExistsUser":
                        context.Response.Write(ExistsUser(context.Request.QueryString["UserName"]));
                        break;
                    case "getSelect":
                        context.Response.Write(getSelect(Convert.ToInt32(context.Request.QueryString["classId"])));
                        break;
                    case "StockToExcel":
                        context.Response.Write(StockToExcel(Convert.ToInt32(context.Request.QueryString["StoreHouse_ID"])));
                        break;
                    case "EnterStockDefToExcel":
                        context.Response.Write(EnterStockDefToExcel(context.Request.QueryString["BeginDate"], context.Request.QueryString["EndDate"]));
                        break;
                    case "EnterStockGatToExcel":
                        context.Response.Write(EnterStockGatToExcel(context.Request.QueryString["BeginDate"], context.Request.QueryString["EndDate"], context.Request.QueryString["according"]));
                        break;
                    case "SaleDefToExcel":
                        context.Response.Write(SaleDefToExcel(context.Request.QueryString["BeginDate"], context.Request.QueryString["EndDate"]));
                        break;
                    case "SaleGatToExcel":
                        context.Response.Write(SaleGatToExcel(context.Request.QueryString["BeginDate"], context.Request.QueryString["EndDate"], context.Request.QueryString["according"]));
                        break;
                    case "DataBackup":
                        context.Response.Write(DataBackup());
                        break;
                    default:
                        context.Response.Write("pipe【error】:code=-1,msg=有命令，但是目前处理不了这个命令");
                        
                        break;
                }
            }
        }
        private string CheckLogin(string UserName, string PassWord, Int32 cookieTime)
        {
            ZhangWei.Model.Employee user = new ZhangWei.BLL.Employee().GetModelByUN(UserName);
            if (user==null)
            {
                return "NoUser";
            }
            else
            {
                if (user.PassWord==PassWord)
                {
                    Common.Utils.SetCookie("UserId", cookieTime, user.Employee_ID.ToString());
                    Common.Utils.SetCookie("UserName", cookieTime, user.UserName);
                    Common.Utils.SetCookie("PassWord", cookieTime, user.PassWord.ToString());
                    return "OK";
                }
                else
                {
                    return "BadPW";
                }
            }
        }

        private string ExistsUser(string UserName)
        {
            if (new ZhangWei.BLL.Employee().Exists(UserName))
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }

        private string getSelect(Int32 classId)
        {
            return new ZhangWei.BLL.ProductList().getSelect(classId);
        }

        private string StockToExcel(Int32 StoreHouse_ID)
        {
            DataSet ds = new ZhangWei.BLL.StockPile().CheckStock(StoreHouse_ID);
            string ToExcel = new LTP.Common.DataToExcel().OutputExcel(ds.Tables[0], "库存盘点 " + DateTime.Now.ToString(), HttpContext.Current.Server.MapPath("/ExcelFiles/"), "库存盘点");
            ZhangWei.BLL.HasChecked bl_hc = new ZhangWei.BLL.HasChecked();
            ZhangWei.Model.HasChecked ml_hc = bl_hc.GetModel(bl_hc.GetMaxId() - 1);
            DateTime dt = DateTime.Now;
            DateTime LastCheckTime = ml_hc.Month;
            if (dt.Month > LastCheckTime.Month)
            {
                ml_hc.Month = dt;
                bl_hc.Add(ml_hc);
            }
            else
            {
                ml_hc.Month = dt;
                bl_hc.Update(ml_hc);
            }
            return ToExcel;
        }

        private string EnterStockDefToExcel(string BeginDate, string EndDate)
        {
            DataSet ds = new ZhangWei.BLL.EnterStock().EnterStockDefinite(BeginDate, EndDate);
            string ToExcel = new LTP.Common.DataToExcel().OutputExcel(ds.Tables[0], "入库明细 " + BeginDate + "—" + EndDate, HttpContext.Current.Server.MapPath("/ExcelFiles/"), "入库明细");
            return ToExcel;
        }

        private string EnterStockGatToExcel(string BeginDate, string EndDate, string according)
        {
            if (according == "1")
            {
                DataSet ds = new ZhangWei.BLL.EnterStock().EnterStockGather(BeginDate, EndDate);
                string ToExcel = new LTP.Common.DataToExcel().OutputExcel(ds.Tables[0], "入库汇总（按品种） " + BeginDate + "—" + EndDate, HttpContext.Current.Server.MapPath("/ExcelFiles/"), "入库汇总（按品种）");
                return ToExcel;
            }
            else
            {
                DataSet ds = new ZhangWei.BLL.EnterStock().GetGatherByList(BeginDate, EndDate);
                string ToExcel = new LTP.Common.DataToExcel().OutputExcel(ds.Tables[0], "入库汇总（按单号） " + BeginDate + "—" + EndDate, HttpContext.Current.Server.MapPath("/ExcelFiles/"), "入库汇总（按单号）");
                return ToExcel;
            }
        }

        private string SaleDefToExcel(string BeginDate, string EndDate)
        {
            DataSet ds = new ZhangWei.BLL.Sale_Detail().GetSaleDefinite(BeginDate, EndDate);
            string ToExcel = new LTP.Common.DataToExcel().OutputExcel(ds.Tables[0], "销售明细 " + BeginDate + "—" + EndDate, HttpContext.Current.Server.MapPath("/ExcelFiles/"), "销售明细");
            return ToExcel;
        }

        private string SaleGatToExcel(string BeginDate, string EndDate, string according)
        {
            if (according=="1")
            {
                DataSet ds = new ZhangWei.BLL.Sale_Detail().GetSaleGather(BeginDate, EndDate);
                string ToExcel = new LTP.Common.DataToExcel().OutputExcel(ds.Tables[0], "销售汇总（按品种） " + BeginDate + "—" + EndDate, HttpContext.Current.Server.MapPath("/ExcelFiles/"), "销售汇总（按品种）");
                return ToExcel;
            }
            else
            {
                DataSet ds = new ZhangWei.BLL.Sale_Detail().GetGatherByList(BeginDate, EndDate);
                string ToExcel = new LTP.Common.DataToExcel().OutputExcel(ds.Tables[0], "销售汇总（按单号） " + BeginDate + "—" + EndDate, HttpContext.Current.Server.MapPath("/ExcelFiles/"), "销售汇总（按单号）");
                return ToExcel;
            }
            
        }

        private string DataBackup()
        {
            string time = string.Format("{0:yyyy-MM-dd@HH：mm：ss}", DateTime.Now);
            StringBuilder Sqlstr = new StringBuilder();
            //Sqlstr.Append("backup database pipe to disk = 'D:\\DataBackup\\" + time + ".bak'");
            Sqlstr.Append("backup database pipe to disk = '" + HttpContext.Current.Server.MapPath("\\DataBackup\\" + time + ".bak") + "'");
            Int32 BackupNum = 0;
            try
            {
                BackupNum = new Maticsoft.Common.DataManage().DataBackup(Sqlstr.ToString());
            }
            catch (Exception)
            {
                
                //throw;
            }
            if (BackupNum == -1)
            {
                return "success";
            }
            else
            {
                return "faild";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}
