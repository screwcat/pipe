﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:Buy_Detail
	/// </summary>
	public partial class Buy_Detail
	{
		public Buy_Detail()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.Buy_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Buy_Detail(");
			strSql.Append("Buy_ID,Product_ID,BuyOrder_ID,Quantity,Price)");
			strSql.Append(" values (");
			strSql.Append("@Buy_ID,@Product_ID,@BuyOrder_ID,@Quantity,@Price)");
			SqlParameter[] parameters = {
					new SqlParameter("@Buy_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@BuyOrder_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Money,8)};
			parameters[0].Value = model.Buy_ID;
			parameters[1].Value = model.Product_ID;
			parameters[2].Value = model.BuyOrder_ID;
			parameters[3].Value = model.Quantity;
			parameters[4].Value = model.Price;

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
		public bool Update(ZhangWei.Model.Buy_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Buy_Detail set ");
			strSql.Append("Buy_ID=@Buy_ID,");
			strSql.Append("Product_ID=@Product_ID,");
			strSql.Append("BuyOrder_ID=@BuyOrder_ID,");
			strSql.Append("Quantity=@Quantity,");
			strSql.Append("Price=@Price");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Buy_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@BuyOrder_ID", SqlDbType.Int,4),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Money,8)};
			parameters[0].Value = model.Buy_ID;
			parameters[1].Value = model.Product_ID;
			parameters[2].Value = model.BuyOrder_ID;
			parameters[3].Value = model.Quantity;
			parameters[4].Value = model.Price;

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
			strSql.Append("delete from Buy_Detail ");
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
		public ZhangWei.Model.Buy_Detail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Buy_ID,Product_ID,BuyOrder_ID,Quantity,Price from Buy_Detail ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			ZhangWei.Model.Buy_Detail model=new ZhangWei.Model.Buy_Detail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Buy_ID"]!=null && ds.Tables[0].Rows[0]["Buy_ID"].ToString()!="")
				{
					model.Buy_ID=int.Parse(ds.Tables[0].Rows[0]["Buy_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Product_ID"]!=null && ds.Tables[0].Rows[0]["Product_ID"].ToString()!="")
				{
					model.Product_ID=int.Parse(ds.Tables[0].Rows[0]["Product_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BuyOrder_ID"]!=null && ds.Tables[0].Rows[0]["BuyOrder_ID"].ToString()!="")
				{
					model.BuyOrder_ID=int.Parse(ds.Tables[0].Rows[0]["BuyOrder_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Quantity"]!=null && ds.Tables[0].Rows[0]["Quantity"].ToString()!="")
				{
					model.Quantity=int.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
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
			strSql.Append("select Buy_ID,Product_ID,BuyOrder_ID,Quantity,Price ");
			strSql.Append(" FROM Buy_Detail ");
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
			strSql.Append(" Buy_ID,Product_ID,BuyOrder_ID,Quantity,Price ");
			strSql.Append(" FROM Buy_Detail ");
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
			parameters[0].Value = "Buy_Detail";
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

