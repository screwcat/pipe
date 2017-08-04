using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// Customer
	/// </summary>
	public partial class Customer
	{
		private readonly ZhangWei.DAL.Customer dal=new ZhangWei.DAL.Customer();
		public Customer()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.Customer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.Customer model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Customer_ID)
		{
			
			return dal.Delete(Customer_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Customer_IDlist )
		{
			return dal.DeleteList(Customer_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.Customer GetModel(int Customer_ID)
		{
			
			return dal.GetModel(Customer_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.Customer GetModelByCache(int Customer_ID)
		{
			
			string CacheKey = "CustomerModel-" + Customer_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Customer_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.Customer)objModel;
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
		public List<ZhangWei.Model.Customer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.Customer> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.Customer> modelList = new List<ZhangWei.Model.Customer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.Customer model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.Customer();
					if(dt.Rows[n]["Customer_ID"]!=null && dt.Rows[n]["Customer_ID"].ToString()!="")
					{
						model.Customer_ID=int.Parse(dt.Rows[n]["Customer_ID"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					if(dt.Rows[n]["Fax"]!=null && dt.Rows[n]["Fax"].ToString()!="")
					{
					model.Fax=dt.Rows[n]["Fax"].ToString();
					}
					if(dt.Rows[n]["PostalCode"]!=null && dt.Rows[n]["PostalCode"].ToString()!="")
					{
					model.PostalCode=dt.Rows[n]["PostalCode"].ToString();
					}
					if(dt.Rows[n]["ConstactPerson"]!=null && dt.Rows[n]["ConstactPerson"].ToString()!="")
					{
					model.ConstactPerson=dt.Rows[n]["ConstactPerson"].ToString();
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

