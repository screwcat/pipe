using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
	/// <summary>
	/// 数据访问类:user
	/// </summary>
	public partial class user
	{
		public user()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into user(");
			strSql.Append("User_Id,User_Pwd,Again_Pwd,Bel_Group,Div_Type,User_Auth,Auth_Type,User_Status,Create_User,Create_Date,Create_Time,Appr_User,Appr_Date,Appr_Time,Pwd_Date,Err_Count,Use_eJCIC)");
			strSql.Append(" values (");
			strSql.Append("@User_Id,@User_Pwd,@Again_Pwd,@Bel_Group,@Div_Type,@User_Auth,@Auth_Type,@User_Status,@Create_User,@Create_Date,@Create_Time,@Appr_User,@Appr_Date,@Appr_Time,@Pwd_Date,@Err_Count,@Use_eJCIC)");
			SqlParameter[] parameters = {
					new SqlParameter("@User_Id", SqlDbType.VarChar,6),
					new SqlParameter("@User_Pwd", SqlDbType.VarChar,8),
					new SqlParameter("@Again_Pwd", SqlDbType.VarChar,8),
					new SqlParameter("@Bel_Group", SqlDbType.VarChar,3),
					new SqlParameter("@Div_Type", SqlDbType.VarChar,1),
					new SqlParameter("@User_Auth", SqlDbType.VarChar,1),
					new SqlParameter("@Auth_Type", SqlDbType.VarChar,1),
					new SqlParameter("@User_Status", SqlDbType.VarChar,1),
					new SqlParameter("@Create_User", SqlDbType.VarChar,6),
					new SqlParameter("@Create_Date", SqlDbType.VarChar,7),
					new SqlParameter("@Create_Time", SqlDbType.VarChar,6),
					new SqlParameter("@Appr_User", SqlDbType.VarChar,6),
					new SqlParameter("@Appr_Date", SqlDbType.VarChar,7),
					new SqlParameter("@Appr_Time", SqlDbType.VarChar,6),
					new SqlParameter("@Pwd_Date", SqlDbType.VarChar,7),
					new SqlParameter("@Err_Count", SqlDbType.Float,8),
					new SqlParameter("@Use_eJCIC", SqlDbType.VarChar,1)};
			parameters[0].Value = model.User_Id;
			parameters[1].Value = model.User_Pwd;
			parameters[2].Value = model.Again_Pwd;
			parameters[3].Value = model.Bel_Group;
			parameters[4].Value = model.Div_Type;
			parameters[5].Value = model.User_Auth;
			parameters[6].Value = model.Auth_Type;
			parameters[7].Value = model.User_Status;
			parameters[8].Value = model.Create_User;
			parameters[9].Value = model.Create_Date;
			parameters[10].Value = model.Create_Time;
			parameters[11].Value = model.Appr_User;
			parameters[12].Value = model.Appr_Date;
			parameters[13].Value = model.Appr_Time;
			parameters[14].Value = model.Pwd_Date;
			parameters[15].Value = model.Err_Count;
			parameters[16].Value = model.Use_eJCIC;

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
		public bool Update(ZhangWei.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update user set ");
			strSql.Append("User_Id=@User_Id,");
			strSql.Append("User_Pwd=@User_Pwd,");
			strSql.Append("Again_Pwd=@Again_Pwd,");
			strSql.Append("Bel_Group=@Bel_Group,");
			strSql.Append("Div_Type=@Div_Type,");
			strSql.Append("User_Auth=@User_Auth,");
			strSql.Append("Auth_Type=@Auth_Type,");
			strSql.Append("User_Status=@User_Status,");
			strSql.Append("Create_User=@Create_User,");
			strSql.Append("Create_Date=@Create_Date,");
			strSql.Append("Create_Time=@Create_Time,");
			strSql.Append("Appr_User=@Appr_User,");
			strSql.Append("Appr_Date=@Appr_Date,");
			strSql.Append("Appr_Time=@Appr_Time,");
			strSql.Append("Pwd_Date=@Pwd_Date,");
			strSql.Append("Err_Count=@Err_Count,");
			strSql.Append("Use_eJCIC=@Use_eJCIC");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@User_Id", SqlDbType.VarChar,6),
					new SqlParameter("@User_Pwd", SqlDbType.VarChar,8),
					new SqlParameter("@Again_Pwd", SqlDbType.VarChar,8),
					new SqlParameter("@Bel_Group", SqlDbType.VarChar,3),
					new SqlParameter("@Div_Type", SqlDbType.VarChar,1),
					new SqlParameter("@User_Auth", SqlDbType.VarChar,1),
					new SqlParameter("@Auth_Type", SqlDbType.VarChar,1),
					new SqlParameter("@User_Status", SqlDbType.VarChar,1),
					new SqlParameter("@Create_User", SqlDbType.VarChar,6),
					new SqlParameter("@Create_Date", SqlDbType.VarChar,7),
					new SqlParameter("@Create_Time", SqlDbType.VarChar,6),
					new SqlParameter("@Appr_User", SqlDbType.VarChar,6),
					new SqlParameter("@Appr_Date", SqlDbType.VarChar,7),
					new SqlParameter("@Appr_Time", SqlDbType.VarChar,6),
					new SqlParameter("@Pwd_Date", SqlDbType.VarChar,7),
					new SqlParameter("@Err_Count", SqlDbType.Float,8),
					new SqlParameter("@Use_eJCIC", SqlDbType.VarChar,1)};
			parameters[0].Value = model.User_Id;
			parameters[1].Value = model.User_Pwd;
			parameters[2].Value = model.Again_Pwd;
			parameters[3].Value = model.Bel_Group;
			parameters[4].Value = model.Div_Type;
			parameters[5].Value = model.User_Auth;
			parameters[6].Value = model.Auth_Type;
			parameters[7].Value = model.User_Status;
			parameters[8].Value = model.Create_User;
			parameters[9].Value = model.Create_Date;
			parameters[10].Value = model.Create_Time;
			parameters[11].Value = model.Appr_User;
			parameters[12].Value = model.Appr_Date;
			parameters[13].Value = model.Appr_Time;
			parameters[14].Value = model.Pwd_Date;
			parameters[15].Value = model.Err_Count;
			parameters[16].Value = model.Use_eJCIC;

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
			strSql.Append("delete from user ");
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
		public ZhangWei.Model.user GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 User_Id,User_Pwd,Again_Pwd,Bel_Group,Div_Type,User_Auth,Auth_Type,User_Status,Create_User,Create_Date,Create_Time,Appr_User,Appr_Date,Appr_Time,Pwd_Date,Err_Count,Use_eJCIC from user ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			ZhangWei.Model.user model=new ZhangWei.Model.user();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["User_Id"]!=null && ds.Tables[0].Rows[0]["User_Id"].ToString()!="")
				{
					model.User_Id=ds.Tables[0].Rows[0]["User_Id"].ToString();
				}
				if(ds.Tables[0].Rows[0]["User_Pwd"]!=null && ds.Tables[0].Rows[0]["User_Pwd"].ToString()!="")
				{
					model.User_Pwd=ds.Tables[0].Rows[0]["User_Pwd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Again_Pwd"]!=null && ds.Tables[0].Rows[0]["Again_Pwd"].ToString()!="")
				{
					model.Again_Pwd=ds.Tables[0].Rows[0]["Again_Pwd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Bel_Group"]!=null && ds.Tables[0].Rows[0]["Bel_Group"].ToString()!="")
				{
					model.Bel_Group=ds.Tables[0].Rows[0]["Bel_Group"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Div_Type"]!=null && ds.Tables[0].Rows[0]["Div_Type"].ToString()!="")
				{
					model.Div_Type=ds.Tables[0].Rows[0]["Div_Type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["User_Auth"]!=null && ds.Tables[0].Rows[0]["User_Auth"].ToString()!="")
				{
					model.User_Auth=ds.Tables[0].Rows[0]["User_Auth"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Auth_Type"]!=null && ds.Tables[0].Rows[0]["Auth_Type"].ToString()!="")
				{
					model.Auth_Type=ds.Tables[0].Rows[0]["Auth_Type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["User_Status"]!=null && ds.Tables[0].Rows[0]["User_Status"].ToString()!="")
				{
					model.User_Status=ds.Tables[0].Rows[0]["User_Status"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Create_User"]!=null && ds.Tables[0].Rows[0]["Create_User"].ToString()!="")
				{
					model.Create_User=ds.Tables[0].Rows[0]["Create_User"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Create_Date"]!=null && ds.Tables[0].Rows[0]["Create_Date"].ToString()!="")
				{
					model.Create_Date=ds.Tables[0].Rows[0]["Create_Date"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Create_Time"]!=null && ds.Tables[0].Rows[0]["Create_Time"].ToString()!="")
				{
					model.Create_Time=ds.Tables[0].Rows[0]["Create_Time"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Appr_User"]!=null && ds.Tables[0].Rows[0]["Appr_User"].ToString()!="")
				{
					model.Appr_User=ds.Tables[0].Rows[0]["Appr_User"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Appr_Date"]!=null && ds.Tables[0].Rows[0]["Appr_Date"].ToString()!="")
				{
					model.Appr_Date=ds.Tables[0].Rows[0]["Appr_Date"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Appr_Time"]!=null && ds.Tables[0].Rows[0]["Appr_Time"].ToString()!="")
				{
					model.Appr_Time=ds.Tables[0].Rows[0]["Appr_Time"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Pwd_Date"]!=null && ds.Tables[0].Rows[0]["Pwd_Date"].ToString()!="")
				{
					model.Pwd_Date=ds.Tables[0].Rows[0]["Pwd_Date"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Err_Count"]!=null && ds.Tables[0].Rows[0]["Err_Count"].ToString()!="")
				{
					model.Err_Count=decimal.Parse(ds.Tables[0].Rows[0]["Err_Count"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Use_eJCIC"]!=null && ds.Tables[0].Rows[0]["Use_eJCIC"].ToString()!="")
				{
					model.Use_eJCIC=ds.Tables[0].Rows[0]["Use_eJCIC"].ToString();
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
			strSql.Append("select User_Id,User_Pwd,Again_Pwd,Bel_Group,Div_Type,User_Auth,Auth_Type,User_Status,Create_User,Create_Date,Create_Time,Appr_User,Appr_Date,Appr_Time,Pwd_Date,Err_Count,Use_eJCIC ");
			strSql.Append(" FROM user ");
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
			strSql.Append(" User_Id,User_Pwd,Again_Pwd,Bel_Group,Div_Type,User_Auth,Auth_Type,User_Status,Create_User,Create_Date,Create_Time,Appr_User,Appr_Date,Appr_Time,Pwd_Date,Err_Count,Use_eJCIC ");
			strSql.Append(" FROM user ");
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
			parameters[0].Value = "user";
			parameters[1].Value = "diagram_id";
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

