using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// Product_Supplier
	/// </summary>
	public partial class Product_Supplier
	{
		private readonly ZhangWei.DAL.Product_Supplier dal=new ZhangWei.DAL.Product_Supplier();
		public Product_Supplier()
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
		public bool Exists(int Product_ID)
		{
			return dal.Exists(Product_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.Product_Supplier model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.Product_Supplier model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Product_ID)
		{
			
			return dal.Delete(Product_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Product_IDlist )
		{
			return dal.DeleteList(Product_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.Product_Supplier GetModel(int Product_ID)
		{
			
			return dal.GetModel(Product_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.Product_Supplier GetModelByCache(int Product_ID)
		{
			
			string CacheKey = "Product_SupplierModel-" + Product_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Product_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.Product_Supplier)objModel;
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
		public List<ZhangWei.Model.Product_Supplier> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.Product_Supplier> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.Product_Supplier> modelList = new List<ZhangWei.Model.Product_Supplier>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.Product_Supplier model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.Product_Supplier();
					if(dt.Rows[n]["Product_ID"]!=null && dt.Rows[n]["Product_ID"].ToString()!="")
					{
						model.Product_ID=int.Parse(dt.Rows[n]["Product_ID"].ToString());
					}
					if(dt.Rows[n]["Supplier_ID"]!=null && dt.Rows[n]["Supplier_ID"].ToString()!="")
					{
						model.Supplier_ID=int.Parse(dt.Rows[n]["Supplier_ID"].ToString());
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

