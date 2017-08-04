using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:Dept_Supplier
	/// </summary>
	public partial class Dept_Supplier
	{
		public Dept_Supplier()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.Dept_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Dept_Supplier(");
			strSql.Append("Dept_ID,Supplier_ID)");
			strSql.Append(" values (");
			strSql.Append("@Dept_ID,@Supplier_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Supplier_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Dept_ID;
			parameters[1].Value = model.Supplier_ID;

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
		public bool Update(ZhangWei.Model.Dept_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dept_Supplier set ");
			strSql.Append("Dept_ID=@Dept_ID,");
			strSql.Append("Supplier_ID=@Supplier_ID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Supplier_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Dept_ID;
			parameters[1].Value = model.Supplier_ID;

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
			strSql.Append("delete from Dept_Supplier ");
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
		public ZhangWei.Model.Dept_Supplier GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Dept_ID,Supplier_ID from Dept_Supplier ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			ZhangWei.Model.Dept_Supplier model=new ZhangWei.Model.Dept_Supplier();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Dept_ID"]!=null && ds.Tables[0].Rows[0]["Dept_ID"].ToString()!="")
				{
					model.Dept_ID=int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier_ID"]!=null && ds.Tables[0].Rows[0]["Supplier_ID"].ToString()!="")
				{
					model.Supplier_ID=int.Parse(ds.Tables[0].Rows[0]["Supplier_ID"].ToString());
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
			strSql.Append("select Dept_ID,Supplier_ID ");
			strSql.Append(" FROM Dept_Supplier ");
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
			strSql.Append(" Dept_ID,Supplier_ID ");
			strSql.Append(" FROM Dept_Supplier ");
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
			parameters[0].Value = "Dept_Supplier";
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

