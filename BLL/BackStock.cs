using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// BackStock
	/// </summary>
	public partial class BackStock
	{
		private readonly ZhangWei.DAL.BackStock dal=new ZhangWei.DAL.BackStock();
		public BackStock()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.BackStock model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.BackStock model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BackStock_ID)
		{
			
			return dal.Delete(BackStock_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BackStock_IDlist )
		{
			return dal.DeleteList(BackStock_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.BackStock GetModel(int BackStock_ID)
		{
			
			return dal.GetModel(BackStock_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.BackStock GetModelByCache(int BackStock_ID)
		{
			
			string CacheKey = "BackStockModel-" + BackStock_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BackStock_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.BackStock)objModel;
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
		public List<ZhangWei.Model.BackStock> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.BackStock> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.BackStock> modelList = new List<ZhangWei.Model.BackStock>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.BackStock model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.BackStock();
					if(dt.Rows[n]["BackStock_ID"]!=null && dt.Rows[n]["BackStock_ID"].ToString()!="")
					{
						model.BackStock_ID=int.Parse(dt.Rows[n]["BackStock_ID"].ToString());
					}
					if(dt.Rows[n]["BackDate"]!=null && dt.Rows[n]["BackDate"].ToString()!="")
					{
						model.BackDate=DateTime.Parse(dt.Rows[n]["BackDate"].ToString());
					}
					if(dt.Rows[n]["Dept_ID"]!=null && dt.Rows[n]["Dept_ID"].ToString()!="")
					{
						model.Dept_ID=int.Parse(dt.Rows[n]["Dept_ID"].ToString());
					}
					if(dt.Rows[n]["StoreHouse_ID"]!=null && dt.Rows[n]["StoreHouse_ID"].ToString()!="")
					{
						model.StoreHouse_ID=int.Parse(dt.Rows[n]["StoreHouse_ID"].ToString());
					}
					if(dt.Rows[n]["Employee_ID"]!=null && dt.Rows[n]["Employee_ID"].ToString()!="")
					{
						model.Employee_ID=int.Parse(dt.Rows[n]["Employee_ID"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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

