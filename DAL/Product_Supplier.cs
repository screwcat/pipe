using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:Product_Supplier
	/// </summary>
	public partial class Product_Supplier
	{
		public Product_Supplier()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Product_ID", "Product_Supplier"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Product_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Product_Supplier");
			strSql.Append(" where Product_ID=@Product_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4)};
			parameters[0].Value = Product_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.Product_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Product_Supplier(");
			strSql.Append("Product_ID,Supplier_ID)");
			strSql.Append(" values (");
			strSql.Append("@Product_ID,@Supplier_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@Supplier_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Product_ID;
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
		public bool Update(ZhangWei.Model.Product_Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Product_Supplier set ");
			strSql.Append("Supplier_ID=@Supplier_ID");
			strSql.Append(" where Product_ID=@Product_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Supplier_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Supplier_ID;
			parameters[1].Value = model.Product_ID;

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
		public bool Delete(int Product_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product_Supplier ");
			strSql.Append(" where Product_ID=@Product_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4)};
			parameters[0].Value = Product_ID;

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
		public bool DeleteList(string Product_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product_Supplier ");
			strSql.Append(" where Product_ID in ("+Product_IDlist + ")  ");
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
		public ZhangWei.Model.Product_Supplier GetModel(int Product_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Product_ID,Supplier_ID from Product_Supplier ");
			strSql.Append(" where Product_ID=@Product_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4)};
			parameters[0].Value = Product_ID;

			ZhangWei.Model.Product_Supplier model=new ZhangWei.Model.Product_Supplier();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Product_ID"]!=null && ds.Tables[0].Rows[0]["Product_ID"].ToString()!="")
				{
					model.Product_ID=int.Parse(ds.Tables[0].Rows[0]["Product_ID"].ToString());
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
			strSql.Append("select Product_ID,Supplier_ID ");
			strSql.Append(" FROM Product_Supplier ");
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
			strSql.Append(" Product_ID,Supplier_ID ");
			strSql.Append(" FROM Product_Supplier ");
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
			parameters[0].Value = "Product_Supplier";
			parameters[1].Value = "Product_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

