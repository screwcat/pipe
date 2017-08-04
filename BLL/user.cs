using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class user
	{
		private readonly ZhangWei.DAL.user dal=new ZhangWei.DAL.user();
		public user()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.user model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.user model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.user GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.user GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "userModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.user)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.user> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.user> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.user> modelList = new List<ZhangWei.Model.user>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.user model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.user();
					if(dt.Rows[n]["User_Id"]!=null && dt.Rows[n]["User_Id"].ToString()!="")
					{
					model.User_Id=dt.Rows[n]["User_Id"].ToString();
					}
					if(dt.Rows[n]["User_Pwd"]!=null && dt.Rows[n]["User_Pwd"].ToString()!="")
					{
					model.User_Pwd=dt.Rows[n]["User_Pwd"].ToString();
					}
					if(dt.Rows[n]["Again_Pwd"]!=null && dt.Rows[n]["Again_Pwd"].ToString()!="")
					{
					model.Again_Pwd=dt.Rows[n]["Again_Pwd"].ToString();
					}
					if(dt.Rows[n]["Bel_Group"]!=null && dt.Rows[n]["Bel_Group"].ToString()!="")
					{
					model.Bel_Group=dt.Rows[n]["Bel_Group"].ToString();
					}
					if(dt.Rows[n]["Div_Type"]!=null && dt.Rows[n]["Div_Type"].ToString()!="")
					{
					model.Div_Type=dt.Rows[n]["Div_Type"].ToString();
					}
					if(dt.Rows[n]["User_Auth"]!=null && dt.Rows[n]["User_Auth"].ToString()!="")
					{
					model.User_Auth=dt.Rows[n]["User_Auth"].ToString();
					}
					if(dt.Rows[n]["Auth_Type"]!=null && dt.Rows[n]["Auth_Type"].ToString()!="")
					{
					model.Auth_Type=dt.Rows[n]["Auth_Type"].ToString();
					}
					if(dt.Rows[n]["User_Status"]!=null && dt.Rows[n]["User_Status"].ToString()!="")
					{
					model.User_Status=dt.Rows[n]["User_Status"].ToString();
					}
					if(dt.Rows[n]["Create_User"]!=null && dt.Rows[n]["Create_User"].ToString()!="")
					{
					model.Create_User=dt.Rows[n]["Create_User"].ToString();
					}
					if(dt.Rows[n]["Create_Date"]!=null && dt.Rows[n]["Create_Date"].ToString()!="")
					{
					model.Create_Date=dt.Rows[n]["Create_Date"].ToString();
					}
					if(dt.Rows[n]["Create_Time"]!=null && dt.Rows[n]["Create_Time"].ToString()!="")
					{
					model.Create_Time=dt.Rows[n]["Create_Time"].ToString();
					}
					if(dt.Rows[n]["Appr_User"]!=null && dt.Rows[n]["Appr_User"].ToString()!="")
					{
					model.Appr_User=dt.Rows[n]["Appr_User"].ToString();
					}
					if(dt.Rows[n]["Appr_Date"]!=null && dt.Rows[n]["Appr_Date"].ToString()!="")
					{
					model.Appr_Date=dt.Rows[n]["Appr_Date"].ToString();
					}
					if(dt.Rows[n]["Appr_Time"]!=null && dt.Rows[n]["Appr_Time"].ToString()!="")
					{
					model.Appr_Time=dt.Rows[n]["Appr_Time"].ToString();
					}
					if(dt.Rows[n]["Pwd_Date"]!=null && dt.Rows[n]["Pwd_Date"].ToString()!="")
					{
					model.Pwd_Date=dt.Rows[n]["Pwd_Date"].ToString();
					}
					if(dt.Rows[n]["Err_Count"]!=null && dt.Rows[n]["Err_Count"].ToString()!="")
					{
						model.Err_Count=decimal.Parse(dt.Rows[n]["Err_Count"].ToString());
					}
					if(dt.Rows[n]["Use_eJCIC"]!=null && dt.Rows[n]["Use_eJCIC"].ToString()!="")
					{
					model.Use_eJCIC=dt.Rows[n]["Use_eJCIC"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

