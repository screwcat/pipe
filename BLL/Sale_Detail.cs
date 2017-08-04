using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
    /// <summary>
    /// Sale_Detail
    /// </summary>
    public partial class Sale_Detail
    {
        private readonly ZhangWei.DAL.Sale_Detail dal = new ZhangWei.DAL.Sale_Detail();
        public Sale_Detail()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZhangWei.Model.Sale_Detail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.Sale_Detail model)
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
        public ZhangWei.Model.Sale_Detail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ZhangWei.Model.Sale_Detail GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "Sale_DetailModel-";
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
                catch { }
            }
            return (ZhangWei.Model.Sale_Detail)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhangWei.Model.Sale_Detail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhangWei.Model.Sale_Detail> DataTableToList(DataTable dt)
        {
            List<ZhangWei.Model.Sale_Detail> modelList = new List<ZhangWei.Model.Sale_Detail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhangWei.Model.Sale_Detail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZhangWei.Model.Sale_Detail();
                    if (dt.Rows[n]["Sale_ID"] != null && dt.Rows[n]["Sale_ID"].ToString() != "")
                    {
                        model.Sale_ID = int.Parse(dt.Rows[n]["Sale_ID"].ToString());
                    }
                    if (dt.Rows[n]["Product_ID"] != null && dt.Rows[n]["Product_ID"].ToString() != "")
                    {
                        model.Product_ID = int.Parse(dt.Rows[n]["Product_ID"].ToString());
                    }
                    if (dt.Rows[n]["SaleOrder_ID"] != null && dt.Rows[n]["SaleOrder_ID"].ToString() != "")
                    {
                        model.SaleOrder_ID = int.Parse(dt.Rows[n]["SaleOrder_ID"].ToString());
                    }
                    if (dt.Rows[n]["Quantity"] != null && dt.Rows[n]["Quantity"].ToString() != "")
                    {
                        model.Quantity = decimal.Parse(dt.Rows[n]["Quantity"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["Discount"] != null && dt.Rows[n]["Discount"].ToString() != "")
                    {
                        model.Discount = int.Parse(dt.Rows[n]["Discount"].ToString());
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

        public DataSet GetListDetail(Int32 Sale_ID)
        {
            return dal.GetListDetail(Sale_ID);
        }

        public DataSet GetDetailAll(Int32 Sale_ID)
        {
            return dal.GetDetailAll(Sale_ID);
        }

        /// <summary>
        /// 销售明细表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetSaleDefinite(string BeginDate, string EndDate)
        {
            return dal.GetSaleDefinite(BeginDate, EndDate);
        }
        /// <summary>
        /// 销售汇总表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetSaleGather(string BeginDate, string EndDate)
        {
            return dal.GetSaleGather(BeginDate, EndDate);
        }

        /// <summary>
        /// 生成销售汇总（按单号汇总）
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataSet GetGatherByList(string BeginDate, string EndDate)
        {
            return dal.GetGatherByList(BeginDate, EndDate);
        }

        public bool DeleteSaleDtl(Int32 Sale_ID)
        {
            return dal.DeleteSaleDtl(Sale_ID);
        }
		#endregion  Method
	}
}

