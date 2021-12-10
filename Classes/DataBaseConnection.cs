using System.Data.SqlClient;

namespace StoreofM_I.Classes
{
    public class DataBaseConnection
    {
        public readonly string connectionString;
        public SqlConnection cnn;

        public DataBaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
            cnn = new SqlConnection(connectionString);
        }
    }
}
