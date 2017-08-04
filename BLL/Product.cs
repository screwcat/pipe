using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
    /// <summary>
    /// Product
    /// </summary>
    public partial class Product
    {
        private readonly ZhangWei.DAL.Product dal = new ZhangWei.DAL.Product();
        public Product()
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
        public bool Exists(int Product_ID)
        {
            return dal.Exists(Product_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.Product model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.Product model)
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
        public bool DeleteList(string Product_IDlist)
        {
            return dal.DeleteList(Product_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhangWei.Model.Product GetModel(int Product_ID)
        {

            return dal.GetModel(Product_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ZhangWei.Model.Product GetModelByCache(int Product_ID)
        {

            string CacheKey = "ProductModel-" + Product_ID;
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
                catch { }
            }
            return (ZhangWei.Model.Product)objModel;
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
        public List<ZhangWei.Model.Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhangWei.Model.Product> DataTableToList(DataTable dt)
        {
            List<ZhangWei.Model.Product> modelList = new List<ZhangWei.Model.Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhangWei.Model.Product model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZhangWei.Model.Product();
                    if (dt.Rows[n]["Product_ID"] != null && dt.Rows[n]["Product_ID"].ToString() != "")
                    {
                        model.Product_ID = int.Parse(dt.Rows[n]["Product_ID"].ToString());
                    }
                    if (dt.Rows[n]["ProductList_ID"] != null && dt.Rows[n]["ProductList_ID"].ToString() != "")
                    {
                        model.ProductList_ID = int.Parse(dt.Rows[n]["ProductList_ID"].ToString());
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["shortname"] != null && dt.Rows[n]["shortname"].ToString() != "")
                    {
                        model.shortname = dt.Rows[n]["shortname"].ToString();
                    }
                    if (dt.Rows[n]["spell"] != null && dt.Rows[n]["spell"].ToString() != "")
                    {
                        model.spell = dt.Rows[n]["spell"].ToString();
                    }
                    if (dt.Rows[n]["s_spell"] != null && dt.Rows[n]["s_spell"].ToString() != "")
                    {
                        model.s_spell = dt.Rows[n]["s_spell"].ToString();
                    }
                    if (dt.Rows[n]["ProductSpec_ID"] != null && dt.Rows[n]["ProductSpec_ID"].ToString() != "")
                    {
                        model.ProductSpec_ID = int.Parse(dt.Rows[n]["ProductSpec_ID"].ToString());
                    }
                    if (dt.Rows[n]["ProductUnit_ID"] != null && dt.Rows[n]["ProductUnit_ID"].ToString() != "")
                    {
                        model.ProductUnit_ID = int.Parse(dt.Rows[n]["ProductUnit_ID"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["Offering_Price"] != null && dt.Rows[n]["Offering_Price"].ToString() != "")
                    {
                        model.Offering_Price = decimal.Parse(dt.Rows[n]["Offering_Price"].ToString());
                    }
                    if (dt.Rows[n]["Employee_ID"] != null && dt.Rows[n]["Employee_ID"].ToString() != "")
                    {
                        model.Employee_ID = int.Parse(dt.Rows[n]["Employee_ID"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"] != null && dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
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

        public DataSet GetProList(string strWhere)
        {
            return dal.GetProList(strWhere);
        }


        /// <summary>
        /// 根据条件字符串，获取商品详细列表，能分页的
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProListPage(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetProListPage(PageSize, PageIndex, strWhere);
        }


        /// <summary>
        /// 根据条件字符串，获取商品详细列表，能分页的，带库存的
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProListPageAll(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetProListPageAll(PageSize, PageIndex, strWhere);
        }

        public DataSet GetListFromView(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetListFromView(PageSize, PageIndex, strWhere);
        }

        public DataSet GetStockFromView(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetStockFromView(PageSize, PageIndex, strWhere);
        }
        
        #endregion  Method
    }
}

