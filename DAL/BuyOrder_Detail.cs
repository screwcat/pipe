using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:BuyOrder_Detail
    /// </summary>
    public partial class BuyOrder_Detail
    {
        public BuyOrder_Detail()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZhangWei.Model.BuyOrder_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BuyOrder_Detail(");
            strSql.Append("BuyOrder_ID,Product_ID,Quantity,Price)");
            strSql.Append(" values (");
            strSql.Append("@BuyOrder_ID,@Product_ID,@Quantity,@Price)");
            SqlParameter[] parameters = {
					new SqlParameter("@BuyOrder_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8)};
            parameters[0].Value = model.BuyOrder_ID;
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
        public bool Update(ZhangWei.Model.BuyOrder_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BuyOrder_Detail set ");
            strSql.Append("BuyOrder_ID=@BuyOrder_ID,");
            strSql.Append("Product_ID=@Product_ID,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Price=@Price");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@BuyOrder_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8)};
            parameters[0].Value = model.BuyOrder_ID;
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
            strSql.Append("delete from BuyOrder_Detail ");
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
        public ZhangWei.Model.BuyOrder_Detail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BuyOrder_ID,Product_ID,Quantity,Price from BuyOrder_Detail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            ZhangWei.Model.BuyOrder_Detail model = new ZhangWei.Model.BuyOrder_Detail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BuyOrder_ID"] != null && ds.Tables[0].Rows[0]["BuyOrder_ID"].ToString() != "")
                {
                    model.BuyOrder_ID = int.Parse(ds.Tables[0].Rows[0]["BuyOrder_ID"].ToString());
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
            strSql.Append("select BuyOrder_ID,Product_ID,Quantity,Price ");
            strSql.Append(" FROM BuyOrder_Detail ");
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
            strSql.Append(" BuyOrder_ID,Product_ID,Quantity,Price ");
            strSql.Append(" FROM BuyOrder_Detail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        ///<summary>
        ///分页获取数据列表
        ///</summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
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
            parameters[0].Value = "BuyOrder_Detail";
            parameters[1].Value = "BuyOrder_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

        #endregion  Method
        /// <summary>
        /// 根据进货合同号获取入库详细信息
        /// </summary>
        /// <param name="BuyOrder_ID">进货合同编号</param>
        /// <returns></returns>
        public DataSet GetProDetail(Int32 BuyOrder_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.BuyOrder_Detail.Product_ID, dbo.Product.Name, dbo.BuyOrder_Detail.Price, dbo.Product.Offering_Price, dbo.BuyOrder_Detail.Quantity, dbo.ProductSpec.Name AS  SpecName,");
            strSql.Append("dbo.Supplier.Name AS SupplierName, dbo.ProductUnit.Name AS UnitName ");
            strSql.Append(" FROM dbo.BuyOrder_Detail INNER JOIN ");
            strSql.Append("dbo.Product ON dbo.BuyOrder_Detail.Product_ID = dbo.Product.Product_ID INNER JOIN ");
            strSql.Append("dbo.ProductSpec ON dbo.Product.ProductSpec_ID = dbo.ProductSpec.ProductSpec_ID INNER JOIN ");
            strSql.Append("dbo.Product_Supplier ON dbo.Product.Product_ID = dbo.Product_Supplier.Product_ID INNER JOIN ");
            strSql.Append("dbo.Supplier ON dbo.Product_Supplier.Supplier_ID = dbo.Supplier.Supplier_ID INNER JOIN ");
            strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID ");
            strSql.Append("WHERE (dbo.BuyOrder_Detail.BuyOrder_ID = " + BuyOrder_ID + ")");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

