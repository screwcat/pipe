using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
	/// <summary>
	/// Employee
	/// </summary>
	public partial class Employee
	{
		private readonly ZhangWei.DAL.Employee dal=new ZhangWei.DAL.Employee();
		public Employee()
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
		public bool Exists(int Employee_ID)
		{
			return dal.Exists(Employee_ID);
		}

        /// <summary>
        /// 是否存在该记录，根据用户名
        /// </summary>
        public bool Exists(string UserName)
        {
            return dal.Exists(UserName);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZhangWei.Model.Employee model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ZhangWei.Model.Employee model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Employee_ID)
		{
			
			return dal.Delete(Employee_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Employee_IDlist )
		{
			return dal.DeleteList(Employee_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZhangWei.Model.Employee GetModel(int Employee_ID)
		{
			
			return dal.GetModel(Employee_ID);
		}


        /// <summary>
        /// 得到一个对象实体，根据用户名
        /// </summary>
        public ZhangWei.Model.Employee GetModelByUN(string UserName)
        {

            return dal.GetModelByUN(UserName);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ZhangWei.Model.Employee GetModelByCache(int Employee_ID)
		{
			
			string CacheKey = "EmployeeModel-" + Employee_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Employee_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZhangWei.Model.Employee)objModel;
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
		public List<ZhangWei.Model.Employee> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZhangWei.Model.Employee> DataTableToList(DataTable dt)
		{
			List<ZhangWei.Model.Employee> modelList = new List<ZhangWei.Model.Employee>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZhangWei.Model.Employee model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZhangWei.Model.Employee();
					if(dt.Rows[n]["Employee_ID"]!=null && dt.Rows[n]["Employee_ID"].ToString()!="")
					{
						model.Employee_ID=int.Parse(dt.Rows[n]["Employee_ID"].ToString());
					}
					if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
					{
					model.UserName=dt.Rows[n]["UserName"].ToString();
					}
					if(dt.Rows[n]["PassWord"]!=null && dt.Rows[n]["PassWord"].ToString()!="")
					{
					model.PassWord=dt.Rows[n]["PassWord"].ToString();
					}
					if(dt.Rows[n]["Dept_ID"]!=null && dt.Rows[n]["Dept_ID"].ToString()!="")
					{
						model.Dept_ID=int.Parse(dt.Rows[n]["Dept_ID"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Duty"]!=null && dt.Rows[n]["Duty"].ToString()!="")
					{
					model.Duty=dt.Rows[n]["Duty"].ToString();
					}
					if(dt.Rows[n]["Gender"]!=null && dt.Rows[n]["Gender"].ToString()!="")
					{
					model.Gender=dt.Rows[n]["Gender"].ToString();
					}
					if(dt.Rows[n]["BirthDate"]!=null && dt.Rows[n]["BirthDate"].ToString()!="")
					{
						model.BirthDate=DateTime.Parse(dt.Rows[n]["BirthDate"].ToString());
					}
					if(dt.Rows[n]["HireDate"]!=null && dt.Rows[n]["HireDate"].ToString()!="")
					{
						model.HireDate=DateTime.Parse(dt.Rows[n]["HireDate"].ToString());
					}
					if(dt.Rows[n]["MatureDate"]!=null && dt.Rows[n]["MatureDate"].ToString()!="")
					{
						model.MatureDate=DateTime.Parse(dt.Rows[n]["MatureDate"].ToString());
					}
					if(dt.Rows[n]["IdentityCard"]!=null && dt.Rows[n]["IdentityCard"].ToString()!="")
					{
					model.IdentityCard=dt.Rows[n]["IdentityCard"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
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

