using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:LeaveStock
	/// </summary>
	public partial class LeaveStock
	{
		public LeaveStock()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.LeaveStock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LeaveStock(");
			strSql.Append("LeaveDate,Dept_ID,StoreHouse_ID,ToStoreHouse_ID,Employee_ID)");
			strSql.Append(" values (");
			strSql.Append("@LeaveDate,@Dept_ID,@StoreHouse_ID,@ToStoreHouse_ID,@Employee_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@ToStoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.LeaveDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.StoreHouse_ID;
			parameters[3].Value = model.ToStoreHouse_ID;
			parameters[4].Value = model.Employee_ID;

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
		public bool Update(ZhangWei.Model.LeaveStock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LeaveStock set ");
			strSql.Append("LeaveDate=@LeaveDate,");
			strSql.Append("Dept_ID=@Dept_ID,");
			strSql.Append("StoreHouse_ID=@StoreHouse_ID,");
			strSql.Append("ToStoreHouse_ID=@ToStoreHouse_ID,");
			strSql.Append("Employee_ID=@Employee_ID");
			strSql.Append(" where LeaveStock_ID=@LeaveStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@ToStoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@LeaveStock_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.LeaveDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.StoreHouse_ID;
			parameters[3].Value = model.ToStoreHouse_ID;
			parameters[4].Value = model.Employee_ID;
			parameters[5].Value = model.LeaveStock_ID;

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
		public bool Delete(int LeaveStock_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LeaveStock ");
			strSql.Append(" where LeaveStock_ID=@LeaveStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveStock_ID", SqlDbType.Int,4)
};
			parameters[0].Value = LeaveStock_ID;

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
		public bool DeleteList(string LeaveStock_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LeaveStock ");
			strSql.Append(" where LeaveStock_ID in ("+LeaveStock_IDlist + ")  ");
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
		public ZhangWei.Model.LeaveStock GetModel(int LeaveStock_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LeaveStock_ID,LeaveDate,Dept_ID,StoreHouse_ID,ToStoreHouse_ID,Employee_ID from LeaveStock ");
			strSql.Append(" where LeaveStock_ID=@LeaveStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveStock_ID", SqlDbType.Int,4)
};
			parameters[0].Value = LeaveStock_ID;

			ZhangWei.Model.LeaveStock model=new ZhangWei.Model.LeaveStock();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LeaveStock_ID"]!=null && ds.Tables[0].Rows[0]["LeaveStock_ID"].ToString()!="")
				{
					model.LeaveStock_ID=int.Parse(ds.Tables[0].Rows[0]["LeaveStock_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LeaveDate"]!=null && ds.Tables[0].Rows[0]["LeaveDate"].ToString()!="")
				{
					model.LeaveDate=DateTime.Parse(ds.Tables[0].Rows[0]["LeaveDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Dept_ID"]!=null && ds.Tables[0].Rows[0]["Dept_ID"].ToString()!="")
				{
					model.Dept_ID=int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StoreHouse_ID"]!=null && ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString()!="")
				{
					model.StoreHouse_ID=int.Parse(ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToStoreHouse_ID"]!=null && ds.Tables[0].Rows[0]["ToStoreHouse_ID"].ToString()!="")
				{
					model.ToStoreHouse_ID=int.Parse(ds.Tables[0].Rows[0]["ToStoreHouse_ID"].ToString());
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
			strSql.Append("select LeaveStock_ID,LeaveDate,Dept_ID,StoreHouse_ID,ToStoreHouse_ID,Employee_ID ");
			strSql.Append(" FROM LeaveStock ");
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
			strSql.Append(" LeaveStock_ID,LeaveDate,Dept_ID,StoreHouse_ID,ToStoreHouse_ID,Employee_ID ");
			strSql.Append(" FROM LeaveStock ");
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
			parameters[0].Value = "LeaveStock";
			parameters[1].Value = "LeaveStock_ID";
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

