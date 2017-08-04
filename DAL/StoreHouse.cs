using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:StoreHouse
	/// </summary>
	public partial class StoreHouse
	{
		public StoreHouse()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.StoreHouse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StoreHouse(");
			strSql.Append("Address,Phone,Employee_ID,CreateDate)");
			strSql.Append(" values (");
			strSql.Append("@Address,@Phone,@Employee_ID,@CreateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Phone", SqlDbType.VarChar,25),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.Address;
			parameters[1].Value = model.Phone;
			parameters[2].Value = model.Employee_ID;
			parameters[3].Value = model.CreateDate;

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
		public bool Update(ZhangWei.Model.StoreHouse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StoreHouse set ");
			strSql.Append("Address=@Address,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Employee_ID=@Employee_ID,");
			strSql.Append("CreateDate=@CreateDate");
			strSql.Append(" where StoreHouse_ID=@StoreHouse_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Phone", SqlDbType.VarChar,25),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Address;
			parameters[1].Value = model.Phone;
			parameters[2].Value = model.Employee_ID;
			parameters[3].Value = model.CreateDate;
			parameters[4].Value = model.StoreHouse_ID;

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
		public bool Delete(int StoreHouse_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreHouse ");
			strSql.Append(" where StoreHouse_ID=@StoreHouse_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreHouse_ID;

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
		public bool DeleteList(string StoreHouse_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StoreHouse ");
			strSql.Append(" where StoreHouse_ID in ("+StoreHouse_IDlist + ")  ");
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
		public ZhangWei.Model.StoreHouse GetModel(int StoreHouse_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoreHouse_ID,Address,Phone,Employee_ID,CreateDate from StoreHouse ");
			strSql.Append(" where StoreHouse_ID=@StoreHouse_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4)
};
			parameters[0].Value = StoreHouse_ID;

			ZhangWei.Model.StoreHouse model=new ZhangWei.Model.StoreHouse();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoreHouse_ID"]!=null && ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString()!="")
				{
					model.StoreHouse_ID=int.Parse(ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Phone"]!=null && ds.Tables[0].Rows[0]["Phone"].ToString()!="")
				{
					model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Employee_ID"]!=null && ds.Tables[0].Rows[0]["Employee_ID"].ToString()!="")
				{
					model.Employee_ID=int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateDate"]!=null && ds.Tables[0].Rows[0]["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
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
			strSql.Append("select StoreHouse_ID,Address,Phone,Employee_ID,CreateDate ");
			strSql.Append(" FROM StoreHouse ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by Address");
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
			strSql.Append(" StoreHouse_ID,Address,Phone,Employee_ID,CreateDate ");
			strSql.Append(" FROM StoreHouse ");
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
			parameters[0].Value = "StoreHouse";
			parameters[1].Value = "StoreHouse_ID";
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

