using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
    /// <summary>
    /// BackSale
    /// </summary>
    public partial class BackSale
    {
        private readonly ZhangWei.DAL.BackSale dal = new ZhangWei.DAL.BackSale();
        public BackSale()
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
        public bool Exists(int BackSale_ID)
        {
            return dal.Exists(BackSale_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.BackSale model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.BackSale model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BackSale_ID)
        {

            return dal.Delete(BackSale_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string BackSale_IDlist)
        {
            return dal.DeleteList(BackSale_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhangWei.Model.BackSale GetModel(int BackSale_ID)
        {

            return dal.GetModel(BackSale_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ZhangWei.Model.BackSale GetModelByCache(int BackSale_ID)
        {

            string CacheKey = "BackSaleModel-" + BackSale_ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(BackSale_ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZhangWei.Model.BackSale)objModel;
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
        public List<ZhangWei.Model.BackSale> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZhangWei.Model.BackSale> DataTableToList(DataTable dt)
        {
            List<ZhangWei.Model.BackSale> modelList = new List<ZhangWei.Model.BackSale>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZhangWei.Model.BackSale model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZhangWei.Model.BackSale();
                    if (dt.Rows[n]["BackSale_ID"] != null && dt.Rows[n]["BackSale_ID"].ToString() != "")
                    {
                        model.BackSale_ID = int.Parse(dt.Rows[n]["BackSale_ID"].ToString());
                    }
                    if (dt.Rows[n]["BackDate"] != null && dt.Rows[n]["BackDate"].ToString() != "")
                    {
                        model.BackDate = DateTime.Parse(dt.Rows[n]["BackDate"].ToString());
                    }
                    if (dt.Rows[n]["Dept_ID"] != null && dt.Rows[n]["Dept_ID"].ToString() != "")
                    {
                        model.Dept_ID = int.Parse(dt.Rows[n]["Dept_ID"].ToString());
                    }
                    if (dt.Rows[n]["StoreHouse_ID"] != null && dt.Rows[n]["StoreHouse_ID"].ToString() != "")
                    {
                        model.StoreHouse_ID = int.Parse(dt.Rows[n]["StoreHouse_ID"].ToString());
                    }
                    if (dt.Rows[n]["Employee_ID"] != null && dt.Rows[n]["Employee_ID"].ToString() != "")
                    {
                        model.Employee_ID = int.Parse(dt.Rows[n]["Employee_ID"].ToString());
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["Address"] != null && dt.Rows[n]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[n]["Address"].ToString();
                    }
                    if (dt.Rows[n]["Account"] != null && dt.Rows[n]["Account"].ToString() != "")
                    {
                        model.Account = dt.Rows[n]["Account"].ToString();
                    }
                    if (dt.Rows[n]["GatheringWay"] != null && dt.Rows[n]["GatheringWay"].ToString() != "")
                    {
                        model.GatheringWay = dt.Rows[n]["GatheringWay"].ToString();
                    }
                    if (dt.Rows[n]["Customer"] != null && dt.Rows[n]["Customer"].ToString() != "")
                    {
                        model.Customer = int.Parse(dt.Rows[n]["Customer"].ToString());
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

