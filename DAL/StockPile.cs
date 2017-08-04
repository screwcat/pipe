using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:StockPile
    /// </summary>
    public partial class StockPile
    {
        public StockPile()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("StockPile_ID", "StockPile");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StockPile_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockPile");
            strSql.Append(" where StockPile_ID=@StockPile_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockPile_ID", SqlDbType.Int,4)
};
            parameters[0].Value = StockPile_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.StockPile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockPile(");
            strSql.Append("Dept_ID,StoreHouse_ID,Product_ID,FirstEnterDate,LastLeaveDate,Quantity,Price)");
            strSql.Append(" values (");
            strSql.Append("@Dept_ID,@StoreHouse_ID,@Product_ID,@FirstEnterDate,@LastLeaveDate,@Quantity,@Price)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@FirstEnterDate", SqlDbType.DateTime),
					new SqlParameter("@LastLeaveDate", SqlDbType.DateTime),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8)};
            parameters[0].Value = model.Dept_ID;
            parameters[1].Value = model.StoreHouse_ID;
            parameters[2].Value = model.Product_ID;
            parameters[3].Value = model.FirstEnterDate;
            parameters[4].Value = model.LastLeaveDate;
            parameters[5].Value = model.Quantity;
            parameters[6].Value = model.Price;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZhangWei.Model.StockPile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockPile set ");
            strSql.Append("Dept_ID=@Dept_ID,");
            strSql.Append("StoreHouse_ID=@StoreHouse_ID,");
            strSql.Append("Product_ID=@Product_ID,");
            strSql.Append("FirstEnterDate=@FirstEnterDate,");
            strSql.Append("LastLeaveDate=@LastLeaveDate,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Price=@Price");
            strSql.Append(" where StockPile_ID=@StockPile_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@StoreHouse_ID", SqlDbType.Int,4),
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
					new SqlParameter("@FirstEnterDate", SqlDbType.DateTime),
					new SqlParameter("@LastLeaveDate", SqlDbType.DateTime),
					new SqlParameter("@Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@StockPile_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Dept_ID;
            parameters[1].Value = model.StoreHouse_ID;
            parameters[2].Value = model.Product_ID;
            parameters[3].Value = model.FirstEnterDate;
            parameters[4].Value = model.LastLeaveDate;
            parameters[5].Value = model.Quantity;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.StockPile_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int StockPile_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockPile ");
            strSql.Append(" where StockPile_ID=@StockPile_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockPile_ID", SqlDbType.Int,4)
};
            parameters[0].Value = StockPile_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string StockPile_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockPile ");
            strSql.Append(" where StockPile_ID in (" + StockPile_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhangWei.Model.StockPile GetModel(int StockPile_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockPile_ID,Dept_ID,StoreHouse_ID,Product_ID,FirstEnterDate,LastLeaveDate,Quantity,Price from StockPile ");
            strSql.Append(" where StockPile_ID=@StockPile_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockPile_ID", SqlDbType.Int,4)
};
            parameters[0].Value = StockPile_ID;

            ZhangWei.Model.StockPile model = new ZhangWei.Model.StockPile();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockPile_ID"] != null && ds.Tables[0].Rows[0]["StockPile_ID"].ToString() != "")
                {
                    model.StockPile_ID = int.Parse(ds.Tables[0].Rows[0]["StockPile_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dept_ID"] != null && ds.Tables[0].Rows[0]["Dept_ID"].ToString() != "")
                {
                    model.Dept_ID = int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreHouse_ID"] != null && ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString() != "")
                {
                    model.StoreHouse_ID = int.Parse(ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Product_ID"] != null && ds.Tables[0].Rows[0]["Product_ID"].ToString() != "")
                {
                    model.Product_ID = int.Parse(ds.Tables[0].Rows[0]["Product_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FirstEnterDate"] != null && ds.Tables[0].Rows[0]["FirstEnterDate"].ToString() != "")
                {
                    model.FirstEnterDate = DateTime.Parse(ds.Tables[0].Rows[0]["FirstEnterDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLeaveDate"] != null && ds.Tables[0].Rows[0]["LastLeaveDate"].ToString() != "")
                {
                    model.LastLeaveDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastLeaveDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"] != null && ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = decimal.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据商品ID和仓库ID得到一个对象实体
        /// </summary>
        /// <param name="Product_ID"></param>
        /// <returns></returns>
        public ZhangWei.Model.StockPile GetModelByProId(int Product_ID, int StoreHouse_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockPile_ID,Dept_ID,StoreHouse_ID,Product_ID,FirstEnterDate,LastLeaveDate,Quantity,Price from StockPile ");
            strSql.Append(" where Product_ID=@Product_ID AND StoreHouse_ID = @StoreHouse_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Product_ID", SqlDbType.Int,4),
                    new SqlParameter("@StoreHouse_ID",SqlDbType.Int,4)
};
            parameters[0].Value = Product_ID;
            parameters[1].Value = StoreHouse_ID;

            ZhangWei.Model.StockPile model = new ZhangWei.Model.StockPile();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StockPile_ID"] != null && ds.Tables[0].Rows[0]["StockPile_ID"].ToString() != "")
                {
                    model.StockPile_ID = int.Parse(ds.Tables[0].Rows[0]["StockPile_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dept_ID"] != null && ds.Tables[0].Rows[0]["Dept_ID"].ToString() != "")
                {
                    model.Dept_ID = int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StoreHouse_ID"] != null && ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString() != "")
                {
                    model.StoreHouse_ID = int.Parse(ds.Tables[0].Rows[0]["StoreHouse_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Product_ID"] != null && ds.Tables[0].Rows[0]["Product_ID"].ToString() != "")
                {
                    model.Product_ID = int.Parse(ds.Tables[0].Rows[0]["Product_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FirstEnterDate"] != null && ds.Tables[0].Rows[0]["FirstEnterDate"].ToString() != "")
                {
                    model.FirstEnterDate = DateTime.Parse(ds.Tables[0].Rows[0]["FirstEnterDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLeaveDate"] != null && ds.Tables[0].Rows[0]["LastLeaveDate"].ToString() != "")
                {
                    model.LastLeaveDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastLeaveDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"] != null && ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = decimal.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StockPile_ID,Dept_ID,StoreHouse_ID,Product_ID,FirstEnterDate,LastLeaveDate,Quantity,Price ");
            strSql.Append(" FROM StockPile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" StockPile_ID,Dept_ID,StoreHouse_ID,Product_ID,FirstEnterDate,LastLeaveDate,Quantity,Price ");
            strSql.Append(" FROM StockPile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "StockPile";
            parameters[1].Value = "StockPile_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


        /// <summary>
        /// 生成库存盘点（从视图读取）
        /// </summary>
        /// <returns></returns>
        public DataSet CheckStock(Int32 StoreHouse_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CheckStock");
            if (StoreHouse_ID != 0)
            {
                strSql.Append(" where StoreHouse_ID = " + StoreHouse_ID);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

