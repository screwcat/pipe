using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
    /// <summary>
    /// StockPile
    /// </summary>
    public partial class StockPile
    {
        private readonly ZhangWei.DAL.StockPile dal = new ZhangWei.DAL.StockPile();
        public StockPile()
        { }
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
        public bool Exists(int StockPile_ID)
        {
            return dal.Exists(StockPile_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.StockPile model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.StockPile model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int StockPile_ID)
        {

            return dal.Delete(StockPile_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string StockPile_IDlist)
        {
            return dal.DeleteList(StockPile_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhangWei.Model.StockPile GetModel(int StockPile_ID)
        {

            return dal.GetModel(StockPile_ID);
        }

        /// <summary>
        /// 根据商品ID和仓库ID得到一个对象实体
        /// </summary>
        /// <param name="Product_ID">商品ID</param>
        /// <returns></returns>
        public ZhangWei.Model.StockPile GetModelByProId(int Product_ID, int StoreHouse_ID)
        {
            return dal.GetModelByProId(Product_ID, StoreHouse_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ZhangWei.Model.StockPile GetModelByCache(int StockPile_ID)
        {

            string CacheKey = "StockPileModel-" + StockPile_ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(StockPile_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZhangWei.Model.StockPile)objModel;
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
        public List<ZhangWei.Model.StockPile> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhangWei.Model.StockPile> DataTableToList(DataTable dt)
        {
            List<ZhangWei.Model.StockPile> modelList = new List<ZhangWei.Model.StockPile>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhangWei.Model.StockPile model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZhangWei.Model.StockPile();
                    if (dt.Rows[n]["StockPile_ID"] != null && dt.Rows[n]["StockPile_ID"].ToString() != "")
                    {
                        model.StockPile_ID = int.Parse(dt.Rows[n]["StockPile_ID"].ToString());
                    }
                    if (dt.Rows[n]["Dept_ID"] != null && dt.Rows[n]["Dept_ID"].ToString() != "")
                    {
                        model.Dept_ID = int.Parse(dt.Rows[n]["Dept_ID"].ToString());
                    }
                    if (dt.Rows[n]["StoreHouse_ID"] != null && dt.Rows[n]["StoreHouse_ID"].ToString() != "")
                    {
                        model.StoreHouse_ID = int.Parse(dt.Rows[n]["StoreHouse_ID"].ToString());
                    }
                    if (dt.Rows[n]["Product_ID"] != null && dt.Rows[n]["Product_ID"].ToString() != "")
                    {
                        model.Product_ID = int.Parse(dt.Rows[n]["Product_ID"].ToString());
                    }
                    if (dt.Rows[n]["FirstEnterDate"] != null && dt.Rows[n]["FirstEnterDate"].ToString() != "")
                    {
                        model.FirstEnterDate = DateTime.Parse(dt.Rows[n]["FirstEnterDate"].ToString());
                    }
                    if (dt.Rows[n]["LastLeaveDate"] != null && dt.Rows[n]["LastLeaveDate"].ToString() != "")
                    {
                        model.LastLeaveDate = DateTime.Parse(dt.Rows[n]["LastLeaveDate"].ToString());
                    }
                    if (dt.Rows[n]["Quantity"] != null && dt.Rows[n]["Quantity"].ToString() != "")
                    {
                        model.Quantity = decimal.Parse(dt.Rows[n]["Quantity"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
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

        public DataSet CheckStock(Int32 StoreHouse_ID)
        {
            return dal.CheckStock(StoreHouse_ID);
        }


		#endregion  Method
	}
}

