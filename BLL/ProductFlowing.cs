using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.Common;
using ZhangWei.Model;
namespace ZhangWei.BLL
{
    public partial class ProductFlowing
    {
        private readonly ZhangWei.DAL.ProductFlowing dal = new ZhangWei.DAL.ProductFlowing();
        public DataSet GetSale(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            return dal.GetSale(Product_ID, StartDate, EndDate);
        }
        public DataSet GetBackSale(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            return dal.GetBackSale(Product_ID, StartDate, EndDate);
        }
        public DataSet GetEnterStock(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            return dal.GetEnterStock(Product_ID, StartDate, EndDate);
        }
        public DataSet GetBackStock(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            return dal.GetBackStock(Product_ID, StartDate, EndDate);
        }
        public DataTable GetFlowing(Int32 Product_ID, DateTime StartDate, DateTime EndDate)
        {
            return dal.GetFlowing(Product_ID, StartDate, EndDate);
        }
    }
}
