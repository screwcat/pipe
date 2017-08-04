using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// UserRight
	/// </summary>
	public partial class UserRight
	{
		private readonly ZhangWei.DAL.UserRight dal=new ZhangWei.DAL.UserRight();
		public UserRight()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZhangWei.Model.UserRight model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.UserRight model)
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
        /// 批量删除数据，根据用户ID
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteList(Int32 UserId)
        {
            return dal.DeleteList(UserId);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.UserRight GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.UserRight GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "UserRightModel-" ;
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
			return (ZhangWei.Model.UserRight)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得数据列表，根据用户Id
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public DataSet GetListByUserId(Int32 UserId)
        {
            return dal.GetListByUserId(UserId);
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
		public List<ZhangWei.Model.UserRight> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.UserRight> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.UserRight> modelList = new List<ZhangWei.Model.UserRight>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.UserRight model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.UserRight();
					if(dt.Rows[n]["UserId"]!=null && dt.Rows[n]["UserId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
					}
					if(dt.Rows[n]["Rights"]!=null && dt.Rows[n]["Rights"].ToString()!="")
					{
						model.Rights=int.Parse(dt.Rows[n]["Rights"].ToString());
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

