using System.Data;
using System.Data.SqlClient;

namespace LTP.Accounts.Data
{
    public class PermissionCategory : DbObject
    {
        public PermissionCategory(string newConnectionString)
            : base(newConnectionString)
        {
        }

        public int Create(string description)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = description;
            return base.RunProcedure("sp_Accounts_CreatePermissionCategory", parameters, out num);
        }
        public bool Delete(int id)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = id;
            base.RunProcedure("sp_Accounts_DeletePermissionCategory", parameters, out num);
            return (num == 1);
        }
        public DataSet GetCategoryList()
        {
            using (DataSet set = base.RunProcedure("sp_Accounts_GetPermissionCategories", new IDataParameter[0], "Categories"))
            {
                return set;
            }
        }
        public DataSet GetPermissionsInCategory(int categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = categoryId;
            using (DataSet set = base.RunProcedure("sp_Accounts_GetPermissionsInCategory", parameters, "Categories"))
            {
                return set;
            }
        }
        public DataRow Retrieve(int categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = categoryId;
            using (DataSet set = base.RunProcedure("sp_Accounts_GetPermissionCategoryDetails", parameters, "Categories"))
            {
                return set.Tables[0].Rows[0];
            }
        }

 

 

 

 

 

 

 

    }
}
