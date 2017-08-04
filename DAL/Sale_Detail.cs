using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:Sale_Detail
    /// </summary>
    public partial class Sale_Detail
    {
        public Sale_Detail()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZhangWei.Model.Sale_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sale_Detail(");
            strSql.Append("Sale_ID,Product_ID,SaleOrder_ID,Quantity,Price,Discount)");
            strSql.Append(" values (");
            strSql.Append("@Sale_ID,@Product_ID,@SaleOrder_ID,@Quantity,@Price,@Discount)");
            SqlParameter[] parameters = {
					new SqlParameter("@Sale_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@SaleOrder_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Discount", SqlDbType.Int,4)};
            parameters[0].Value = model.Sale_ID;
            parameters[1].Value = model.Product_ID;
            parameters[2].Value = model.SaleOrder_ID;
            parameters[3].Value = model.Quantity;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Discount;

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
        public bool Update(ZhangWei.Model.Sale_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale_Detail set ");
            strSql.Append("Sale_ID=@Sale_ID,");
            strSql.Append("Product_ID=@Product_ID,");
            strSql.Append("SaleOrder_ID=@SaleOrder_ID,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Price=@Price,");
            strSql.Append("Discount=@Discount");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sale_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@SaleOrder_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Discount", SqlDbType.Int,4)};
            parameters[0].Value = model.Sale_ID;
            parameters[1].Value = model.Product_ID;
            parameters[2].Value = model.SaleOrder_ID;
            parameters[3].Value = model.Quantity;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.Discount;

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
            strSql.Append("delete from Sale_Detail ");
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
        public ZhangWei.Model.Sale_Detail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Sale_ID,Product_ID,SaleOrder_ID,Quantity,Price,Discount from Sale_Detail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            ZhangWei.Model.Sale_Detail model = new ZhangWei.Model.Sale_Detail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Sale_ID"] != null && ds.Tables[0].Rows[0]["Sale_ID"].ToString() != "")
                {
                    model.Sale_ID = int.Parse(ds.Tables[0].Rows[0]["Sale_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Product_ID"] != null && ds.Tables[0].Rows[0]["Product_ID"].ToString() != "")
                {
                    model.Product_ID = int.Parse(ds.Tables[0].Rows[0]["Product_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleOrder_ID"] != null && ds.Tables[0].Rows[0]["SaleOrder_ID"].ToString() != "")
                {
                    model.SaleOrder_ID = int.Parse(ds.Tables[0].Rows[0]["SaleOrder_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"] != null && ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = decimal.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Discount"] != null && ds.Tables[0].Rows[0]["Discount"].ToString() != "")
                {
                    model.Discount = int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
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
            strSql.Append("select Sale_ID,Product_ID,SaleOrder_ID,Quantity,Price,Discount ");
            strSql.Append(" FROM Sale_Detail ");
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
            strSql.Append(" Sale_ID,Product_ID,SaleOrder_ID,Quantity,Price,Discount ");
            strSql.Append(" FROM Sale_Detail ");
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
            parameters[0].Value = "SaleDefinite";
            parameters[1].Value = "Sale_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListDetail(Int32 Sale_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.Sale_Detail.Price, dbo.Sale_Detail.Quantity, dbo.Sale_Detail.Product_ID, dbo.Product.Name ");
            strSql.Append("FROM dbo.Sale_Detail INNER JOIN ");
            strSql.Append("dbo.Product ON dbo.Sale_Detail.Product_ID = dbo.Product.Product_ID ");
            strSql.Append("where Sale_ID = " + Sale_ID);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 销售单明细
        /// </summary>
        /// <param name="Sale_ID"></param>
        /// <returns></returns>
        public DataSet GetDetailAll(Int32 Sale_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.Sale.Sale_ID, dbo.Sale_Detail.Price, dbo.Product.Name, dbo.ProductUnit.Name AS UnitName, dbo.Sale_Detail.Quantity, ");
            strSql.Append("dbo.ProductSpec.Name AS SpecName, dbo.Sale_Detail.Product_ID ");
            strSql.Append("FROM dbo.Product INNER JOIN ");
            strSql.Append("dbo.Sale INNER JOIN ");
            strSql.Append("dbo.Sale_Detail ON dbo.Sale.Sale_ID = dbo.Sale_Detail.Sale_ID ON dbo.Product.Product_ID = dbo.Sale_Detail.Product_ID INNER JOIN ");
            strSql.Append("dbo.ProductUnit ON dbo.Product.ProductUnit_ID = dbo.ProductUnit.ProductUnit_ID INNER JOIN ");
            strSql.Append("dbo.ProductSpec ON dbo.Product.ProductSpec_ID = dbo.ProductSpec.ProductSpec_ID ");
            strSql.Append("where dbo.Sale_Detail.Sale_ID = " + Sale_ID);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 销售明细表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetSaleDefinite(string BeginDate, string EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SaleDefinite where saledate between '" + BeginDate + "' and '" + Convert.ToDateTime(EndDate).AddDays(1) +"'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 生成销售汇总（按单品汇总）
        /// </summary>
        /// <param name="BeginDate">统计开始时间</param>
        /// <param name="EndDate">统计终止时间</param>
        /// <returns>DataSet</returns>
        public DataSet GetSaleGather(string BeginDate, string EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Product_ID,ProductName,SpecName,UnitName,shortname,Name,sum(Quantity) as totalQty from SaleDefinite where saledate between '" + BeginDate + "' and '" + Convert.ToDateTime(EndDate).AddDays(1) + "' group by Product_ID,ProductName,SpecName,UnitName,shortname,Name");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 生成销售汇总（按单号汇总）
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetGatherByList(string BeginDate, string EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Sale_ID, TradeNo,StoreAdd,count(TradeNo) as TrCount, sum(Price*Quantity) as totalPrice,GatheringWay,Account,Address,SaleDate ");
            strSql.Append("from dbo.SaleDefinite where SaleDate between '" + BeginDate + "' and '" + Convert.ToDateTime(EndDate).AddDays(1) + "' group by Sale_ID, TradeNo,StoreAdd,Address,SaleDate,GatheringWay,Account");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public bool DeleteSaleDtl(Int32 Sale_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sale_Detail ");
            strSql.Append(" where Sale_ID =" + Sale_ID);
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

        #endregion  Method
    }
}

