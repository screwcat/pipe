using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace ZhangWei.DAL
{
    public partial class ProductFlowing
    {
        public DataSet GetSale(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.Sale.TradeNo AS ID, dbo.Sale.SaleDate AS Date, dbo.StoreHouse.Address, dbo.Sale_Detail.Product_ID, '销售' AS action, dbo.Sale_Detail.Quantity, dbo.Sale_Detail.Price ");
            strSql.Append("FROM dbo.Sale INNER JOIN ");
            strSql.Append("dbo.Sale_Detail ON dbo.Sale.Sale_ID = dbo.Sale_Detail.Sale_ID INNER JOIN ");
            strSql.Append("dbo.StoreHouse ON dbo.Sale.StoreHouse_ID = dbo.StoreHouse.StoreHouse_ID ");
            strSql.Append("WHERE (dbo.Sale_Detail.Product_ID = @Product_ID) AND (dbo.Sale.SaleDate BETWEEN @StartDate AND @EndDate) ");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
                    new SqlParameter("@StartDate", SqlDbType.DateTime),
                    new SqlParameter("@EndDate", SqlDbType.DateTime)};
            parameters[0].Value = Product_ID;
            parameters[1].Value = StartDate;
            parameters[2].Value = EndDate;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        public DataSet GetBackSale(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.BackSale.BackSale_ID AS ID, dbo.BackSale.BackDate AS Date, dbo.StoreHouse.Address, dbo.BackSale_Detail.Product_ID, '销售退货' AS action, dbo.BackSale_Detail.Quantity, dbo.BackSale_Detail.Price ");
            strSql.Append("FROM dbo.BackSale INNER JOIN ");
            strSql.Append("dbo.BackSale_Detail ON dbo.BackSale.BackSale_ID = dbo.BackSale_Detail.BackSale_ID INNER JOIN ");
            strSql.Append("dbo.StoreHouse ON dbo.BackSale.StoreHouse_ID = dbo.StoreHouse.StoreHouse_ID ");
            strSql.Append("WHERE (dbo.BackSale_Detail.Product_ID = @Product_ID) AND (dbo.BackSale.BackDate BETWEEN @StartDate AND @EndDate) ");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
                    new SqlParameter("@StartDate", SqlDbType.DateTime),
                    new SqlParameter("@EndDate", SqlDbType.DateTime)};
            parameters[0].Value = Product_ID;
            parameters[1].Value = StartDate;
            parameters[2].Value = EndDate;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetEnterStock(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.EnterStock.EnterStock_ID AS ID, dbo.EnterStock.EnterDate AS Date, dbo.StoreHouse.Address, dbo.EnterStock_Detail.Product_ID, '进货' AS action, dbo.EnterStock_Detail.Quantity, ");
            strSql.Append("dbo.EnterStock_Detail.Price ");
            strSql.Append("FROM dbo.EnterStock INNER JOIN ");
            strSql.Append("dbo.EnterStock_Detail ON dbo.EnterStock.EnterStock_ID = dbo.EnterStock_Detail.EnterStock_ID INNER JOIN ");
            strSql.Append("dbo.StoreHouse ON dbo.EnterStock.StoreHouse_ID = dbo.StoreHouse.StoreHouse_ID ");
            strSql.Append("WHERE (dbo.EnterStock_Detail.Product_ID = @Product_ID) AND (dbo.EnterStock.EnterDate BETWEEN @StartDate AND @EndDate) ");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
                    new SqlParameter("@StartDate", SqlDbType.DateTime),
                    new SqlParameter("@EndDate", SqlDbType.DateTime)};
            parameters[0].Value = Product_ID;
            parameters[1].Value = StartDate;
            parameters[2].Value = EndDate;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetBackStock(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.BackStock.BackStock_ID AS ID, dbo.BackStock.BackDate AS Date, dbo.StoreHouse.Address, dbo.BackStock_Detail.Product_ID, '出库' AS action, dbo.BackStock_Detail.Quantity, ");
            strSql.Append("dbo.BackStock_Detail.Price ");
            strSql.Append("FROM dbo.BackStock INNER JOIN ");
            strSql.Append("dbo.BackStock_Detail ON dbo.BackStock.BackStock_ID = dbo.BackStock_Detail.BackStock_ID INNER JOIN ");
            strSql.Append("dbo.StoreHouse ON dbo.BackStock.StoreHouse_ID = dbo.StoreHouse.StoreHouse_ID ");
            strSql.Append("WHERE (dbo.BackStock_Detail.Product_ID = @Product_ID) AND (dbo.BackStock.BackDate BETWEEN @StartDate AND @EndDate) ");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
                    new SqlParameter("@StartDate", SqlDbType.DateTime),
                    new SqlParameter("@EndDate", SqlDbType.DateTime)};
            parameters[0].Value = Product_ID;
            parameters[1].Value = StartDate;
            parameters[2].Value = EndDate;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataTable GetFlowing(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds1 = GetSale(Product_ID, StartDate, EndDate);
            DataSet ds2 = GetBackSale(Product_ID, StartDate, EndDate);
            DataSet ds3 = GetEnterStock(Product_ID, StartDate, EndDate);
            DataSet ds4 = GetBackStock(Product_ID, StartDate, EndDate);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            //dt.Columns.Add("Date", Type.GetType("System.DataTime"));
            dt.Columns.Add("Date", Type.GetType("System.DateTime"));
            dt.Columns.Add("Address", Type.GetType("System.String"));
            dt.Columns.Add("Product_ID", Type.GetType("System.Int32"));
            dt.Columns.Add("action", Type.GetType("System.String"));
            dt.Columns.Add("Quantity", Type.GetType("System.Decimal"));
            dt.Columns.Add("Price", Type.GetType("System.Decimal"));
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = ds1.Tables[0].Rows[i]["ID"];
                    dr["Date"] = ds1.Tables[0].Rows[i]["Date"];
                    dr["Address"] = ds1.Tables[0].Rows[i]["Address"];
                    dr["Product_ID"] = ds1.Tables[0].Rows[i]["Product_ID"];
                    dr["action"] = ds1.Tables[0].Rows[i]["action"];
                    dr["Quantity"] = ds1.Tables[0].Rows[i]["Quantity"];
                    dr["Price"] = ds1.Tables[0].Rows[i]["Price"];
                    dt.Rows.Add(dr);
                }
            }
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = ds2.Tables[0].Rows[i]["ID"];
                    dr["Date"] = ds2.Tables[0].Rows[i]["Date"];
                    dr["Address"] = ds2.Tables[0].Rows[i]["Address"];
                    dr["Product_ID"] = ds2.Tables[0].Rows[i]["Product_ID"];
                    dr["action"] = ds2.Tables[0].Rows[i]["action"];
                    dr["Quantity"] = ds2.Tables[0].Rows[i]["Quantity"];
                    dr["Price"] = ds2.Tables[0].Rows[i]["Price"];
                    dt.Rows.Add(dr);
                }
            }
            if (ds3.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = ds3.Tables[0].Rows[i]["ID"];
                    dr["Date"] = ds3.Tables[0].Rows[i]["Date"];
                    dr["Address"] = ds3.Tables[0].Rows[i]["Address"];
                    dr["Product_ID"] = ds3.Tables[0].Rows[i]["Product_ID"];
                    dr["action"] = ds3.Tables[0].Rows[i]["action"];
                    dr["Quantity"] = ds3.Tables[0].Rows[i]["Quantity"];
                    dr["Price"] = ds3.Tables[0].Rows[i]["Price"];
                    dt.Rows.Add(dr);
                }
            }
            if (ds4.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = ds4.Tables[0].Rows[i]["ID"];
                    dr["Date"] = ds4.Tables[0].Rows[i]["Date"];
                    dr["Address"] = ds4.Tables[0].Rows[i]["Address"];
                    dr["Product_ID"] = ds4.Tables[0].Rows[i]["Product_ID"];
                    dr["action"] = ds4.Tables[0].Rows[i]["action"];
                    dr["Quantity"] = ds4.Tables[0].Rows[i]["Quantity"];
                    dr["Price"] = ds4.Tables[0].Rows[i]["Price"];
                    dt.Rows.Add(dr);
                }
            }
            dt.DefaultView.Sort = "Date";
            return dt;
        }

    }
}
