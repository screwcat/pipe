using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZhangWei.DAL
{
    /// <summary>
    /// 数据访问类:Employee
    /// </summary>
    public partial class Employee
    {
        public Employee()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Employee_ID", "Employee");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Employee_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Employee");
            strSql.Append(" where Employee_ID=@Employee_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Employee_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录，根据用户名
        /// </summary>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Employee");
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
        public int Add(ZhangWei.Model.Employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Employee(");
            strSql.Append("UserName,PassWord,Dept_ID,Name,Duty,Gender,BirthDate,HireDate,MatureDate,IdentityCard,Address,Phone,Email)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@PassWord,@Dept_ID,@Name,@Duty,@Gender,@BirthDate,@HireDate,@MatureDate,@IdentityCard,@Address,@Phone,@Email)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Duty", SqlDbType.VarChar,20),
					new SqlParameter("@Gender", SqlDbType.VarChar,6),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@HireDate", SqlDbType.DateTime),
					new SqlParameter("@MatureDate", SqlDbType.DateTime),
					new SqlParameter("@IdentityCard", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Phone", SqlDbType.VarChar,25),
					new SqlParameter("@Email", SqlDbType.VarChar,30)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Dept_ID;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Duty;
            parameters[5].Value = model.Gender;
            parameters[6].Value = model.BirthDate;
            parameters[7].Value = model.HireDate;
            parameters[8].Value = model.MatureDate;
            parameters[9].Value = model.IdentityCard;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.Phone;
            parameters[12].Value = model.Email;

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
        public bool Update(ZhangWei.Model.Employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Employee set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("Dept_ID=@Dept_ID,");
            strSql.Append("Name=@Name,");
            strSql.Append("Duty=@Duty,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("BirthDate=@BirthDate,");
            strSql.Append("HireDate=@HireDate,");
            strSql.Append("MatureDate=@MatureDate,");
            strSql.Append("IdentityCard=@IdentityCard,");
            strSql.Append("Address=@Address,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email");
            strSql.Append(" where Employee_ID=@Employee_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Dept_ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Duty", SqlDbType.VarChar,20),
					new SqlParameter("@Gender", SqlDbType.VarChar,6),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@HireDate", SqlDbType.DateTime),
					new SqlParameter("@MatureDate", SqlDbType.DateTime),
					new SqlParameter("@IdentityCard", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,250),
					new SqlParameter("@Phone", SqlDbType.VarChar,25),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Dept_ID;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Duty;
            parameters[5].Value = model.Gender;
            parameters[6].Value = model.BirthDate;
            parameters[7].Value = model.HireDate;
            parameters[8].Value = model.MatureDate;
            parameters[9].Value = model.IdentityCard;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.Phone;
            parameters[12].Value = model.Email;
            parameters[13].Value = model.Employee_ID;

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
        public bool Delete(int Employee_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
            strSql.Append(" where Employee_ID=@Employee_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Employee_ID;

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
        public bool DeleteList(string Employee_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
            strSql.Append(" where Employee_ID in (" + Employee_IDlist + ")  ");
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
        public ZhangWei.Model.Employee GetModel(int Employee_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Employee_ID,UserName,PassWord,Dept_ID,Name,Duty,Gender,BirthDate,HireDate,MatureDate,IdentityCard,Address,Phone,Email from Employee ");
            strSql.Append(" where Employee_ID=@Employee_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Employee_ID", SqlDbType.Int,4)
};
            parameters[0].Value = Employee_ID;

            ZhangWei.Model.Employee model = new ZhangWei.Model.Employee();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Employee_ID"] != null && ds.Tables[0].Rows[0]["Employee_ID"].ToString() != "")
                {
                    model.Employee_ID = int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null && ds.Tables[0].Rows[0]["PassWord"].ToString() != "")
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Dept_ID"] != null && ds.Tables[0].Rows[0]["Dept_ID"].ToString() != "")
                {
                    model.Dept_ID = int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Duty"] != null && ds.Tables[0].Rows[0]["Duty"].ToString() != "")
                {
                    model.Duty = ds.Tables[0].Rows[0]["Duty"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gender"] != null && ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BirthDate"] != null && ds.Tables[0].Rows[0]["BirthDate"].ToString() != "")
                {
                    model.BirthDate = DateTime.Parse(ds.Tables[0].Rows[0]["BirthDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HireDate"] != null && ds.Tables[0].Rows[0]["HireDate"].ToString() != "")
                {
                    model.HireDate = DateTime.Parse(ds.Tables[0].Rows[0]["HireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MatureDate"] != null && ds.Tables[0].Rows[0]["MatureDate"].ToString() != "")
                {
                    model.MatureDate = DateTime.Parse(ds.Tables[0].Rows[0]["MatureDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IdentityCard"] != null && ds.Tables[0].Rows[0]["IdentityCard"].ToString() != "")
                {
                    model.IdentityCard = ds.Tables[0].Rows[0]["IdentityCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体，根据用户名
        /// </summary>
        public ZhangWei.Model.Employee GetModelByUN(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Employee_ID,UserName,PassWord,Dept_ID,Name,Duty,Gender,BirthDate,HireDate,MatureDate,IdentityCard,Address,Phone,Email from Employee ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)
};
            parameters[0].Value = UserName;

            ZhangWei.Model.Employee model = new ZhangWei.Model.Employee();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Employee_ID"] != null && ds.Tables[0].Rows[0]["Employee_ID"].ToString() != "")
                {
                    model.Employee_ID = int.Parse(ds.Tables[0].Rows[0]["Employee_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null && ds.Tables[0].Rows[0]["PassWord"].ToString() != "")
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Dept_ID"] != null && ds.Tables[0].Rows[0]["Dept_ID"].ToString() != "")
                {
                    model.Dept_ID = int.Parse(ds.Tables[0].Rows[0]["Dept_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Duty"] != null && ds.Tables[0].Rows[0]["Duty"].ToString() != "")
                {
                    model.Duty = ds.Tables[0].Rows[0]["Duty"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gender"] != null && ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    model.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BirthDate"] != null && ds.Tables[0].Rows[0]["BirthDate"].ToString() != "")
                {
                    model.BirthDate = DateTime.Parse(ds.Tables[0].Rows[0]["BirthDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HireDate"] != null && ds.Tables[0].Rows[0]["HireDate"].ToString() != "")
                {
                    model.HireDate = DateTime.Parse(ds.Tables[0].Rows[0]["HireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MatureDate"] != null && ds.Tables[0].Rows[0]["MatureDate"].ToString() != "")
                {
                    model.MatureDate = DateTime.Parse(ds.Tables[0].Rows[0]["MatureDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IdentityCard"] != null && ds.Tables[0].Rows[0]["IdentityCard"].ToString() != "")
                {
                    model.IdentityCard = ds.Tables[0].Rows[0]["IdentityCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
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
            strSql.Append("select Employee_ID,UserName,PassWord,Dept_ID,Name,Duty,Gender,BirthDate,HireDate,MatureDate,IdentityCard,Address,Phone,Email ");
            strSql.Append(" FROM Employee ");
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
            strSql.Append(" Employee_ID,UserName,PassWord,Dept_ID,Name,Duty,Gender,BirthDate,HireDate,MatureDate,IdentityCard,Address,Phone,Email ");
            strSql.Append(" FROM Employee ");
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
            parameters[0].Value = "Employee";
            parameters[1].Value = "Employee_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

