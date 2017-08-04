using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class sysdiagrams
	{
		private readonly ZhangWei.DAL.sysdiagrams dal=new ZhangWei.DAL.sysdiagrams();
		public sysdiagrams()
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
		public bool Exists(int diagram_id)
		{
			return dal.Exists(diagram_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.sysdiagrams model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.sysdiagrams model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int diagram_id)
		{
			
			return dal.Delete(diagram_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string diagram_idlist )
		{
			return dal.DeleteList(diagram_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.sysdiagrams GetModel(int diagram_id)
		{
			
			return dal.GetModel(diagram_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.sysdiagrams GetModelByCache(int diagram_id)
		{
			
			string CacheKey = "sysdiagramsModel-" + diagram_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(diagram_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.sysdiagrams)objModel;
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
		public List<ZhangWei.Model.sysdiagrams> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.sysdiagrams> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.sysdiagrams> modelList = new List<ZhangWei.Model.sysdiagrams>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.sysdiagrams model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.sysdiagrams();
					if(dt.Rows[n]["name"]!=null && dt.Rows[n]["name"].ToString()!="")
					{
					model.name=dt.Rows[n]["name"].ToString();
					}
					if(dt.Rows[n]["principal_id"]!=null && dt.Rows[n]["principal_id"].ToString()!="")
					{
						model.principal_id=int.Parse(dt.Rows[n]["principal_id"].ToString());
					}
					if(dt.Rows[n]["diagram_id"]!=null && dt.Rows[n]["diagram_id"].ToString()!="")
					{
						model.diagram_id=int.Parse(dt.Rows[n]["diagram_id"].ToString());
					}
					if(dt.Rows[n]["version"]!=null && dt.Rows[n]["version"].ToString()!="")
					{
						model.version=int.Parse(dt.Rows[n]["version"].ToString());
					}
					if(dt.Rows[n]["definition"]!=null && dt.Rows[n]["definition"].ToString()!="")
					{
						model.definition=(byte[])dt.Rows[n]["definition"];
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

