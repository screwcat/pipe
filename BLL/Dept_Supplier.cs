using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// Dept_Supplier
	/// </summary>
	public partial class Dept_Supplier
	{
		private readonly ZhangWei.DAL.Dept_Supplier dal=new ZhangWei.DAL.Dept_Supplier();
		public Dept_Supplier()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ZhangWei.Model.Dept_Supplier model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.Dept_Supplier model)
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
		public ZhangWei.Model.Dept_Supplier GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.Dept_Supplier GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "Dept_SupplierModel-" ;
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
			return (ZhangWei.Model.Dept_Supplier)objModel;
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
		public List<ZhangWei.Model.Dept_Supplier> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.Dept_Supplier> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.Dept_Supplier> modelList = new List<ZhangWei.Model.Dept_Supplier>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.Dept_Supplier model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.Dept_Supplier();
					if(dt.Rows[n]["Dept_ID"]!=null && dt.Rows[n]["Dept_ID"].ToString()!="")
					{
						model.Dept_ID=int.Parse(dt.Rows[n]["Dept_ID"].ToString());
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

