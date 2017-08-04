using System.Data;
using LTP.Accounts.Data;

namespace LTP.Accounts.Bus
{
    public class Role
    {
        // Fields
        private string description;
        private DataSet nopermissions;
        private DataSet permissions;
        private int roleId;

        // Methods
        public Role()
        {
        }

        public Role(int currentRoleId)
        {
            DataRow row = new Data.Role(PubConstant.ConnectionString).Retrieve(currentRoleId);
            this.roleId = currentRoleId;
            this.description = (string)row["Description"];
            Permission permission = new Permission(PubConstant.ConnectionString);
            this.permissions = permission.GetPermissionList(currentRoleId);
            this.nopermissions = permission.GetNoPermissionList(currentRoleId);
        }

        public void AddPermission(int permissionId)
        {
            new Data.Role(PubConstant.ConnectionString).AddPermission(this.roleId, permissionId);
        }

        public void ClearPermissions()
        {
            new Data.Role(PubConstant.ConnectionString).ClearPermissions(this.roleId);
        }


        public int Create()
        {
            this.roleId = new Data.Role(PubConstant.ConnectionString).Create(this.description);
            return this.roleId;
        }


        public bool Delete()
        {
            Data.Role role = new Data.Role(PubConstant.ConnectionString);
            return role.Delete(this.roleId);
        }

        public void RemovePermission(int permissionId)
        {
            new Data.Role(PubConstant.ConnectionString).RemovePermission(this.roleId, permissionId);
        }

        public bool Update()
        {
            Data.Role role = new LTP.Accounts.Data.Role(PubConstant.ConnectionString);
            return role.Update(this.roleId, this.description);
        }


        // Properties
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public DataSet NoPermissions
        {
            get
            {
                return this.nopermissions;
            }
        }

        public DataSet Permissions
        {
            get
            {
                return this.permissions;
            }
        }
        public int RoleID
        {
            get
            {
                return this.roleId;
            }
        }


    }
}
