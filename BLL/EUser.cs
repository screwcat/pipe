using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// EUser
	/// </summary>
	public partial class EUser
	{
		private readonly ZhangWei.DAL.EUser dal=new ZhangWei.DAL.EUser();
		public EUser()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserId)
		{
			return dal.Exists(UserId);
		}

        /// <summary>
        /// 是否存在该记录，根据用户名
        /// </summary>
        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.EUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.EUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserId)
		{
			
			return dal.Delete(UserId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIdlist )
		{
			return dal.DeleteList(UserIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.EUser GetModel(int UserId)
		{
			
			return dal.GetModel(UserId);
		}

        public ZhangWei.Model.EUser GetModelByUN(string UserName)
        {
            return dal.GetModelByUN(UserName);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.EUser GetModelByCache(int UserId)
		{
			
			string CacheKey = "EUserModel-" + UserId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.EUser)objModel;
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
		public List<ZhangWei.Model.EUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.EUser> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.EUser> modelList = new List<ZhangWei.Model.EUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.EUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.EUser();
					if(dt.Rows[n]["UserId"]!=null && dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
					}
					if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
					{
					model.UserName=dt.Rows[n]["UserName"].ToString();
					}
					if(dt.Rows[n]["PassWord"]!=null && dt.Rows[n]["PassWord"].ToString()!="")
					{
					model.PassWord=dt.Rows[n]["PassWord"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Sex"]!=null && dt.Rows[n]["Sex"].ToString()!="")
					{
					model.Sex=dt.Rows[n]["Sex"].ToString();
					}
					if(dt.Rows[n]["Age"]!=null && dt.Rows[n]["Age"].ToString()!="")
					{
						model.Age=int.Parse(dt.Rows[n]["Age"].ToString());
					}
					if(dt.Rows[n]["ID_Card"]!=null && dt.Rows[n]["ID_Card"].ToString()!="")
					{
					model.ID_Card=dt.Rows[n]["ID_Card"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					if(dt.Rows[n]["MobilPhone"]!=null && dt.Rows[n]["MobilPhone"].ToString()!="")
					{
					model.MobilPhone=dt.Rows[n]["MobilPhone"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["Postalcode"]!=null && dt.Rows[n]["Postalcode"].ToString()!="")
					{
					model.Postalcode=dt.Rows[n]["Postalcode"].ToString();
					}
					if(dt.Rows[n]["Work"]!=null && dt.Rows[n]["Work"].ToString()!="")
					{
					model.Work=dt.Rows[n]["Work"].ToString();
					}
					if(dt.Rows[n]["Income"]!=null && dt.Rows[n]["Income"].ToString()!="")
					{
						model.Income=decimal.Parse(dt.Rows[n]["Income"].ToString());
					}
					if(dt.Rows[n]["Integral"]!=null && dt.Rows[n]["Integral"].ToString()!="")
					{
						model.Integral=int.Parse(dt.Rows[n]["Integral"].ToString());
					}
					if(dt.Rows[n]["CreateTime"]!=null && dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
					}
					if(dt.Rows[n]["LaseLogin"]!=null && dt.Rows[n]["LaseLogin"].ToString()!="")
					{
						model.LaseLogin=DateTime.Parse(dt.Rows[n]["LaseLogin"].ToString());
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

