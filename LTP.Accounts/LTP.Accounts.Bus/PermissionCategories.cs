using LTP.Accounts.Data;

namespace LTP.Accounts.Bus
{
    public class PermissionCategories

    {
        public int Create(string description)
        {
            PermissionCategory category = new PermissionCategory(PubConstant.ConnectionString);
            return category.Create(description);
        }
        public bool Delete(int pID)
        {
            PermissionCategory category = new PermissionCategory(PubConstant.ConnectionString);
            return category.Delete(pID);
        }

    }
}
