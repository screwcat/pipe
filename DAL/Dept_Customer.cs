using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:Dept_Customer
	/// </summary>
	public partial class Dept_Customer
	{
		public Dept_Customer()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.Dept_Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Dept_Customer(");
			strSql.Append("Dept_ID,Customer_ID)");
			strSql.Append(" values (");
			strSql.Append("@Dept_ID,@Customer_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Customer_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Dept_ID;
			parameters[1].Value = model.Customer_ID;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.Dept_Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dept_Customer set ");
			strSql.Append("Dept_ID=@Dept_ID,");
			strSql.Append("Customer_ID=@Customer_ID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Customer_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Dept_ID;
			parameters[1].Value = model.Customer_ID;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dept_Customer ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

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
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.Dept_Customer GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Dept_ID,Customer_ID from Dept_Customer ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			ZhangWei.Model.Dept_Customer model=new ZhangWei.Model.Dept_Customer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Dept_ID"]!=null && ds.Tables[0].Rows[0]["Dept_ID"].ToString()!="")
				{
					model.Dept_ID=int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Customer_ID"]!=null && ds.Tables[0].Rows[0]["Customer_ID"].ToString()!="")
				{
					model.Customer_ID=int.Parse(ds.Tables[0].Rows[0]["Customer_ID"].ToString());
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
			strSql.Append("select Dept_ID,Customer_ID ");
			strSql.Append(" FROM Dept_Customer ");
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
			strSql.Append(" Dept_ID,Customer_ID ");
			strSql.Append(" FROM Dept_Customer ");
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
			parameters[0].Value = "Dept_Customer";
			parameters[1].Value = "Dept_ID";
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

