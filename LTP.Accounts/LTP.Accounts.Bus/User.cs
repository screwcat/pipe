using System.Data;
using LTP.Accounts.Data;

namespace LTP.Accounts.Bus

{
    public sealed class User
    {
        private bool activity;
        private string departmentID;
        private string email;
        private int employeeID;
        private byte[] password;
        private string phone;
        private string sex;
        private int style;
        private string trueName;
        private int userID;
        private string userName;
        private string userType;

        public User()
        {
            this.departmentID = "-1";
        }

        public User(AccountsPrincipal existingPrincipal)
        {
            this.departmentID = "-1";
            this.userID = ((SiteIdentity)existingPrincipal.Identity).UserID;
            this.LoadFromID();
        }


        public User(int existingUserID)
        {
            this.departmentID = "-1";
            this.userID = existingUserID;
            this.LoadFromID();
        }

        public User(string UserName)
        {
            this.departmentID = "-1";
            DataRow row = new Data.User(PubConstant.ConnectionString).Retrieve(UserName);
           
            
            if (row != null)
            {
                this.userID = (int)row["UserID"];
                this.trueName = (string)row["TrueName"];
                this.sex = (string)row["Sex"];
                this.phone = (string)row["Phone"];
                this.email = (string)row["Email"];
                this.employeeID = (int)row["EmployeeID"];
                this.password = (byte[])row["Password"];
                this.style = (int)row["Style"];
            }
        }

        public bool AddToRole(int roleId)
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);
            return user.AddRole(this.userID, roleId);
        }

        public int Create()
        {
            this.userID = new Data.User(PubConstant.ConnectionString).Create(this.userName, this.password, this.trueName, this.sex, this.phone, this.email, this.employeeID, this.departmentID, this.activity, this.userType, this.style);
            return this.userID;
        }

        public bool Delete()
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);
            return user.Delete(this.userID);
        }


        public DataSet GetAllUsers(string key)
        {            
            Data.User user = new Data.User(PubConstant.ConnectionString);  
            return user.GetAllUsers(key);
        }




        public DataSet GetUsers(string DepartmentID)
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);  
            return user.GetUsers(DepartmentID);
        }

        public DataSet GetUsersByType(string usertype, string key)
        {            
            Data.User user = new Data.User(PubConstant.ConnectionString);  
            return user.GetUsersByType(usertype, key);
        }




        public bool HasUser(string userName)
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);  
            return user.HasUser(userName);
        }

        private void LoadFromID()
        {
            DataRow row = new  Data.User(PubConstant.ConnectionString).Retrieve(this.userID);
            if (row != null)
            {
                this.userName = (string)row["UserName"];
                this.trueName = (string)row["TrueName"];
                this.sex = (string)row["Sex"];
                this.phone = (string)row["Phone"];
                this.email = (string)row["Email"];
                this.employeeID = (int)row["EmployeeID"];
                this.departmentID = (string)row["DepartmentID"];
                this.activity = (bool)row["Activity"];
                this.userType = (string)row["UserType"];
                this.password = (byte[])row["Password"];
                this.style = (int)row["Style"];
            }
        }

        public bool RemoveRole(int roleId)
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);
            return user.RemoveRole(this.userID, roleId);
            
        }

        public bool SetPassword(string UserName, string password)
        {
            byte[] encPassword = AccountsPrincipal.EncryptPassword(password);
            Data.User user = new Data.User(PubConstant.ConnectionString);            
            return user.SetPassword(UserName, encPassword);
        }

        public bool Update()
        {
            Data.User user = new Data.User(PubConstant.ConnectionString);
            return user.Update(this.userID, this.userName, this.password, this.trueName, this.sex, this.phone, this.email, this.employeeID, this.departmentID, this.activity, this.userType, this.style);
        }


        public bool Activity
        {
            get
            {
                return this.activity;
            }
            set
            {
                this.activity = value;
            }
        }
        public string DepartmentID
        {
            get
            {
                return this.departmentID;
            }
            set
            {
                this.departmentID = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return this.employeeID;
            }
            set
            {
                this.employeeID = value;
            }
        }
        public byte[] Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public int Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }

        public string TrueName
        {
            get
            {
                return this.trueName;
            }
            set
            {
                this.trueName = value;
            }
        }

        public int UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }
        
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
        
        public string UserType
        {
            get
            {
                return this.userType;
            }
            set
            {
                this.userType = value;
            }
        }

    }
}
