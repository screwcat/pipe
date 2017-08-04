﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:Customer
	/// </summary>
	public partial class Customer
	{
		public Customer()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Customer(");
			strSql.Append("Name,Address,Phone,Fax,PostalCode,ConstactPerson)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Address,@Phone,@Fax,@PostalCode,@ConstactPerson)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,250),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Phone", SqlDbType.VarChar,25),
					new SqlParameter("@Fax", SqlDbType.VarChar,25),
					new SqlParameter("@PostalCode", SqlDbType.VarChar,10),
					new SqlParameter("@ConstactPerson", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Address;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Fax;
			parameters[4].Value = model.PostalCode;
			parameters[5].Value = model.ConstactPerson;

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
		public bool Update(ZhangWei.Model.Customer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Customer set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Address=@Address,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("PostalCode=@PostalCode,");
			strSql.Append("ConstactPerson=@ConstactPerson");
			strSql.Append(" where Customer_ID=@Customer_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,250),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Phone", SqlDbType.VarChar,25),
					new SqlParameter("@Fax", SqlDbType.VarChar,25),
					new SqlParameter("@PostalCode", SqlDbType.VarChar,10),
					new SqlParameter("@ConstactPerson", SqlDbType.VarChar,20),
					new SqlParameter("@Customer_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Address;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Fax;
			parameters[4].Value = model.PostalCode;
			parameters[5].Value = model.ConstactPerson;
			parameters[6].Value = model.Customer_ID;

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
		public bool Delete(int Customer_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Customer ");
			strSql.Append(" where Customer_ID=@Customer_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Customer_ID", SqlDbType.Int,4)
};
			parameters[0].Value = Customer_ID;

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
		public bool DeleteList(string Customer_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Customer ");
			strSql.Append(" where Customer_ID in ("+Customer_IDlist + ")  ");
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
		public ZhangWei.Model.Customer GetModel(int Customer_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Customer_ID,Name,Address,Phone,Fax,PostalCode,ConstactPerson from Customer ");
			strSql.Append(" where Customer_ID=@Customer_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Customer_ID", SqlDbType.Int,4)
};
			parameters[0].Value = Customer_ID;

			ZhangWei.Model.Customer model=new ZhangWei.Model.Customer();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Customer_ID"]!=null && ds.Tables[0].Rows[0]["Customer_ID"].ToString()!="")
				{
					model.Customer_ID=int.Parse(ds.Tables[0].Rows[0]["Customer_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Phone"]!=null && ds.Tables[0].Rows[0]["Phone"].ToString()!="")
				{
					model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Fax"]!=null && ds.Tables[0].Rows[0]["Fax"].ToString()!="")
				{
					model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PostalCode"]!=null && ds.Tables[0].Rows[0]["PostalCode"].ToString()!="")
				{
					model.PostalCode=ds.Tables[0].Rows[0]["PostalCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ConstactPerson"]!=null && ds.Tables[0].Rows[0]["ConstactPerson"].ToString()!="")
				{
					model.ConstactPerson=ds.Tables[0].Rows[0]["ConstactPerson"].ToString();
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
			strSql.Append("select Customer_ID,Name,Address,Phone,Fax,PostalCode,ConstactPerson ");
			strSql.Append(" FROM Customer ");
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
			strSql.Append(" Customer_ID,Name,Address,Phone,Fax,PostalCode,ConstactPerson ");
			strSql.Append(" FROM Customer ");
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
			parameters[0].Value = "Customer";
			parameters[1].Value = "Customer_ID";
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

