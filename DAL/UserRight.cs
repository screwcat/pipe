using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:UserRight
	/// </summary>
	public partial class UserRight
	{
		public UserRight()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZhangWei.Model.UserRight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserRight(");
			strSql.Append("UserId,Rights)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@Rights)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Rights", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Rights;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.UserRight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserRight set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("Rights=@Rights");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Rights", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Rights;

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
			strSql.Append("delete from UserRight ");
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
        /// 批量删除数据，根据用户ID
        /// </summary>
        public bool DeleteList(Int32 UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserRight ");
            strSql.Append(" where UserId = (" + UserId + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ZhangWei.Model.UserRight GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserId,Rights from UserRight ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			ZhangWei.Model.UserRight model=new ZhangWei.Model.UserRight();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserId"]!=null && ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rights"]!=null && ds.Tables[0].Rows[0]["Rights"].ToString()!="")
				{
					model.Rights=int.Parse(ds.Tables[0].Rows[0]["Rights"].ToString());
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
			strSql.Append("select UserId,Rights ");
			strSql.Append(" FROM UserRight ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表，根据用户ID
        /// </summary>
        public DataSet GetListByUserId(Int32 UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,Rights ");
            strSql.Append(" FROM UserRight ");
            strSql.Append(" where UserId = " + UserId);
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
			strSql.Append(" UserId,Rights ");
			strSql.Append(" FROM UserRight ");
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
			parameters[0].Value = "UserRight";
			parameters[1].Value = "";
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

