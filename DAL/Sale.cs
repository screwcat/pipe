using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:Sale
    /// </summary>
    public partial class Sale
    {
        public Sale()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Sale_ID", "Sale");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Sale_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sale");
            strSql.Append(" where Sale_ID=@Sale_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Sale_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Sale_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.Sale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sale(");
            strSql.Append("SaleDate,TradeNo,Dept_ID,Employee_ID,StoreHouse_ID,Address,Account,GatheringWay,Customer)");
            strSql.Append(" values (");
            strSql.Append("@SaleDate,@TradeNo,@Dept_ID,@Employee_ID,@StoreHouse_ID,@Address,@Account,@GatheringWay,@Customer)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SaleDate", SqlDbType.DateTime),
					new SqlParameter("@TradeNo", SqlDbType.NChar,11),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Account", SqlDbType.VarChar,250),
					new SqlParameter("@GatheringWay", SqlDbType.VarChar,20),
					new SqlParameter("@Customer", SqlDbType.Int,4)};
            parameters[0].Value = model.SaleDate;
            parameters[1].Value = model.TradeNo;
            parameters[2].Value = model.Dept_ID;
            parameters[3].Value = model.Employee_ID;
            parameters[4].Value = model.StoreHouse_ID;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.Account;
            parameters[7].Value = model.GatheringWay;
            parameters[8].Value = model.Customer;

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
        public bool Update(ZhangWei.Model.Sale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sale set ");
            strSql.Append("SaleDate=@SaleDate,");
            strSql.Append("TradeNo=@TradeNo,");
            strSql.Append("Dept_ID=@Dept_ID,");
            strSql.Append("Employee_ID=@Employee_ID,");
            strSql.Append("StoreHouse_ID=@StoreHouse_ID,");
            strSql.Append("Address=@Address,");
            strSql.Append("Account=@Account,");
            strSql.Append("GatheringWay=@GatheringWay,");
            strSql.Append("Customer=@Customer");
            strSql.Append(" where Sale_ID=@Sale_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@SaleDate", SqlDbType.DateTime),
					new SqlParameter("@TradeNo", SqlDbType.NChar,11),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Account", SqlDbType.VarChar,250),
					new SqlParameter("@GatheringWay", SqlDbType.VarChar,20),
					new SqlParameter("@Customer", SqlDbType.Int,4),
					new SqlParameter("@Sale_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.SaleDate;
            parameters[1].Value = model.TradeNo;
            parameters[2].Value = model.Dept_ID;
            parameters[3].Value = model.Employee_ID;
            parameters[4].Value = model.StoreHouse_ID;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.Account;
            parameters[7].Value = model.GatheringWay;
            parameters[8].Value = model.Customer;
            parameters[9].Value = model.Sale_ID;

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
        public bool Delete(int Sale_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sale ");
            strSql.Append(" where Sale_ID=@Sale_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Sale_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Sale_ID;

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
        public bool DeleteList(string Sale_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sale ");
            strSql.Append(" where Sale_ID in (" + Sale_IDlist + ")  ");
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
        public ZhangWei.Model.Sale GetModel(int Sale_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Sale_ID,SaleDate,TradeNo,Dept_ID,Employee_ID,StoreHouse_ID,Address,Account,GatheringWay,Customer from Sale ");
            strSql.Append(" where Sale_ID=@Sale_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Sale_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Sale_ID;

            ZhangWei.Model.Sale model = new ZhangWei.Model.Sale();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Sale_ID"] != null && ds.Tables[0].Rows[0]["Sale_ID"].ToString() != "")
                {
                    model.Sale_ID = int.Parse(ds.Tables[0].Rows[0]["Sale_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleDate"] != null && ds.Tables[0].Rows[0]["SaleDate"].ToString() != "")
                {
                    model.SaleDate = DateTime.Parse(ds.Tables[0].Rows[0]["SaleDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TradeNo"] != null && ds.Tables[0].Rows[0]["TradeNo"].ToString() != "")
                {
                    model.TradeNo = ds.Tables[0].Rows[0]["TradeNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Dept_ID"] != null && ds.Tables[0].Rows[0]["Dept_ID"].ToString() != "")
                {
                    model.Dept_ID = int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Employee_ID"] != null && ds.Tables[0].Rows[0]["Employee_ID"].ToString() != "")
                {
                    model.Employee_ID = int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreHouse_ID"] != null && ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString() != "")
                {
                    model.StoreHouse_ID = int.Parse(ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Account"] != null && ds.Tables[0].Rows[0]["Account"].ToString() != "")
                {
                    model.Account = ds.Tables[0].Rows[0]["Account"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GatheringWay"] != null && ds.Tables[0].Rows[0]["GatheringWay"].ToString() != "")
                {
                    model.GatheringWay = ds.Tables[0].Rows[0]["GatheringWay"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Customer"] != null && ds.Tables[0].Rows[0]["Customer"].ToString() != "")
                {
                    model.Customer = int.Parse(ds.Tables[0].Rows[0]["Customer"].ToString());
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
            strSql.Append("select Sale_ID,SaleDate,TradeNo,Dept_ID,Employee_ID,StoreHouse_ID,Address,Account,GatheringWay,Customer ");
            strSql.Append(" FROM Sale ");
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
            strSql.Append(" Sale_ID,SaleDate,TradeNo,Dept_ID,Employee_ID,StoreHouse_ID,Address,Account,GatheringWay,Customer ");
            strSql.Append(" FROM Sale ");
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
            parameters[0].Value = "SaleGather";
            parameters[1].Value = "Sale_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        #endregion  Method
    }
}

