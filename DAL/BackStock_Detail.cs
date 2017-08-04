using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:BackStock_Detail
    /// </summary>
    public partial class BackStock_Detail
    {
        public BackStock_Detail()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZhangWei.Model.BackStock_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BackStock_Detail(");
            strSql.Append("BackStock_ID,Product_ID,Quantity,Price)");
            strSql.Append(" values (");
            strSql.Append("@BackStock_ID,@Product_ID,@Quantity,@Price)");
            SqlParameter[] parameters = {
					new SqlParameter("@BackStock_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8)};
            parameters[0].Value = model.BackStock_ID;
            parameters[1].Value = model.Product_ID;
            parameters[2].Value = model.Quantity;
            parameters[3].Value = model.Price;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.BackStock_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BackStock_Detail set ");
            strSql.Append("BackStock_ID=@BackStock_ID,");
            strSql.Append("Product_ID=@Product_ID,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Price=@Price");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@BackStock_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8)};
            parameters[0].Value = model.BackStock_ID;
            parameters[1].Value = model.Product_ID;
            parameters[2].Value = model.Quantity;
            parameters[3].Value = model.Price;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BackStock_Detail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

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
        /// 得到一个对象实体
        /// </summary>
        public ZhangWei.Model.BackStock_Detail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BackStock_ID,Product_ID,Quantity,Price from BackStock_Detail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            ZhangWei.Model.BackStock_Detail model = new ZhangWei.Model.BackStock_Detail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BackStock_ID"] != null && ds.Tables[0].Rows[0]["BackStock_ID"].ToString() != "")
                {
                    model.BackStock_ID = int.Parse(ds.Tables[0].Rows[0]["BackStock_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Product_ID"] != null && ds.Tables[0].Rows[0]["Product_ID"].ToString() != "")
                {
                    model.Product_ID = int.Parse(ds.Tables[0].Rows[0]["Product_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"] != null && ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = decimal.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
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
            strSql.Append("select BackStock_ID,Product_ID,Quantity,Price ");
            strSql.Append(" FROM BackStock_Detail ");
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
            strSql.Append(" BackStock_ID,Product_ID,Quantity,Price ");
            strSql.Append(" FROM BackStock_Detail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
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
            parameters[0].Value = "BackStock_Detail";
            parameters[1].Value = "";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 获取出库单详细信息
        /// </summary>
        /// <param name="BackStock_ID"></param>
        /// <returns></returns>
        public DataSet GetBackStockDtl(Int32 BackStock_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.BackStock.BackStock_ID, dbo.BackStock_Detail.Quantity, dbo.BackStock_Detail.Price, dbo.Employee.Name AS EmployeeName, ");
            strSql.Append("dbo.ProductList.Name, dbo.Product.Name AS ProductName, dbo.Product.shortname, dbo.ProductSpec.Name AS SpecName, ");
            strSql.Append("dbo.ProductUnit.Name AS UnitName, dbo.Supplier.Name AS SupplierName, dbo.StoreHouse.Address,dbo.BackStock.BackDate ");
            strSql.Append("FROM dbo.Supplier INNER JOIN ");
            strSql.Append("dbo.Product_Supplier ON dbo.Supplier.Supplier_ID = dbo.Product_Supplier.Supplier_ID INNER JOIN ");
            strSql.Append("dbo.Product ON dbo.Product_Supplier.Product_ID = dbo.Product.Product_ID INNER JOIN ");
            strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID INNER JOIN ");
            strSql.Append("dbo.ProductSpec ON dbo.Product.ProductSpec_ID = dbo.ProductSpec.ProductSpec_ID INNER JOIN ");
            strSql.Append("dbo.ProductList ON dbo.Product.ProductList_ID = dbo.ProductList.ProductList_ID INNER JOIN ");
            strSql.Append("dbo.Employee INNER JOIN ");
            strSql.Append("dbo.BackStock INNER JOIN ");
            strSql.Append("dbo.BackStock_Detail ON dbo.BackStock.BackStock_ID = dbo.BackStock_Detail.BackStock_ID ON ");
            strSql.Append("dbo.Employee.Employee_ID = dbo.BackStock.Employee_ID ON dbo.Product.Product_ID = dbo.BackStock_Detail.Product_ID INNER JOIN ");
            strSql.Append("dbo.StoreHouse ON dbo.BackStock.StoreHouse_ID = dbo.StoreHouse.StoreHouse_ID ");
            strSql.Append("WHERE dbo.BackStock_Detail.BackStock_ID=@BackStock_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BackStock_ID", SqlDbType.Int)
					};
            parameters[0].Value = BackStock_ID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion  Method
    }
}

