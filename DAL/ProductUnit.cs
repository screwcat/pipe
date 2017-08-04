using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:ProductUnit
	/// </summary>
	public partial class ProductUnit
	{
		public ProductUnit()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.ProductUnit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductUnit(");
			strSql.Append("Name,Employee_ID,CreateDate,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Employee_ID,@CreateDate,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Employee_ID;
			parameters[2].Value = model.CreateDate;
			parameters[3].Value = model.Remark;

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
		public bool Update(ZhangWei.Model.ProductUnit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductUnit set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Employee_ID=@Employee_ID,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ProductUnit_ID=@ProductUnit_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250),
					new SqlParameter("@ProductUnit_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Employee_ID;
			parameters[2].Value = model.CreateDate;
			parameters[3].Value = model.Remark;
			parameters[4].Value = model.ProductUnit_ID;

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
		public bool Delete(int ProductUnit_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductUnit ");
			strSql.Append(" where ProductUnit_ID=@ProductUnit_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductUnit_ID", SqlDbType.Int,4)
};
			parameters[0].Value = ProductUnit_ID;

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
		public bool DeleteList(string ProductUnit_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductUnit ");
			strSql.Append(" where ProductUnit_ID in ("+ProductUnit_IDlist + ")  ");
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
		public ZhangWei.Model.ProductUnit GetModel(int ProductUnit_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductUnit_ID,Name,Employee_ID,CreateDate,Remark from ProductUnit ");
			strSql.Append(" where ProductUnit_ID=@ProductUnit_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductUnit_ID", SqlDbType.Int,4)
};
			parameters[0].Value = ProductUnit_ID;

			ZhangWei.Model.ProductUnit model=new ZhangWei.Model.ProductUnit();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductUnit_ID"]!=null && ds.Tables[0].Rows[0]["ProductUnit_ID"].ToString()!="")
				{
					model.ProductUnit_ID=int.Parse(ds.Tables[0].Rows[0]["ProductUnit_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Employee_ID"]!=null && ds.Tables[0].Rows[0]["Employee_ID"].ToString()!="")
				{
					model.Employee_ID=int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateDate"]!=null && ds.Tables[0].Rows[0]["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
			strSql.Append("select ProductUnit_ID,Name,Employee_ID,CreateDate,Remark ");
			strSql.Append(" FROM ProductUnit ");
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
			strSql.Append(" ProductUnit_ID,Name,Employee_ID,CreateDate,Remark ");
			strSql.Append(" FROM ProductUnit ");
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
			parameters[0].Value = "ProductUnit";
			parameters[1].Value = "ProductUnit_ID";
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

