using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections;
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:ProductList
	/// </summary>
	public partial class ProductList
	{
		public ProductList()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZhangWei.Model.ProductList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductList(");
			strSql.Append("ProductClass_ID,Name,Employee_ID,CreateDate,Remark)");
			strSql.Append(" values (");
			strSql.Append("@ProductClass_ID,@Name,@Employee_ID,@CreateDate,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductClass_ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250)};
			parameters[0].Value = model.ProductClass_ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Employee_ID;
			parameters[3].Value = model.CreateDate;
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
		public bool Update(ZhangWei.Model.ProductList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductList set ");
			strSql.Append("ProductClass_ID=@ProductClass_ID,");
			strSql.Append("Name=@Name,");
			strSql.Append("Employee_ID=@Employee_ID,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ProductList_ID=@ProductList_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductClass_ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250),
					new SqlParameter("@ProductList_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProductClass_ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Employee_ID;
			parameters[3].Value = model.CreateDate;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.ProductList_ID;

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
		public bool Delete(int ProductList_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductList ");
			strSql.Append(" where ProductList_ID=@ProductList_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductList_ID", SqlDbType.Int,4)
};
			parameters[0].Value = ProductList_ID;

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
		public bool DeleteList(string ProductList_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductList ");
			strSql.Append(" where ProductList_ID in ("+ProductList_IDlist + ")  ");
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
		public ZhangWei.Model.ProductList GetModel(int ProductList_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductClass_ID,ProductList_ID,Name,Employee_ID,CreateDate,Remark from ProductList ");
			strSql.Append(" where ProductList_ID=@ProductList_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductList_ID", SqlDbType.Int,4)
};
			parameters[0].Value = ProductList_ID;

			ZhangWei.Model.ProductList model=new ZhangWei.Model.ProductList();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductClass_ID"]!=null && ds.Tables[0].Rows[0]["ProductClass_ID"].ToString()!="")
				{
					model.ProductClass_ID=int.Parse(ds.Tables[0].Rows[0]["ProductClass_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductList_ID"]!=null && ds.Tables[0].Rows[0]["ProductList_ID"].ToString()!="")
				{
					model.ProductList_ID=int.Parse(ds.Tables[0].Rows[0]["ProductList_ID"].ToString());
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
			strSql.Append("select ProductClass_ID,ProductList_ID,Name,Employee_ID,CreateDate,Remark ");
			strSql.Append(" FROM ProductList ");
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
			strSql.Append(" ProductClass_ID,ProductList_ID,Name,Employee_ID,CreateDate,Remark ");
			strSql.Append(" FROM ProductList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 根据主分类获取详细分类
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string getSelect(Int32 classId)
        {
            StringBuilder sbr = new StringBuilder();
            sbr.Append("{\"data\":[");
            DataSet ds = GetList("ProductClass_ID = " + classId);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sbr.Append("{\"value\":\"" + ds.Tables[0].Rows[i]["ProductList_ID"] + "\",\"text\":\"" + ds.Tables[0].Rows[i]["Name"] + "\"},");
            }
            if (sbr.ToString().EndsWith(","))
            {
                sbr.Remove(sbr.Length - 1, 1);
            }
            sbr.Append("]}");
            return sbr.ToString();
        }


        /// <summary>
        /// 根据主分类获取详细分类
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public ArrayList getSelectArray(Int32 classId)
        {
            ArrayList subList = new ArrayList();
            DataSet ds = GetList("ProductClass_ID = " + classId);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //subList.Add((new it("文艺","1");
            }
            return subList;
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
			parameters[0].Value = "ProductList";
			parameters[1].Value = "ProductList_ID";
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

