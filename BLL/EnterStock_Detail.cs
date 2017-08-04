using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
    /// <summary>
    /// EnterStock_Detail
    /// </summary>
    public partial class EnterStock_Detail
    {
        private readonly ZhangWei.DAL.EnterStock_Detail dal = new ZhangWei.DAL.EnterStock_Detail();
        public EnterStock_Detail()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ZhangWei.Model.EnterStock_Detail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.EnterStock_Detail model)
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
        public ZhangWei.Model.EnterStock_Detail GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            return dal.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ZhangWei.Model.EnterStock_Detail GetModelByCache()
        {
            //该表无主键信息，请自定义主键/条件字段
            string CacheKey = "EnterStock_DetailModel-";
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
            return (ZhangWei.Model.EnterStock_Detail)objModel;
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
        public List<ZhangWei.Model.EnterStock_Detail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhangWei.Model.EnterStock_Detail> DataTableToList(DataTable dt)
        {
            List<ZhangWei.Model.EnterStock_Detail> modelList = new List<ZhangWei.Model.EnterStock_Detail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhangWei.Model.EnterStock_Detail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZhangWei.Model.EnterStock_Detail();
                    if (dt.Rows[n]["EnterStock_ID"] != null && dt.Rows[n]["EnterStock_ID"].ToString() != "")
                    {
                        model.EnterStock_ID = int.Parse(dt.Rows[n]["EnterStock_ID"].ToString());
                    }
                    if (dt.Rows[n]["Product_ID"] != null && dt.Rows[n]["Product_ID"].ToString() != "")
                    {
                        model.Product_ID = int.Parse(dt.Rows[n]["Product_ID"].ToString());
                    }
                    if (dt.Rows[n]["Quantity"] != null && dt.Rows[n]["Quantity"].ToString() != "")
                    {
                        model.Quantity = decimal.Parse(dt.Rows[n]["Quantity"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["HaveInvoice"] != null && dt.Rows[n]["HaveInvoice"].ToString() != "")
                    {
                        if ((dt.Rows[n]["HaveInvoice"].ToString() == "1") || (dt.Rows[n]["HaveInvoice"].ToString().ToLower() == "true"))
                        {
                            model.HaveInvoice = true;
                        }
                        else
                        {
                            model.HaveInvoice = false;
                        }
                    }
                    if (dt.Rows[n]["InvoiceNum"] != null && dt.Rows[n]["InvoiceNum"].ToString() != "")
                    {
                        model.InvoiceNum = dt.Rows[n]["InvoiceNum"].ToString();
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


        /// <summary>
        /// 获取带商品资料的入库详单
        /// </summary>
        /// <param name="EnterStock_ID"></param>
        /// <returns></returns>
        public DataSet GetEnterStock(Int32 EnterStock_ID)
        {
            return dal.GetEnterStock(EnterStock_ID);
        }

        /// <summary>
        /// 删除指指定单号的详单
        /// </summary>
        /// <param name="Sale_ID"></param>
        /// <returns></returns>
        public bool DeleteEnterStock(Int32 EnterStock_ID)
        {
            return dal.DeleteEnterStock(EnterStock_ID);
        }
		#endregion  Method
	}
}

