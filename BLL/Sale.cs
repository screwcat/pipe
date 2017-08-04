using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// Sale
	/// </summary>
	public partial class Sale
	{
		private readonly ZhangWei.DAL.Sale dal=new ZhangWei.DAL.Sale();
		public Sale()
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
		public bool Exists(int Sale_ID)
		{
			return dal.Exists(Sale_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.Sale model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.Sale model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Sale_ID)
		{
			
			return dal.Delete(Sale_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Sale_IDlist )
		{
			return dal.DeleteList(Sale_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.Sale GetModel(int Sale_ID)
		{
			
			return dal.GetModel(Sale_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.Sale GetModelByCache(int Sale_ID)
		{
			
			string CacheKey = "SaleModel-" + Sale_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Sale_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.Sale)objModel;
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
		public List<ZhangWei.Model.Sale> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.Sale> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.Sale> modelList = new List<ZhangWei.Model.Sale>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.Sale model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.Sale();
					if(dt.Rows[n]["Sale_ID"]!=null && dt.Rows[n]["Sale_ID"].ToString()!="")
					{
						model.Sale_ID=int.Parse(dt.Rows[n]["Sale_ID"].ToString());
					}
					if(dt.Rows[n]["SaleDate"]!=null && dt.Rows[n]["SaleDate"].ToString()!="")
					{
						model.SaleDate=DateTime.Parse(dt.Rows[n]["SaleDate"].ToString());
					}
					if(dt.Rows[n]["TradeNo"]!=null && dt.Rows[n]["TradeNo"].ToString()!="")
					{
					model.TradeNo=dt.Rows[n]["TradeNo"].ToString();
					}
					if(dt.Rows[n]["Dept_ID"]!=null && dt.Rows[n]["Dept_ID"].ToString()!="")
					{
						model.Dept_ID=int.Parse(dt.Rows[n]["Dept_ID"].ToString());
					}
					if(dt.Rows[n]["Employee_ID"]!=null && dt.Rows[n]["Employee_ID"].ToString()!="")
					{
						model.Employee_ID=int.Parse(dt.Rows[n]["Employee_ID"].ToString());
					}
					if(dt.Rows[n]["StoreHouse_ID"]!=null && dt.Rows[n]["StoreHouse_ID"].ToString()!="")
					{
						model.StoreHouse_ID=int.Parse(dt.Rows[n]["StoreHouse_ID"].ToString());
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["Account"]!=null && dt.Rows[n]["Account"].ToString()!="")
					{
					model.Account=dt.Rows[n]["Account"].ToString();
					}
					if(dt.Rows[n]["GatheringWay"]!=null && dt.Rows[n]["GatheringWay"].ToString()!="")
					{
					model.GatheringWay=dt.Rows[n]["GatheringWay"].ToString();
					}
					if(dt.Rows[n]["Customer"]!=null && dt.Rows[n]["Customer"].ToString()!="")
					{
						model.Customer=int.Parse(dt.Rows[n]["Customer"].ToString());
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

