using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// ProductClass
	/// </summary>
	public partial class ProductClass
	{
		private readonly ZhangWei.DAL.ProductClass dal=new ZhangWei.DAL.ProductClass();
		public ProductClass()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.ProductClass model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.ProductClass model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProductClass_ID)
		{
			
			return dal.Delete(ProductClass_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProductClass_IDlist )
		{
			return dal.DeleteList(ProductClass_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.ProductClass GetModel(int ProductClass_ID)
		{
			
			return dal.GetModel(ProductClass_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.ProductClass GetModelByCache(int ProductClass_ID)
		{
			
			string CacheKey = "ProductClassModel-" + ProductClass_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductClass_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.ProductClass)objModel;
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
		public List<ZhangWei.Model.ProductClass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.ProductClass> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.ProductClass> modelList = new List<ZhangWei.Model.ProductClass>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.ProductClass model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.ProductClass();
					if(dt.Rows[n]["ProductClass_ID"]!=null && dt.Rows[n]["ProductClass_ID"].ToString()!="")
					{
						model.ProductClass_ID=int.Parse(dt.Rows[n]["ProductClass_ID"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Employee_ID"]!=null && dt.Rows[n]["Employee_ID"].ToString()!="")
					{
						model.Employee_ID=int.Parse(dt.Rows[n]["Employee_ID"].ToString());
					}
					if(dt.Rows[n]["CreateDate"]!=null && dt.Rows[n]["CreateDate"].ToString()!="")
					{
						model.CreateDate=DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

