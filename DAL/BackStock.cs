using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:BackStock
	/// </summary>
	public partial class BackStock
	{
		public BackStock()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.BackStock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BackStock(");
			strSql.Append("BackDate,Dept_ID,StoreHouse_ID,Employee_ID,Remark)");
			strSql.Append(" values (");
			strSql.Append("@BackDate,@Dept_ID,@StoreHouse_ID,@Employee_ID,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BackDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,250)};
			parameters[0].Value = model.BackDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.StoreHouse_ID;
			parameters[3].Value = model.Employee_ID;
			parameters[4].Value = model.Remark;

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
		public bool Update(ZhangWei.Model.BackStock model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BackStock set ");
			strSql.Append("BackDate=@BackDate,");
			strSql.Append("Dept_ID=@Dept_ID,");
			strSql.Append("StoreHouse_ID=@StoreHouse_ID,");
			strSql.Append("Employee_ID=@Employee_ID,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where BackStock_ID=@BackStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BackDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,250),
					new SqlParameter("@BackStock_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.BackDate;
			parameters[1].Value = model.Dept_ID;
			parameters[2].Value = model.StoreHouse_ID;
			parameters[3].Value = model.Employee_ID;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.BackStock_ID;

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
		public bool Delete(int BackStock_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BackStock ");
			strSql.Append(" where BackStock_ID=@BackStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BackStock_ID", SqlDbType.Int,4)
};
			parameters[0].Value = BackStock_ID;

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
		public bool DeleteList(string BackStock_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BackStock ");
			strSql.Append(" where BackStock_ID in ("+BackStock_IDlist + ")  ");
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
		public ZhangWei.Model.BackStock GetModel(int BackStock_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BackStock_ID,BackDate,Dept_ID,StoreHouse_ID,Employee_ID,Remark from BackStock ");
			strSql.Append(" where BackStock_ID=@BackStock_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BackStock_ID", SqlDbType.Int,4)
};
			parameters[0].Value = BackStock_ID;

			ZhangWei.Model.BackStock model=new ZhangWei.Model.BackStock();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["BackStock_ID"]!=null && ds.Tables[0].Rows[0]["BackStock_ID"].ToString()!="")
				{
					model.BackStock_ID=int.Parse(ds.Tables[0].Rows[0]["BackStock_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BackDate"]!=null && ds.Tables[0].Rows[0]["BackDate"].ToString()!="")
				{
					model.BackDate=DateTime.Parse(ds.Tables[0].Rows[0]["BackDate"].ToString());
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
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append("select BackStock_ID,BackDate,Dept_ID,StoreHouse_ID,Employee_ID,Remark ");
			strSql.Append(" FROM BackStock ");
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
			strSql.Append(" BackStock_ID,BackDate,Dept_ID,StoreHouse_ID,Employee_ID,Remark ");
			strSql.Append(" FROM BackStock ");
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
			parameters[0].Value = "BackStock";
			parameters[1].Value = "BackStock_ID";
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

