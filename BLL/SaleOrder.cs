using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// SaleOrder
	/// </summary>
	public partial class SaleOrder
	{
		private readonly ZhangWei.DAL.SaleOrder dal=new ZhangWei.DAL.SaleOrder();
		public SaleOrder()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.SaleOrder model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.SaleOrder model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SaleOrder_ID)
		{
			
			return dal.Delete(SaleOrder_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SaleOrder_IDlist )
		{
			return dal.DeleteList(SaleOrder_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.SaleOrder GetModel(int SaleOrder_ID)
		{
			
			return dal.GetModel(SaleOrder_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.SaleOrder GetModelByCache(int SaleOrder_ID)
		{
			
			string CacheKey = "SaleOrderModel-" + SaleOrder_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SaleOrder_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.SaleOrder)objModel;
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
		public List<ZhangWei.Model.SaleOrder> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.SaleOrder> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.SaleOrder> modelList = new List<ZhangWei.Model.SaleOrder>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.SaleOrder model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.SaleOrder();
					if(dt.Rows[n]["SaleOrder_ID"]!=null && dt.Rows[n]["SaleOrder_ID"].ToString()!="")
					{
						model.SaleOrder_ID=int.Parse(dt.Rows[n]["SaleOrder_ID"].ToString());
					}
					if(dt.Rows[n]["WriteDate"]!=null && dt.Rows[n]["WriteDate"].ToString()!="")
					{
						model.WriteDate=DateTime.Parse(dt.Rows[n]["WriteDate"].ToString());
					}
					if(dt.Rows[n]["InsureDate"]!=null && dt.Rows[n]["InsureDate"].ToString()!="")
					{
						model.InsureDate=DateTime.Parse(dt.Rows[n]["InsureDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["Dept_ID"]!=null && dt.Rows[n]["Dept_ID"].ToString()!="")
					{
						model.Dept_ID=int.Parse(dt.Rows[n]["Dept_ID"].ToString());
					}
					if(dt.Rows[n]["Customer_ID"]!=null && dt.Rows[n]["Customer_ID"].ToString()!="")
					{
						model.Customer_ID=int.Parse(dt.Rows[n]["Customer_ID"].ToString());
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

