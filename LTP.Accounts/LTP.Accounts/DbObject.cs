using System.Data;
using System.Data.SqlClient;

namespace LTP.Accounts
{
    public abstract class DbObject
    {
        public static string connectionString;
        protected SqlConnection Connection;

        protected string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        static DbObject()
        {
            connectionString = PubConstant.ConnectionString;
        }

        public DbObject(string newConnectionString)
        {
            connectionString = newConnectionString;
            this.Connection = new SqlConnection(connectionString);
        }


        private SqlCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = this.BuildQueryCommand(storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        private SqlCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, this.Connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }


        protected SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            this.Connection.Open();
            SqlCommand command = this.BuildQueryCommand(storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();
        }
        protected DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            this.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildQueryCommand(storedProcName, parameters);
            adapter.Fill(dataSet, tableName);
            this.Connection.Close();
            return dataSet;
        }


        protected int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            this.Connection.Open();
            SqlCommand command = this.BuildIntCommand(storedProcName, parameters);
            rowsAffected = command.ExecuteNonQuery();
            int num = (int)command.Parameters["ReturnValue"].Value;
            this.Connection.Close();
            return num;
        }


        protected void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName)
        {
            this.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildIntCommand(storedProcName, parameters);
            adapter.Fill(dataSet, tableName);
            this.Connection.Close();
        }        
    }
}
