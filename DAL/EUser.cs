using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:EUser
    /// </summary>
    public partial class EUser
    {
        public EUser()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserId", "EUser");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from EUser");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
                                        };
            parameters[0].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录，根据用户名
        /// </summary>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from EUser");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = UserName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZhangWei.Model.EUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EUser(");
            strSql.Append("UserName,PassWord,Email,Name,Sex,Age,ID_Card,Phone,MobilPhone,Address,Postalcode,Work,Income,Integral,CreateTime,LaseLogin)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@PassWord,@Email,@Name,@Sex,@Age,@ID_Card,@Phone,@MobilPhone,@Address,@Postalcode,@Work,@Income,@Integral,@CreateTime,@LaseLogin)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.Char,4),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@ID_Card", SqlDbType.NVarChar,18),
					new SqlParameter("@Phone", SqlDbType.NVarChar,30),
					new SqlParameter("@MobilPhone", SqlDbType.NVarChar,30),
					new SqlParameter("@Address", SqlDbType.NVarChar),
					new SqlParameter("@Postalcode", SqlDbType.NVarChar,10),
					new SqlParameter("@Work", SqlDbType.NVarChar,50),
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@Integral", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LaseLogin", SqlDbType.DateTime)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Age;
            parameters[6].Value = model.ID_Card;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.MobilPhone;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.Postalcode;
            parameters[11].Value = model.Work;
            parameters[12].Value = model.Income;
            parameters[13].Value = model.Integral;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.LaseLogin;

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
        public bool Update(ZhangWei.Model.EUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EUser set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("Email=@Email,");
            strSql.Append("Name=@Name,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Age=@Age,");
            strSql.Append("ID_Card=@ID_Card,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("MobilPhone=@MobilPhone,");
            strSql.Append("Address=@Address,");
            strSql.Append("Postalcode=@Postalcode,");
            strSql.Append("Work=@Work,");
            strSql.Append("Income=@Income,");
            strSql.Append("Integral=@Integral,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("LaseLogin=@LaseLogin");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.Char,4),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@ID_Card", SqlDbType.NVarChar,18),
					new SqlParameter("@Phone", SqlDbType.NVarChar,30),
					new SqlParameter("@MobilPhone", SqlDbType.NVarChar,30),
					new SqlParameter("@Address", SqlDbType.NVarChar),
					new SqlParameter("@Postalcode", SqlDbType.NVarChar,10),
					new SqlParameter("@Work", SqlDbType.NVarChar,50),
					new SqlParameter("@Income", SqlDbType.Decimal,9),
					new SqlParameter("@Integral", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LaseLogin", SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Age;
            parameters[6].Value = model.ID_Card;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.MobilPhone;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.Postalcode;
            parameters[11].Value = model.Work;
            parameters[12].Value = model.Income;
            parameters[13].Value = model.Integral;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.LaseLogin;
            parameters[16].Value = model.UserId;

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
        public bool Delete(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EUser ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
};
            parameters[0].Value = UserId;

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
        public bool DeleteList(string UserIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EUser ");
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
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
        public ZhangWei.Model.EUser GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,UserName,PassWord,Email,Name,Sex,Age,ID_Card,Phone,MobilPhone,Address,Postalcode,Work,Income,Integral,CreateTime,LaseLogin from EUser ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
};
            parameters[0].Value = UserId;

            ZhangWei.Model.EUser model = new ZhangWei.Model.EUser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserId"] != null && ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null && ds.Tables[0].Rows[0]["PassWord"].ToString() != "")
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Age"] != null && ds.Tables[0].Rows[0]["Age"].ToString() != "")
                {
                    model.Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ID_Card"] != null && ds.Tables[0].Rows[0]["ID_Card"].ToString() != "")
                {
                    model.ID_Card = ds.Tables[0].Rows[0]["ID_Card"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MobilPhone"] != null && ds.Tables[0].Rows[0]["MobilPhone"].ToString() != "")
                {
                    model.MobilPhone = ds.Tables[0].Rows[0]["MobilPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Postalcode"] != null && ds.Tables[0].Rows[0]["Postalcode"].ToString() != "")
                {
                    model.Postalcode = ds.Tables[0].Rows[0]["Postalcode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Work"] != null && ds.Tables[0].Rows[0]["Work"].ToString() != "")
                {
                    model.Work = ds.Tables[0].Rows[0]["Work"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Income"] != null && ds.Tables[0].Rows[0]["Income"].ToString() != "")
                {
                    model.Income = decimal.Parse(ds.Tables[0].Rows[0]["Income"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Integral"] != null && ds.Tables[0].Rows[0]["Integral"].ToString() != "")
                {
                    model.Integral = int.Parse(ds.Tables[0].Rows[0]["Integral"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"] != null && ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LaseLogin"] != null && ds.Tables[0].Rows[0]["LaseLogin"].ToString() != "")
                {
                    model.LaseLogin = DateTime.Parse(ds.Tables[0].Rows[0]["LaseLogin"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体，从用户名
        /// </summary>
        public ZhangWei.Model.EUser GetModelByUN(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,UserName,PassWord,Email,Name,Sex,Age,ID_Card,Phone,MobilPhone,Address,Postalcode,Work,Income,Integral,CreateTime,LaseLogin from EUser ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)
};
            parameters[0].Value = UserName;

            ZhangWei.Model.EUser model = new ZhangWei.Model.EUser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserId"] != null && ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null && ds.Tables[0].Rows[0]["PassWord"].ToString() != "")
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Age"] != null && ds.Tables[0].Rows[0]["Age"].ToString() != "")
                {
                    model.Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ID_Card"] != null && ds.Tables[0].Rows[0]["ID_Card"].ToString() != "")
                {
                    model.ID_Card = ds.Tables[0].Rows[0]["ID_Card"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MobilPhone"] != null && ds.Tables[0].Rows[0]["MobilPhone"].ToString() != "")
                {
                    model.MobilPhone = ds.Tables[0].Rows[0]["MobilPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Postalcode"] != null && ds.Tables[0].Rows[0]["Postalcode"].ToString() != "")
                {
                    model.Postalcode = ds.Tables[0].Rows[0]["Postalcode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Work"] != null && ds.Tables[0].Rows[0]["Work"].ToString() != "")
                {
                    model.Work = ds.Tables[0].Rows[0]["Work"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Income"] != null && ds.Tables[0].Rows[0]["Income"].ToString() != "")
                {
                    model.Income = decimal.Parse(ds.Tables[0].Rows[0]["Income"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Integral"] != null && ds.Tables[0].Rows[0]["Integral"].ToString() != "")
                {
                    model.Integral = int.Parse(ds.Tables[0].Rows[0]["Integral"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"] != null && ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LaseLogin"] != null && ds.Tables[0].Rows[0]["LaseLogin"].ToString() != "")
                {
                    model.LaseLogin = DateTime.Parse(ds.Tables[0].Rows[0]["LaseLogin"].ToString());
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
            strSql.Append("select UserId,UserName,PassWord,Email,Name,Sex,Age,ID_Card,Phone,MobilPhone,Address,Postalcode,Work,Income,Integral,CreateTime,LaseLogin ");
            strSql.Append(" FROM EUser ");
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
            strSql.Append(" UserId,UserName,PassWord,Email,Name,Sex,Age,ID_Card,Phone,MobilPhone,Address,Postalcode,Work,Income,Integral,CreateTime,LaseLogin ");
            strSql.Append(" FROM EUser ");
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
            parameters[0].Value = "EUser";
            parameters[1].Value = "UserId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

