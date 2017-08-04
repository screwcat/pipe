using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:EnterStock_Detail
    /// </summary>
    public partial class EnterStock_Detail
    {
        public EnterStock_Detail()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZhangWei.Model.EnterStock_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EnterStock_Detail(");
            strSql.Append("EnterStock_ID,Product_ID,Quantity,Price,HaveInvoice,InvoiceNum)");
            strSql.Append(" values (");
            strSql.Append("@EnterStock_ID,@Product_ID,@Quantity,@Price,@HaveInvoice,@InvoiceNum)");
            SqlParameter[] parameters = {
					new SqlParameter("@EnterStock_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@HaveInvoice", SqlDbType.Bit,1),
					new SqlParameter("@InvoiceNum", SqlDbType.VarChar,30)};
            parameters[0].Value = model.EnterStock_ID;
            parameters[1].Value = model.Product_ID;
            parameters[2].Value = model.Quantity;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.HaveInvoice;
            parameters[5].Value = model.InvoiceNum;

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
        public bool Update(ZhangWei.Model.EnterStock_Detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EnterStock_Detail set ");
            strSql.Append("EnterStock_ID=@EnterStock_ID,");
            strSql.Append("Product_ID=@Product_ID,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Price=@Price,");
            strSql.Append("HaveInvoice=@HaveInvoice,");
            strSql.Append("InvoiceNum=@InvoiceNum");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@EnterStock_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@HaveInvoice", SqlDbType.Bit,1),
					new SqlParameter("@InvoiceNum", SqlDbType.VarChar,30)};
            parameters[0].Value = model.EnterStock_ID;
            parameters[1].Value = model.Product_ID;
            parameters[2].Value = model.Quantity;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.HaveInvoice;
            parameters[5].Value = model.InvoiceNum;

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
            strSql.Append("delete from EnterStock_Detail ");
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
        public ZhangWei.Model.EnterStock_Detail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EnterStock_ID,Product_ID,Quantity,Price,HaveInvoice,InvoiceNum from EnterStock_Detail ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            ZhangWei.Model.EnterStock_Detail model = new ZhangWei.Model.EnterStock_Detail();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EnterStock_ID"] != null && ds.Tables[0].Rows[0]["EnterStock_ID"].ToString() != "")
                {
                    model.EnterStock_ID = int.Parse(ds.Tables[0].Rows[0]["EnterStock_ID"].ToString());
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
                if (ds.Tables[0].Rows[0]["HaveInvoice"] != null && ds.Tables[0].Rows[0]["HaveInvoice"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HaveInvoice"].ToString() == "1") || (ds.Tables[0].Rows[0]["HaveInvoice"].ToString().ToLower() == "true"))
                    {
                        model.HaveInvoice = true;
                    }
                    else
                    {
                        model.HaveInvoice = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["InvoiceNum"] != null && ds.Tables[0].Rows[0]["InvoiceNum"].ToString() != "")
                {
                    model.InvoiceNum = ds.Tables[0].Rows[0]["InvoiceNum"].ToString();
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
            strSql.Append("select EnterStock_ID,Product_ID,Quantity,Price,HaveInvoice,InvoiceNum ");
            strSql.Append(" FROM EnterStock_Detail ");
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
            strSql.Append(" EnterStock_ID,Product_ID,Quantity,Price,HaveInvoice,InvoiceNum ");
            strSql.Append(" FROM EnterStock_Detail ");
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
            parameters[0].Value = "EnterStock_Detail";
            parameters[1].Value = "";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 获取带商品资料的入库详单
        /// </summary>
        /// <param name="EnterStock_ID"></param>
        /// <returns></returns>
        public DataSet GetEnterStock(Int32 EnterStock_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.EnterStock_Detail.EnterStock_ID, dbo.EnterStock_Detail.Quantity, dbo.EnterStock_Detail.Price, dbo.Product.Name, dbo.Supplier.Name AS SupplierName, ");
            strSql.Append("dbo.ProductUnit.Name AS UnitName, dbo.EnterStock_Detail.Product_ID, dbo.ProductSpec.Name AS SpecName ");
            strSql.Append("FROM dbo.ProductUnit INNER JOIN ");
            strSql.Append("dbo.Product ON dbo.ProductUnit.ProductUnit_ID = dbo.Product.ProductUnit_ID INNER JOIN ");
            strSql.Append("dbo.Supplier INNER JOIN ");
            strSql.Append("dbo.Product_Supplier ON dbo.Supplier.Supplier_ID = dbo.Product_Supplier.Supplier_ID ON dbo.Product.Product_ID = dbo.Product_Supplier.Product_ID INNER JOIN ");
            strSql.Append("dbo.ProductSpec ON dbo.Product.ProductSpec_ID = dbo.ProductSpec.ProductSpec_ID RIGHT OUTER JOIN ");
            strSql.Append("dbo.EnterStock_Detail ON dbo.Product.Product_ID = dbo.EnterStock_Detail.Product_ID ");
            strSql.Append("WHERE EnterStock_ID = @EnterStock_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@EnterStock_ID", SqlDbType.Int,4)};
            parameters[0].Value = EnterStock_ID;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除指指定单号的详单
        /// </summary>
        /// <param name="Sale_ID"></param>
        /// <returns></returns>
        public bool DeleteEnterStock(Int32 EnterStock_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EnterStock_Detail ");
            strSql.Append(" where EnterStock_ID = @EnterStock_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@EnterStock_ID", SqlDbType.Int,4)};
            parameters[0].Value = EnterStock_ID;
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

        #endregion  Method
    }
}

