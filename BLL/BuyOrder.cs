using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
    /// <summary>
    /// BuyOrder
    /// </summary>
    public partial class BuyOrder
    {
        private readonly ZhangWei.DAL.BuyOrder dal = new ZhangWei.DAL.BuyOrder();
        public BuyOrder()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.BuyOrder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.BuyOrder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BuyOrder_ID)
        {

            return dal.Delete(BuyOrder_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string BuyOrder_IDlist)
        {
            return dal.DeleteList(BuyOrder_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhangWei.Model.BuyOrder GetModel(int BuyOrder_ID)
        {

            return dal.GetModel(BuyOrder_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ZhangWei.Model.BuyOrder GetModelByCache(int BuyOrder_ID)
        {

            string CacheKey = "BuyOrderModel-" + BuyOrder_ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(BuyOrder_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZhangWei.Model.BuyOrder)objModel;
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
        public List<ZhangWei.Model.BuyOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhangWei.Model.BuyOrder> DataTableToList(DataTable dt)
        {
            List<ZhangWei.Model.BuyOrder> modelList = new List<ZhangWei.Model.BuyOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhangWei.Model.BuyOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZhangWei.Model.BuyOrder();
                    if (dt.Rows[n]["BuyOrder_ID"] != null && dt.Rows[n]["BuyOrder_ID"].ToString() != "")
                    {
                        model.BuyOrder_ID = int.Parse(dt.Rows[n]["BuyOrder_ID"].ToString());
                    }
                    if (dt.Rows[n]["WriteDate"] != null && dt.Rows[n]["WriteDate"].ToString() != "")
                    {
                        model.WriteDate = DateTime.Parse(dt.Rows[n]["WriteDate"].ToString());
                    }
                    if (dt.Rows[n]["InsureDate"] != null && dt.Rows[n]["InsureDate"].ToString() != "")
                    {
                        model.InsureDate = DateTime.Parse(dt.Rows[n]["InsureDate"].ToString());
                    }
                    if (dt.Rows[n]["EndDate"] != null && dt.Rows[n]["EndDate"].ToString() != "")
                    {
                        model.EndDate = DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
                    }
                    if (dt.Rows[n]["Dept_ID"] != null && dt.Rows[n]["Dept_ID"].ToString() != "")
                    {
                        model.Dept_ID = int.Parse(dt.Rows[n]["Dept_ID"].ToString());
                    }
                    if (dt.Rows[n]["Supplier_ID"] != null && dt.Rows[n]["Supplier_ID"].ToString() != "")
                    {
                        model.Supplier_ID = int.Parse(dt.Rows[n]["Supplier_ID"].ToString());
                    }
                    if (dt.Rows[n]["Employee_ID"] != null && dt.Rows[n]["Employee_ID"].ToString() != "")
                    {
                        model.Employee_ID = int.Parse(dt.Rows[n]["Employee_ID"].ToString());
                    }
                    if (dt.Rows[n]["Produced"] != null && dt.Rows[n]["Produced"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Produced"].ToString() == "1") || (dt.Rows[n]["Produced"].ToString().ToLower() == "true"))
                        {
                            model.Produced = true;
                        }
                        else
                        {
                            model.Produced = false;
                        }
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

        #endregion  Method
    }
}

