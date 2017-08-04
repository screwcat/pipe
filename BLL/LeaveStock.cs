using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// LeaveStock
	/// </summary>
	public partial class LeaveStock
	{
		private readonly ZhangWei.DAL.LeaveStock dal=new ZhangWei.DAL.LeaveStock();
		public LeaveStock()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.LeaveStock model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.LeaveStock model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LeaveStock_ID)
		{
			
			return dal.Delete(LeaveStock_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LeaveStock_IDlist )
		{
			return dal.DeleteList(LeaveStock_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.LeaveStock GetModel(int LeaveStock_ID)
		{
			
			return dal.GetModel(LeaveStock_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.LeaveStock GetModelByCache(int LeaveStock_ID)
		{
			
			string CacheKey = "LeaveStockModel-" + LeaveStock_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(LeaveStock_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.LeaveStock)objModel;
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
		public List<ZhangWei.Model.LeaveStock> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.LeaveStock> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.LeaveStock> modelList = new List<ZhangWei.Model.LeaveStock>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.LeaveStock model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.LeaveStock();
					if(dt.Rows[n]["LeaveStock_ID"]!=null && dt.Rows[n]["LeaveStock_ID"].ToString()!="")
					{
						model.LeaveStock_ID=int.Parse(dt.Rows[n]["LeaveStock_ID"].ToString());
					}
					if(dt.Rows[n]["LeaveDate"]!=null && dt.Rows[n]["LeaveDate"].ToString()!="")
					{
						model.LeaveDate=DateTime.Parse(dt.Rows[n]["LeaveDate"].ToString());
					}
					if(dt.Rows[n]["Dept_ID"]!=null && dt.Rows[n]["Dept_ID"].ToString()!="")
					{
						model.Dept_ID=int.Parse(dt.Rows[n]["Dept_ID"].ToString());
					}
					if(dt.Rows[n]["StoreHouse_ID"]!=null && dt.Rows[n]["StoreHouse_ID"].ToString()!="")
					{
						model.StoreHouse_ID=int.Parse(dt.Rows[n]["StoreHouse_ID"].ToString());
					}
					if(dt.Rows[n]["ToStoreHouse_ID"]!=null && dt.Rows[n]["ToStoreHouse_ID"].ToString()!="")
					{
						model.ToStoreHouse_ID=int.Parse(dt.Rows[n]["ToStoreHouse_ID"].ToString());
					}
					if(dt.Rows[n]["Employee_ID"]!=null && dt.Rows[n]["Employee_ID"].ToString()!="")
					{
						model.Employee_ID=int.Parse(dt.Rows[n]["Employee_ID"].ToString());
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

		#endregion  Method
	}
}

