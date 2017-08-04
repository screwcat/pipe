using LTP.Accounts.Data;

namespace LTP.Accounts.Bus
{
    public class Permissions
    {
        public int Create(int pcID, string description)
        {
            Permission permission = new Permission(PubConstant.ConnectionString);
            return permission.Create(pcID, description);
        }
        public bool Delete(int pID)
        {
            Permission permission = new Permission(PubConstant.ConnectionString);
            return permission.Delete(pID);
        }

        public string GetPermissionName(int pID)
        {
            Permission permission = new Permission(PubConstant.ConnectionString);
            return permission.Retrieve(pID)["Description"].ToString();
        }

        public bool Update(int pcID, string description)
        {
            Permission permission = new Permission(PubConstant.ConnectionString);
            return permission.Update(pcID, description);
        }

 

    }
}
