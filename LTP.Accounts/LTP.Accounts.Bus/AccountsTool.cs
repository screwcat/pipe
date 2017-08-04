using System.Data;
using LTP.Accounts.Data;
	
namespace LTP.Accounts.Bus
{
    public class AccountsTool
    {
        public static DataSet GetAllCategories()
        {
            PermissionCategory category = new PermissionCategory(PubConstant.ConnectionString);
            return category.GetCategoryList();
        }

        public static DataSet GetAllPermissions()
        {
            Permission permission = new Permission(PubConstant.ConnectionString);
            return permission.GetPermissionList();
        }


        public static DataSet GetPermissionsByCategory(int categoryID)
        {
            PermissionCategory category = new PermissionCategory(PubConstant.ConnectionString);
            return category.GetPermissionsInCategory(categoryID);
        }

        public static DataSet GetRoleList()
        {            
            Data.Role role = new Data.Role(PubConstant.ConnectionString);
            return role.GetRoleList();
        }

 

    }
}
