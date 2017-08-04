﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:Product
    /// </summary>
    public partial class Product
    {
        public Product()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Product_ID", "Product");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Product_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Product");
            strSql.Append(" where Product_ID=@Product_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Product_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Product(");
            strSql.Append("ProductList_ID,Name,shortname,spell,s_spell,ProductSpec_ID,ProductUnit_ID,Price,Offering_Price,Employee_ID,CreateDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ProductList_ID,@Name,@shortname,@spell,@s_spell,@ProductSpec_ID,@ProductUnit_ID,@Price,@Offering_Price,@Employee_ID,@CreateDate,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductList_ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@shortname", SqlDbType.VarChar,50),
					new SqlParameter("@spell", SqlDbType.VarChar,50),
					new SqlParameter("@s_spell", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSpec_ID", SqlDbType.Int,4),
					new SqlParameter("@ProductUnit_ID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Offering_Price", SqlDbType.Money,8),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250)};
            parameters[0].Value = model.ProductList_ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.shortname;
            parameters[3].Value = model.spell;
            parameters[4].Value = model.s_spell;
            parameters[5].Value = model.ProductSpec_ID;
            parameters[6].Value = model.ProductUnit_ID;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.Offering_Price;
            parameters[9].Value = model.Employee_ID;
            parameters[10].Value = model.CreateDate;
            parameters[11].Value = model.Remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Product set ");
            strSql.Append("ProductList_ID=@ProductList_ID,");
            strSql.Append("Name=@Name,");
            strSql.Append("shortname=@shortname,");
            strSql.Append("spell=@spell,");
            strSql.Append("s_spell=@s_spell,");
            strSql.Append("ProductSpec_ID=@ProductSpec_ID,");
            strSql.Append("ProductUnit_ID=@ProductUnit_ID,");
            strSql.Append("Price=@Price,");
            strSql.Append("Offering_Price=@Offering_Price,");
            strSql.Append("Employee_ID=@Employee_ID,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Product_ID=@Product_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductList_ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@shortname", SqlDbType.VarChar,50),
					new SqlParameter("@spell", SqlDbType.VarChar,50),
					new SqlParameter("@s_spell", SqlDbType.VarChar,50),
					new SqlParameter("@ProductSpec_ID", SqlDbType.Int,4),
					new SqlParameter("@ProductUnit_ID", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Offering_Price", SqlDbType.Money,8),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250),
					new SqlParameter("@Product_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProductList_ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.shortname;
            parameters[3].Value = model.spell;
            parameters[4].Value = model.s_spell;
            parameters[5].Value = model.ProductSpec_ID;
            parameters[6].Value = model.ProductUnit_ID;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.Offering_Price;
            parameters[9].Value = model.Employee_ID;
            parameters[10].Value = model.CreateDate;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.Product_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Product_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where Product_ID=@Product_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Product_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Product_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
            strSql.Append(" where Product_ID in (" + Product_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhangWei.Model.Product GetModel(int Product_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Product_ID,ProductList_ID,Name,shortname,spell,s_spell,ProductSpec_ID,ProductUnit_ID,Price,Offering_Price,Employee_ID,CreateDate,Remark from Product ");
            strSql.Append(" where Product_ID=@Product_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Product_ID;

            ZhangWei.Model.Product model = new ZhangWei.Model.Product();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Product_ID"] != null && ds.Tables[0].Rows[0]["Product_ID"].ToString() != "")
                {
                    model.Product_ID = int.Parse(ds.Tables[0].Rows[0]["Product_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductList_ID"] != null && ds.Tables[0].Rows[0]["ProductList_ID"].ToString() != "")
                {
                    model.ProductList_ID = int.Parse(ds.Tables[0].Rows[0]["ProductList_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["shortname"] != null && ds.Tables[0].Rows[0]["shortname"].ToString() != "")
                {
                    model.shortname = ds.Tables[0].Rows[0]["shortname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["spell"] != null && ds.Tables[0].Rows[0]["spell"].ToString() != "")
                {
                    model.spell = ds.Tables[0].Rows[0]["spell"].ToString();
                }
                if (ds.Tables[0].Rows[0]["s_spell"] != null && ds.Tables[0].Rows[0]["s_spell"].ToString() != "")
                {
                    model.s_spell = ds.Tables[0].Rows[0]["s_spell"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductSpec_ID"] != null && ds.Tables[0].Rows[0]["ProductSpec_ID"].ToString() != "")
                {
                    model.ProductSpec_ID = int.Parse(ds.Tables[0].Rows[0]["ProductSpec_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductUnit_ID"] != null && ds.Tables[0].Rows[0]["ProductUnit_ID"].ToString() != "")
                {
                    model.ProductUnit_ID = int.Parse(ds.Tables[0].Rows[0]["ProductUnit_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Offering_Price"] != null && ds.Tables[0].Rows[0]["Offering_Price"].ToString() != "")
                {
                    model.Offering_Price = decimal.Parse(ds.Tables[0].Rows[0]["Offering_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Employee_ID"] != null && ds.Tables[0].Rows[0]["Employee_ID"].ToString() != "")
                {
                    model.Employee_ID = int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Product_ID,ProductList_ID,Name,shortname,spell,s_spell,ProductSpec_ID,ProductUnit_ID,Price,Offering_Price,Employee_ID,CreateDate,Remark ");
            strSql.Append(" FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Product_ID,ProductList_ID,Name,shortname,spell,s_spell,ProductSpec_ID,ProductUnit_ID,Price,Offering_Price,Employee_ID,CreateDate,Remark ");
            strSql.Append(" FROM Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Product";
			parameters[1].Value = "Product_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 1;
			parameters[5].Value = 1;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}


        /// <summary>
        /// 获取商品详细列表，不能分页
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.Product.Product_ID, dbo.ProductList.Name, dbo.Product.spell, dbo.Product.s_spell, dbo.ProductSpec.Name AS SpecName, dbo.ProductUnit.Name AS tUnitName, ");
            strSql.Append("dbo.Product.Price, dbo.Product.Offering_Price, dbo.Product.Remark, dbo.Product.Name AS ProductName, dbo.Product.shortname ");
            strSql.Append("FROM dbo.Product INNER JOIN ");
            strSql.Append("dbo.ProductList ON dbo.Product.ProductList_ID = dbo.ProductList.ProductList_ID INNER JOIN ");
            strSql.Append("dbo.ProductSpec ON dbo.Product.ProductSpec_ID = dbo.ProductSpec.ProductSpec_ID INNER JOIN ");
            strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID ");
            strSql.Append("where " + strWhere);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件字符串，获取商品详细列表，能分页的
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProListPage(int PageSize, int PageIndex, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select count(*) as Total from dbo.Product ");
            if (PageIndex == 1)
            {
                strSql.Append("SELECT TOP (" + PageSize + ") dbo.Product.Product_ID, dbo.ProductList.Name AS ProductListName, dbo.Product.s_spell, dbo.ProductSpec.Name AS SpecName, dbo.ProductUnit.Name AS UnitName, ");
                strSql.Append("dbo.Product.Price, dbo.Product.Offering_Price, dbo.Product.Remark, dbo.Product.Name AS ProductName, dbo.Product.shortname, dbo.Product.spell, dbo.Supplier.Name AS SupplierName ");
                strSql.Append("FROM dbo.Supplier INNER JOIN ");
                strSql.Append("dbo.Product_Supplier ON dbo.Supplier.Supplier_ID = dbo.Product_Supplier.Supplier_ID INNER JOIN ");
                strSql.Append("dbo.ProductSpec INNER JOIN ");
                strSql.Append("dbo.Product ON dbo.ProductSpec.ProductSpec_ID = dbo.Product.ProductSpec_ID ON dbo.Product_Supplier.Product_ID = dbo.Product.Product_ID INNER JOIN ");
                strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID INNER JOIN ");
                strSql.Append("dbo.ProductList ON dbo.Product.ProductList_ID = dbo.ProductList.ProductList_ID ");
                if (strWhere != "")
                {
                    strSql.Append("where " + strWhere);
                    strSql1.Append("where " + strWhere);
                }
                strSql.Append(" ORDER BY dbo.Product.Product_ID DESC ");
            }
            else
            {
                strSql.Append("SELECT TOP (" + PageSize + ") dbo.Product.Product_ID, dbo.ProductList.Name AS ProductListName, dbo.Product.s_spell, dbo.ProductSpec.Name AS SpecName, dbo.ProductUnit.Name AS UnitName, ");
                strSql.Append("dbo.Product.Price, dbo.Product.Offering_Price, dbo.Product.Remark, dbo.Product.Name AS ProductName, dbo.Product.shortname, dbo.Product.spell, dbo.Supplier.Name AS SupplierName ");
                strSql.Append("FROM dbo.Supplier INNER JOIN ");
                strSql.Append("dbo.Product_Supplier ON dbo.Supplier.Supplier_ID = dbo.Product_Supplier.Supplier_ID INNER JOIN ");
                strSql.Append("dbo.ProductSpec INNER JOIN ");
                strSql.Append("dbo.Product ON dbo.ProductSpec.ProductSpec_ID = dbo.Product.ProductSpec_ID ON dbo.Product_Supplier.Product_ID = dbo.Product.Product_ID INNER JOIN ");
                strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID INNER JOIN ");
                strSql.Append("dbo.ProductList ON dbo.Product.ProductList_ID = dbo.ProductList.ProductList_ID ");
                strSql.Append("where dbo.Product.Product_ID < (select min ([Product_ID]) from (select top " + PageSize * (PageIndex - 1) + " [Product_ID] from [Product] order by Product_ID desc) as tblTmp) ");
                if (strWhere != "")
                {
                    strSql.Append("and " + strWhere);
                    strSql1.Append("where " + strWhere);
                }
                strSql.Append(" order by dbo.Product.Product_ID desc ");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataSet ds1 = DbHelperSQL.Query(strSql1.ToString());
            DataTable table = new DataTable();
            table.Columns.Add("Total");
            DataRow dr = table.NewRow();
            dr["Total"] = ds1.Tables[0].Rows[0]["Total"];
            table.Rows.Add(dr);
            ds.Tables.Add(table);
            return ds;
        }


        /// <summary>
        /// 根据条件字符串，获取商品详细列表，能分页的，带库存的
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProListPageAll(int PageSize, int PageIndex, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select count(*) as Total from dbo.Product ");
            if (PageIndex == 1)
            {
                strSql.Append("SELECT TOP (" + PageSize + ") dbo.Product.Product_ID, dbo.ProductList.Name AS ProductListName, dbo.Product.s_spell, dbo.ProductSpec.Name AS SpecName, dbo.ProductUnit.Name AS UnitName, ");
                strSql.Append("dbo.Product.Price, dbo.Product.Offering_Price, dbo.Product.Remark, dbo.Product.Name AS ProductName, dbo.Product.shortname, dbo.Product.spell, dbo.Product.CreateDate, dbo.Product.Remark, dbo.StockPile.Quantity, dbo.StoreHouse.Address, dbo.Supplier.Name AS SupplierName ");
                strSql.Append("FROM dbo.Supplier INNER JOIN ");
                strSql.Append("dbo.Product_Supplier ON dbo.Supplier.Supplier_ID = dbo.Product_Supplier.Supplier_ID INNER JOIN ");
                strSql.Append("dbo.ProductSpec INNER JOIN ");
                strSql.Append("dbo.Product ON dbo.ProductSpec.ProductSpec_ID = dbo.Product.ProductSpec_ID ON dbo.Product_Supplier.Product_ID = dbo.Product.Product_ID INNER JOIN ");
                strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID INNER JOIN ");
                strSql.Append("dbo.ProductList ON dbo.Product.ProductList_ID = dbo.ProductList.ProductList_ID LEFT OUTER JOIN ");
                strSql.Append("dbo.StockPile ON dbo.Product.Product_ID = dbo.StockPile.Product_ID LEFT OUTER JOIN ");
                strSql.Append("dbo.StoreHouse ON dbo.StockPile.StoreHouse_ID = dbo.StoreHouse.StoreHouse_ID ");
                if (strWhere != "")
                {
                    strSql.Append("where " + strWhere);
                    strSql1.Append("where " + strWhere);
                }
                strSql.Append(" ORDER BY dbo.Product.Product_ID DESC ");
            }
            else
            {
                strSql.Append("SELECT TOP (" + PageSize + ") dbo.Product.Product_ID, dbo.ProductList.Name AS ProductListName, dbo.Product.s_spell, dbo.ProductSpec.Name AS SpecName, dbo.ProductUnit.Name AS UnitName, ");
                strSql.Append("dbo.Product.Price, dbo.Product.Offering_Price, dbo.Product.Remark, dbo.Product.Name AS ProductName, dbo.Product.shortname, dbo.Product.spell, dbo.Product.CreateDate, dbo.Product.Remark, dbo.StockPile.Quantity, dbo.StoreHouse.Address, dbo.Supplier.Name AS SupplierName ");
                strSql.Append("FROM dbo.Supplier INNER JOIN ");
                strSql.Append("dbo.Product_Supplier ON dbo.Supplier.Supplier_ID = dbo.Product_Supplier.Supplier_ID INNER JOIN ");
                strSql.Append("dbo.ProductSpec INNER JOIN ");
                strSql.Append("dbo.Product ON dbo.ProductSpec.ProductSpec_ID = dbo.Product.ProductSpec_ID ON dbo.Product_Supplier.Product_ID = dbo.Product.Product_ID INNER JOIN ");
                strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID INNER JOIN ");
                strSql.Append("dbo.ProductList ON dbo.Product.ProductList_ID = dbo.ProductList.ProductList_ID LEFT OUTER JOIN ");
                strSql.Append("dbo.StockPile ON dbo.Product.Product_ID = dbo.StockPile.Product_ID LEFT OUTER JOIN ");
                strSql.Append("dbo.StoreHouse ON dbo.StockPile.StoreHouse_ID = dbo.StoreHouse.StoreHouse_ID ");
                strSql.Append("where dbo.Product.Product_ID < (select min ([Product_ID]) from (select top " + PageSize * (PageIndex - 1) + " [Product_ID] from [Product] order by Product_ID desc) as tblTmp) ");
                if (strWhere != "")
                {
                    strSql.Append("and " + strWhere);
                    strSql1.Append("where " + strWhere);
                }
                strSql.Append(" order by dbo.Product.Product_ID desc ");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            DataSet ds1 = DbHelperSQL.Query(strSql1.ToString());
            DataTable table = new DataTable();
            table.Columns.Add("Total");
            DataRow dr = table.NewRow();
            dr["Total"] = ds1.Tables[0].Rows[0]["Total"];
            table.Rows.Add(dr);
            ds.Tables.Add(table);
            return ds;
        }

        /// <summary>
        /// 从视图获取分页数据，不带库存的
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListFromView(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "ProInfoList";
            parameters[1].Value = "Product_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

        /// <summary>
        /// 从视图获取分页数据，带库存的
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetStockFromView(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "GetProDetail";
            parameters[1].Value = "Product_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }
		#endregion  Method
	}
}
