using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:SaleOrder
	/// </summary>
	public partial class SaleOrder
	{
		public SaleOrder()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.SaleOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SaleOrder(");
			strSql.Append("WriteDate,InsureDate,EndDate,Dept_ID,Customer_ID,Employee_ID)");
			strSql.Append(" values (");
			strSql.Append("@WriteDate,@InsureDate,@EndDate,@Dept_ID,@Customer_ID,@Employee_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WriteDate", SqlDbType.DateTime),
					new SqlParameter("@InsureDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Customer_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.WriteDate;
			parameters[1].Value = model.InsureDate;
			parameters[2].Value = model.EndDate;
			parameters[3].Value = model.Dept_ID;
			parameters[4].Value = model.Customer_ID;
			parameters[5].Value = model.Employee_ID;

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
		public bool Update(ZhangWei.Model.SaleOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SaleOrder set ");
			strSql.Append("WriteDate=@WriteDate,");
			strSql.Append("InsureDate=@InsureDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Dept_ID=@Dept_ID,");
			strSql.Append("Customer_ID=@Customer_ID,");
			strSql.Append("Employee_ID=@Employee_ID");
			strSql.Append(" where SaleOrder_ID=@SaleOrder_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@WriteDate", SqlDbType.DateTime),
					new SqlParameter("@InsureDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Customer_ID", SqlDbType.Int,4),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@SaleOrder_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.WriteDate;
			parameters[1].Value = model.InsureDate;
			parameters[2].Value = model.EndDate;
			parameters[3].Value = model.Dept_ID;
			parameters[4].Value = model.Customer_ID;
			parameters[5].Value = model.Employee_ID;
			parameters[6].Value = model.SaleOrder_ID;

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
		public bool Delete(int SaleOrder_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SaleOrder ");
			strSql.Append(" where SaleOrder_ID=@SaleOrder_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SaleOrder_ID", SqlDbType.Int,4)
};
			parameters[0].Value = SaleOrder_ID;

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
		public bool DeleteList(string SaleOrder_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SaleOrder ");
			strSql.Append(" where SaleOrder_ID in ("+SaleOrder_IDlist + ")  ");
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
		public ZhangWei.Model.SaleOrder GetModel(int SaleOrder_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SaleOrder_ID,WriteDate,InsureDate,EndDate,Dept_ID,Customer_ID,Employee_ID from SaleOrder ");
			strSql.Append(" where SaleOrder_ID=@SaleOrder_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SaleOrder_ID", SqlDbType.Int,4)
};
			parameters[0].Value = SaleOrder_ID;

			ZhangWei.Model.SaleOrder model=new ZhangWei.Model.SaleOrder();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SaleOrder_ID"]!=null && ds.Tables[0].Rows[0]["SaleOrder_ID"].ToString()!="")
				{
					model.SaleOrder_ID=int.Parse(ds.Tables[0].Rows[0]["SaleOrder_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WriteDate"]!=null && ds.Tables[0].Rows[0]["WriteDate"].ToString()!="")
				{
					model.WriteDate=DateTime.Parse(ds.Tables[0].Rows[0]["WriteDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InsureDate"]!=null && ds.Tables[0].Rows[0]["InsureDate"].ToString()!="")
				{
					model.InsureDate=DateTime.Parse(ds.Tables[0].Rows[0]["InsureDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Dept_ID"]!=null && ds.Tables[0].Rows[0]["Dept_ID"].ToString()!="")
				{
					model.Dept_ID=int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Customer_ID"]!=null && ds.Tables[0].Rows[0]["Customer_ID"].ToString()!="")
				{
					model.Customer_ID=int.Parse(ds.Tables[0].Rows[0]["Customer_ID"].ToString());
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
			strSql.Append("select SaleOrder_ID,WriteDate,InsureDate,EndDate,Dept_ID,Customer_ID,Employee_ID ");
			strSql.Append(" FROM SaleOrder ");
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
			strSql.Append(" SaleOrder_ID,WriteDate,InsureDate,EndDate,Dept_ID,Customer_ID,Employee_ID ");
			strSql.Append(" FROM SaleOrder ");
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
			parameters[0].Value = "SaleOrder";
			parameters[1].Value = "SaleOrder_ID";
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

