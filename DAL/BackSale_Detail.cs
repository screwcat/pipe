using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:BackSale_Detail
    /// </summary>
    public partial class BackSale_Detail
    {
        public BackSale_Detail()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZhangWei.Model.BackSale_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BackSale_Detail(");
            strSql.Append("BackSale_ID,Product_ID,Quantity,Price)");
            strSql.Append(" values (");
            strSql.Append("@BackSale_ID,@Product_ID,@Quantity,@Price)");
            SqlParameter[] parameters = {
					new SqlParameter("@BackSale_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8)};
            parameters[0].Value = model.BackSale_ID;
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
        public bool Update(ZhangWei.Model.BackSale_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BackSale_Detail set ");
            strSql.Append("BackSale_ID=@BackSale_ID,");
            strSql.Append("Product_ID=@Product_ID,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Price=@Price");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@BackSale_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8)};
            parameters[0].Value = model.BackSale_ID;
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
            strSql.Append("delete from BackSale_Detail ");
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
        public ZhangWei.Model.BackSale_Detail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BackSale_ID,Product_ID,Quantity,Price from BackSale_Detail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            ZhangWei.Model.BackSale_Detail model = new ZhangWei.Model.BackSale_Detail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BackSale_ID"] != null && ds.Tables[0].Rows[0]["BackSale_ID"].ToString() != "")
                {
                    model.BackSale_ID = int.Parse(ds.Tables[0].Rows[0]["BackSale_ID"].ToString());
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
            strSql.Append("select BackSale_ID,Product_ID,Quantity,Price ");
            strSql.Append(" FROM BackSale_Detail ");
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
            strSql.Append(" BackSale_ID,Product_ID,Quantity,Price ");
            strSql.Append(" FROM BackSale_Detail ");
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
            parameters[0].Value = "BackSale_Detail";
            parameters[1].Value = "";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


        /// <summary>
        /// 获取退货明细，不分页
        /// </summary>
        public DataSet GetBackSaleDef(Int32 BackSale_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.BackSale.BackSale_ID, dbo.Product.Product_ID, dbo.Product.Name, dbo.ProductList.Name AS ListName, dbo.Supplier.Name AS SupplierName, ");
            strSql.Append("dbo.ProductUnit.Name AS UnitName, dbo.ProductSpec.Name AS SpecName, dbo.BackSale_Detail.Price, dbo.BackSale_Detail.Quantity ");
            strSql.Append("FROM dbo.Product INNER JOIN ");
            strSql.Append("dbo.Product_Supplier ON dbo.Product.Product_ID = dbo.Product_Supplier.Product_ID INNER JOIN ");
            strSql.Append("dbo.ProductList ON dbo.Product.ProductList_ID = dbo.ProductList.ProductList_ID INNER JOIN ");
            strSql.Append("dbo.ProductSpec ON dbo.Product.ProductSpec_ID = dbo.ProductSpec.ProductSpec_ID INNER JOIN ");
            strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID INNER JOIN ");
            strSql.Append("dbo.Supplier ON dbo.Product_Supplier.Supplier_ID = dbo.Supplier.Supplier_ID RIGHT OUTER JOIN ");
            strSql.Append("dbo.BackSale_Detail ON dbo.Product.Product_ID = dbo.BackSale_Detail.Product_ID LEFT OUTER JOIN ");
            strSql.Append("dbo.BackSale ON dbo.BackSale_Detail.BackSale_ID = dbo.BackSale.BackSale_ID ");
            if (BackSale_ID != 0)
            {
                strSql.Append(" where dbo.BackSale_Detail.BackSale_ID = " + BackSale_ID);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

