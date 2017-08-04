using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:EnterStock
	/// </summary>
	public partial class EnterStock
	{
		public EnterStock()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.EnterStock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EnterStock(");
			strSql.Append("EnterDate,Dept_ID,StoreHouse_ID,Employee_ID)");
			strSql.Append(" values (");
			strSql.Append("@EnterDate,@Dept_ID,@StoreHouse_ID,@Employee_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.EnterDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.StoreHouse_ID;
			parameters[3].Value = model.Employee_ID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(ZhangWei.Model.EnterStock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EnterStock set ");
			strSql.Append("EnterDate=@EnterDate,");
			strSql.Append("Dept_ID=@Dept_ID,");
			strSql.Append("StoreHouse_ID=@StoreHouse_ID,");
			strSql.Append("Employee_ID=@Employee_ID");
			strSql.Append(" where EnterStock_ID=@EnterStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@EnterStock_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.EnterDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.StoreHouse_ID;
			parameters[3].Value = model.Employee_ID;
			parameters[4].Value = model.EnterStock_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int EnterStock_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EnterStock ");
			strSql.Append(" where EnterStock_ID=@EnterStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterStock_ID", SqlDbType.Int,4)
};
			parameters[0].Value = EnterStock_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string EnterStock_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EnterStock ");
			strSql.Append(" where EnterStock_ID in ("+EnterStock_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ZhangWei.Model.EnterStock GetModel(int EnterStock_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EnterStock_ID,EnterDate,Dept_ID,StoreHouse_ID,Employee_ID from EnterStock ");
			strSql.Append(" where EnterStock_ID=@EnterStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@EnterStock_ID", SqlDbType.Int,4)
};
			parameters[0].Value = EnterStock_ID;

			ZhangWei.Model.EnterStock model=new ZhangWei.Model.EnterStock();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["EnterStock_ID"]!=null && ds.Tables[0].Rows[0]["EnterStock_ID"].ToString()!="")
				{
					model.EnterStock_ID=int.Parse(ds.Tables[0].Rows[0]["EnterStock_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EnterDate"]!=null && ds.Tables[0].Rows[0]["EnterDate"].ToString()!="")
				{
					model.EnterDate=DateTime.Parse(ds.Tables[0].Rows[0]["EnterDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Dept_ID"]!=null && ds.Tables[0].Rows[0]["Dept_ID"].ToString()!="")
				{
					model.Dept_ID=int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreHouse_ID"]!=null && ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString()!="")
				{
					model.StoreHouse_ID=int.Parse(ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Employee_ID"]!=null && ds.Tables[0].Rows[0]["Employee_ID"].ToString()!="")
				{
					model.Employee_ID=int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EnterStock_ID,EnterDate,Dept_ID,StoreHouse_ID,Employee_ID ");
			strSql.Append(" FROM EnterStock ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" EnterStock_ID,EnterDate,Dept_ID,StoreHouse_ID,Employee_ID ");
			strSql.Append(" FROM EnterStock ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "EnterStock";
			parameters[1].Value = "EnterStock_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 1;
			parameters[5].Value = 1;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}


        /// <summary>
        /// 入库明细，从视图
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet EnterStockDefinite(string BeginDate, string EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from EnterStockDefinite where EnterDate between '" + BeginDate + "' and '" + Convert.ToDateTime(EndDate).AddDays(0) + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取入库汇总（按品种）
        /// </summary>
        /// <param name="BeginDate">统计开始时间</param>
        /// <param name="EndDate">统计终止时间</param>
        /// <returns>DataSet</returns>
        public DataSet EnterStockGather(string BeginDate, string EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Product_ID,ProductName,SpecName,UnitName,shortname,Name,sum(Quantity) as totalQty from EnterStockDefinite where EnterDate between '" + BeginDate + "' and '" + Convert.ToDateTime(EndDate).AddDays(1) + "' group by Product_ID,ProductName,SpecName,UnitName,shortname,Name");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 生成入库汇总（按单号汇总）
        /// </summary>
        /// <param name="BeginDate">统计开始时间</param>
        /// <param name="EndDate">统计终止时间</param>
        /// <returns>DataSet</returns>
        public DataSet GetGatherByList(string BeginDate, string EndDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EnterStock_ID, count(Product_ID)as TrCount, sum(Price*Quantity) as totalPrice,EnterDate,StoreAdd ");
            strSql.Append("from dbo.EnterStockDefinite where EnterDate between '" + BeginDate + "' and '" + Convert.ToDateTime(EndDate).AddDays(1) + "' group by EnterStock_ID,EnterDate,StoreAdd");
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  Method
	}
}

