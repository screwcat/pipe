using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// EnterStock
	/// </summary>
	public partial class EnterStock
	{
		private readonly ZhangWei.DAL.EnterStock dal=new ZhangWei.DAL.EnterStock();
		public EnterStock()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.EnterStock model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.EnterStock model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int EnterStock_ID)
		{
			
			return dal.Delete(EnterStock_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string EnterStock_IDlist )
		{
			return dal.DeleteList(EnterStock_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.EnterStock GetModel(int EnterStock_ID)
		{
			
			return dal.GetModel(EnterStock_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.EnterStock GetModelByCache(int EnterStock_ID)
		{
			
			string CacheKey = "EnterStockModel-" + EnterStock_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(EnterStock_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.EnterStock)objModel;
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
		public List<ZhangWei.Model.EnterStock> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.EnterStock> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.EnterStock> modelList = new List<ZhangWei.Model.EnterStock>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.EnterStock model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.EnterStock();
					if(dt.Rows[n]["EnterStock_ID"]!=null && dt.Rows[n]["EnterStock_ID"].ToString()!="")
					{
						model.EnterStock_ID=int.Parse(dt.Rows[n]["EnterStock_ID"].ToString());
					}
					if(dt.Rows[n]["EnterDate"]!=null && dt.Rows[n]["EnterDate"].ToString()!="")
					{
						model.EnterDate=DateTime.Parse(dt.Rows[n]["EnterDate"].ToString());
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

        /// <summary>
        /// 入库明细，从视图
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet EnterStockDefinite(string BeginDate, string EndDate)
        {
            return dal.EnterStockDefinite(BeginDate, EndDate);
        }

        /// <summary>
        /// 获取入库汇总
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet EnterStockGather(string BeginDate, string EndDate)
        {
            return dal.EnterStockGather(BeginDate, EndDate);
        }


        /// <summary>
        /// 生成入库汇总（按单号汇总）
        /// </summary>
        /// <param name="BeginDate">统计开始时间</param>
        /// <param name="EndDate">统计终止时间</param>
        /// <returns>DataSet</returns>
        public DataSet GetGatherByList(string BeginDate, string EndDate)
        {
            return dal.GetGatherByList(BeginDate, EndDate);
        }


		#endregion  Method
	}
}

