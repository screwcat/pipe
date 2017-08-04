using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:BuyOrder
    /// </summary>
    public partial class BuyOrder
    {
        public BuyOrder()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.BuyOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BuyOrder(");
            strSql.Append("WriteDate,InsureDate,EndDate,Dept_ID,Supplier_ID,Employee_ID,Produced)");
            strSql.Append(" values (");
            strSql.Append("@WriteDate,@InsureDate,@EndDate,@Dept_ID,@Supplier_ID,@Employee_ID,@Produced)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WriteDate", SqlDbType.DateTime),
					new SqlParameter("@InsureDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Supplier_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@Produced", SqlDbType.Bit,1)};
            parameters[0].Value = model.WriteDate;
            parameters[1].Value = model.InsureDate;
            parameters[2].Value = model.EndDate;
            parameters[3].Value = model.Dept_ID;
            parameters[4].Value = model.Supplier_ID;
            parameters[5].Value = model.Employee_ID;
            parameters[6].Value = model.Produced;

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
        public bool Update(ZhangWei.Model.BuyOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BuyOrder set ");
            strSql.Append("WriteDate=@WriteDate,");
            strSql.Append("InsureDate=@InsureDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("Dept_ID=@Dept_ID,");
            strSql.Append("Supplier_ID=@Supplier_ID,");
            strSql.Append("Employee_ID=@Employee_ID,");
            strSql.Append("Produced=@Produced");
            strSql.Append(" where BuyOrder_ID=@BuyOrder_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@WriteDate", SqlDbType.DateTime),
					new SqlParameter("@InsureDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Supplier_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@Produced", SqlDbType.Bit,1),
					new SqlParameter("@BuyOrder_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.WriteDate;
            parameters[1].Value = model.InsureDate;
            parameters[2].Value = model.EndDate;
            parameters[3].Value = model.Dept_ID;
            parameters[4].Value = model.Supplier_ID;
            parameters[5].Value = model.Employee_ID;
            parameters[6].Value = model.Produced;
            parameters[7].Value = model.BuyOrder_ID;

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
        public bool Delete(int BuyOrder_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BuyOrder ");
            strSql.Append(" where BuyOrder_ID=@BuyOrder_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BuyOrder_ID", SqlDbType.Int,4)
};
            parameters[0].Value = BuyOrder_ID;

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
        public bool DeleteList(string BuyOrder_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BuyOrder ");
            strSql.Append(" where BuyOrder_ID in (" + BuyOrder_IDlist + ")  ");
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
        public ZhangWei.Model.BuyOrder GetModel(int BuyOrder_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BuyOrder_ID,WriteDate,InsureDate,EndDate,Dept_ID,Supplier_ID,Employee_ID,Produced from BuyOrder ");
            strSql.Append(" where BuyOrder_ID=@BuyOrder_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BuyOrder_ID", SqlDbType.Int,4)
};
            parameters[0].Value = BuyOrder_ID;

            ZhangWei.Model.BuyOrder model = new ZhangWei.Model.BuyOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BuyOrder_ID"] != null && ds.Tables[0].Rows[0]["BuyOrder_ID"].ToString() != "")
                {
                    model.BuyOrder_ID = int.Parse(ds.Tables[0].Rows[0]["BuyOrder_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WriteDate"] != null && ds.Tables[0].Rows[0]["WriteDate"].ToString() != "")
                {
                    model.WriteDate = DateTime.Parse(ds.Tables[0].Rows[0]["WriteDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InsureDate"] != null && ds.Tables[0].Rows[0]["InsureDate"].ToString() != "")
                {
                    model.InsureDate = DateTime.Parse(ds.Tables[0].Rows[0]["InsureDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndDate"] != null && ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dept_ID"] != null && ds.Tables[0].Rows[0]["Dept_ID"].ToString() != "")
                {
                    model.Dept_ID = int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Supplier_ID"] != null && ds.Tables[0].Rows[0]["Supplier_ID"].ToString() != "")
                {
                    model.Supplier_ID = int.Parse(ds.Tables[0].Rows[0]["Supplier_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Employee_ID"] != null && ds.Tables[0].Rows[0]["Employee_ID"].ToString() != "")
                {
                    model.Employee_ID = int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Produced"] != null && ds.Tables[0].Rows[0]["Produced"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Produced"].ToString() == "1") || (ds.Tables[0].Rows[0]["Produced"].ToString().ToLower() == "true"))
                    {
                        model.Produced = true;
                    }
                    else
                    {
                        model.Produced = false;
                    }
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
            strSql.Append("select BuyOrder_ID,WriteDate,InsureDate,EndDate,Dept_ID,Supplier_ID,Employee_ID,Produced ");
            strSql.Append(" FROM BuyOrder ");
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
            strSql.Append(" BuyOrder_ID,WriteDate,InsureDate,EndDate,Dept_ID,Supplier_ID,Employee_ID,Produced ");
            strSql.Append(" FROM BuyOrder ");
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
            parameters[0].Value = "v_BuyOrderList";
            parameters[1].Value = "BuyOrder_ID";
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

