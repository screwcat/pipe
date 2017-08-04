using System.Text;
using System.Security.Principal;
using System.Collections;
using LTP.Accounts.Data;
using System.Security.Cryptography;

namespace LTP.Accounts.Bus
{
    public class AccountsPrincipal : IPrincipal
    {
        // Fields
        protected IIdentity identity;
        protected ArrayList permissionList;
        protected ArrayList permissionListid;
        protected ArrayList roleList;

        // Methods
        public AccountsPrincipal(int userID)
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);
            this.identity = new SiteIdentity(userID);
            this.permissionList = user.GetEffectivePermissionList(userID);
            
            this.permissionListid = user.GetEffectivePermissionListID(userID);
            this.roleList = user.GetUserRoles(userID);
        }


        public AccountsPrincipal(string userName)
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);
            this.identity = new SiteIdentity(userName);
            this.permissionList = user.GetEffectivePermissionList(((SiteIdentity)this.identity).UserID);
            this.permissionListid = user.GetEffectivePermissionListID(((SiteIdentity)this.identity).UserID);
            this.roleList = user.GetUserRoles(((SiteIdentity)this.identity).UserID);
        }


        public static byte[] EncryptPassword(string password)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(bytes);
        }


        public bool HasPermission(string permission)
        {
            return this.permissionList.Contains(permission);
        }



        public bool HasPermissionID(int permissionid)
        {
            return this.permissionListid.Contains(permissionid);
        }


        public bool IsInRole(string role)
        {
            return this.roleList.Contains(role);
        }

        public static AccountsPrincipal ValidateLogin(string userName, string password)
        {
            byte[] encPassword = EncryptPassword(password);
            Data.User user = new Data.User(PubConstant.ConnectionString);
            int userID = user.ValidateLogin(userName, encPassword);
            if (userID > 0)
            {
                return new AccountsPrincipal(userID);
            }
            return null;
        }


        // Properties
        public IIdentity Identity
        {
            get
            {
                return this.identity;
            }
            set
            {
                this.identity = value;
            }
        }
        public ArrayList Permissions
        {
            get
            {
                return this.permissionList;
            }
        }
        public ArrayList PermissionsID
        {
            get
            {
                return this.permissionListid;
            }
        }
        public ArrayList Roles
        {
            get
            {
                return this.roleList;
            }
        }
 

    }
}
