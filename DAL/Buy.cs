using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:Buy
	/// </summary>
	public partial class Buy
	{
		public Buy()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.Buy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Buy(");
			strSql.Append("ComeDate,Dept_ID,Employee_ID)");
			strSql.Append(" values (");
			strSql.Append("@ComeDate,@Dept_ID,@Employee_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ComeDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ComeDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.Employee_ID;

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
		public bool Update(ZhangWei.Model.Buy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Buy set ");
			strSql.Append("ComeDate=@ComeDate,");
			strSql.Append("Dept_ID=@Dept_ID,");
			strSql.Append("Employee_ID=@Employee_ID");
			strSql.Append(" where Buy_ID=@Buy_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ComeDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@Buy_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ComeDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.Employee_ID;
			parameters[3].Value = model.Buy_ID;

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
		public bool Delete(int Buy_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Buy ");
			strSql.Append(" where Buy_ID=@Buy_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Buy_ID", SqlDbType.Int,4)
};
			parameters[0].Value = Buy_ID;

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
		public bool DeleteList(string Buy_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Buy ");
			strSql.Append(" where Buy_ID in ("+Buy_IDlist + ")  ");
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
		public ZhangWei.Model.Buy GetModel(int Buy_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Buy_ID,ComeDate,Dept_ID,Employee_ID from Buy ");
			strSql.Append(" where Buy_ID=@Buy_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Buy_ID", SqlDbType.Int,4)
};
			parameters[0].Value = Buy_ID;

			ZhangWei.Model.Buy model=new ZhangWei.Model.Buy();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Buy_ID"]!=null && ds.Tables[0].Rows[0]["Buy_ID"].ToString()!="")
				{
					model.Buy_ID=int.Parse(ds.Tables[0].Rows[0]["Buy_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ComeDate"]!=null && ds.Tables[0].Rows[0]["ComeDate"].ToString()!="")
				{
					model.ComeDate=DateTime.Parse(ds.Tables[0].Rows[0]["ComeDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Dept_ID"]!=null && ds.Tables[0].Rows[0]["Dept_ID"].ToString()!="")
				{
					model.Dept_ID=int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
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
			strSql.Append("select Buy_ID,ComeDate,Dept_ID,Employee_ID ");
			strSql.Append(" FROM Buy ");
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
			strSql.Append(" Buy_ID,ComeDate,Dept_ID,Employee_ID ");
			strSql.Append(" FROM Buy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "Buy";
			parameters[1].Value = "Buy_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 1;
			parameters[5].Value = 1;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

