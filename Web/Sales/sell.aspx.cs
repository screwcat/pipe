using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web.Sales
{
    public partial class sell : UserPageBass
    {
        DataSet Dept = new BLL.Dept().GetAllList();
        DataSet Employee = new BLL.Employee().GetAllList();
        DataSet StoreHouse = new BLL.StoreHouse().GetAllList();
        DataSet Customer = new BLL.Customer().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Dept;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Dept_ID";
                DropDownList1.DataBind();
                DropDownList2.DataSource = Employee;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "Employee_ID";
                DropDownList2.DataBind();
                DropDownList3.DataSource = StoreHouse;
                DropDownList3.DataTextField = "Address";
                DropDownList3.DataValueField = "StoreHouse_ID";
                DropDownList3.DataBind();
                DropDownList5.DataSource = Customer;
                DropDownList5.DataTextField = "Name";
                DropDownList5.DataValueField = "Customer_ID";
                DropDownList5.DataBind();
                DropDownList2.SelectedValue = UserModel.Employee_ID.ToString();
            }
            Button4.Attributes.Add("onclick", "return false;");
            Button2.Attributes.Add("onclick", "return confirm(\"确认销售信息吗？\")");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value == "")
            {
                Maticsoft.Common.MessageBox.Show(this, "请添加商品");
                return;
            }
            else
            {
                Model.Sale ml_sale = new ZhangWei.Model.Sale();
                ml_sale.SaleDate = Convert.ToDateTime(TextBox1.Text);
                ml_sale.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                ml_sale.Customer = Convert.ToInt32(DropDownList5.SelectedValue);//客户
                ml_sale.Employee_ID = Convert.ToInt32(DropDownList2.SelectedValue);
                ml_sale.Account = DropDownList4.SelectedValue;
                ml_sale.Address = TextBox2.Text;
                ml_sale.GatheringWay = DropDownList6.SelectedValue;
                ml_sale.StoreHouse_ID = Convert.ToInt32(DropDownList3.SelectedValue);
                ml_sale.TradeNo = GetTradeNo();
                Int32 sale_id = new BLL.Sale().Add(ml_sale);
                string Ids = HiddenField1.Value.Replace(" ", "").Replace("\r\n", "");
                string Qtys = HiddenField2.Value.Replace(" ", "").Replace("\r\n", "");
                string Prices = HiddenField3.Value.Replace(" ", "").Replace("\r\n", "");
                string[] ArrIds = Ids.Split(new char[] { '|' });
                string[] ArrQty = Qtys.Split(new char[] { '|' });
                string[] ArrPri = Prices.Split(new char[] { '|' });
                for (int i = 0; i < ArrIds.Length - 1; i++)
                {
                    Model.Sale_Detail ml_sa = new ZhangWei.Model.Sale_Detail();
                    BLL.Sale_Detail bl_sd = new ZhangWei.BLL.Sale_Detail();
                    ml_sa.Sale_ID = sale_id;
                    ml_sa.Product_ID = Convert.ToInt32(ArrIds[i]);
                    //ml_sa.SaleOrder_ID = 0;
                    ml_sa.Quantity = Convert.ToDecimal(ArrQty[i]);
                    ml_sa.Price = Convert.ToDecimal(ArrPri[i]);
                    Model.StockPile ml_sp = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]),Convert.ToInt32(DropDownList3.SelectedValue));
                    BLL.StockPile bl_sp = new ZhangWei.BLL.StockPile();
                    if (ml_sp == null)
                    {
                        Model.Product ml_pr = new BLL.Product().GetModel(Convert.ToInt32(ArrIds[i]));
                        ml_sp = new ZhangWei.Model.StockPile();
                        ml_sp.Product_ID = Convert.ToInt32(ArrIds[i]);
                        ml_sp.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                        ml_sp.FirstEnterDate = DateTime.Now;
                        ml_sp.LastLeaveDate = DateTime.Now;
                        ml_sp.Price = Convert.ToDecimal(ArrPri[i]);
                        ml_sp.Quantity = 0;
                        ml_sp.StoreHouse_ID = Convert.ToInt32(DropDownList3.SelectedValue);
                        ml_sp.Quantity -= Convert.ToDecimal(ArrQty[i]);
                        bl_sp.Add(ml_sp);
                    }
                    else
                    {
                        ml_sp.Quantity -= Convert.ToDecimal(ArrQty[i]);
                        ml_sp.LastLeaveDate = DateTime.Now;
                        bl_sp.Update(ml_sp);
                    }
                    bl_sd.Add(ml_sa);
                }
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功，单号为：" + ml_sale.TradeNo, "/Sales/SaleReport.aspx");
            }
        }

        public string GetTradeNo() //生成交易号码
        {
            string sYear = DateTime.Now.Year.ToString();//取年份
            string sMonth = DateTime.Now.Month.ToString();//取月份
            string sDay = DateTime.Now.Day.ToString();//取日期
            if (sMonth.Length == 1) { sMonth = "0" + sMonth; }//小于10的月份变双位
            if (sDay.Length == 1) { sDay = "0" + sDay; }//小于10 的日期变双位
            string sTemp = sYear + sMonth + sDay + "001";//生成当天初始的交易号
            //string TradeNoSQL = "SELECT TradeNo FROM sales order by TradeNo DESC";//查询数据库中最大的交易号的SQL语句
            //MySqlConnection TradeNoconn = new MySqlConnection(connStr);//连接数据库
            //TradeNoconn.Open();//打开数据库
            //MySqlCommand TradeNocmd = new MySqlCommand(TradeNoSQL, TradeNoconn);//执行查询
            //MySqlDataReader reader = TradeNocmd.ExecuteReader();//读取数据
            Model.Sale ml_sale = new BLL.Sale().GetModel(new BLL.Sale().GetMaxId() - 1);
            string MaxCode = ml_sale.TradeNo;
            if (MaxCode.Substring(1, 8) == sTemp.Substring(1, 8))//如果取得数据并且sTemp的前八位等于数据库中取得的数据的前八位
            {
                long dd = Convert.ToInt64(sTemp);
                long cc = Convert.ToInt64(MaxCode);
                dd = cc + 1;//sTemp等于取得的交易号+1,否则sTemp等于初始生成的号码
                sTemp = dd.ToString();
            }
            return sTemp;//返回sTemp
        }
    }
}
