using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoreofM_I.Classes
{
    public class DataBaseConnection
    {
        public readonly string connectionString;
        public SqlConnection cnn;
        public const string selectAllString = "Select Owner_Name,Producent,Age,Serial_Number,Producing_Date,Type from M_ITable";

        public DataBaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
            cnn = new SqlConnection(connectionString);
        }

        public T Select<T>() where T : class
        {
            var tempList = new List<M_I>();
            cnn.Open();
            var command = new SqlCommand(selectAllString, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    tempList.Add(new M_I(dataReader.GetString(0), dataReader.GetString(1), Convert.ToInt32(dataReader.GetValue(2)), dataReader.GetString(3), Convert.ToDateTime(dataReader.GetString(4)), dataReader.GetString(5)));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cnn.Close();
            }

            return tempList as T;
        }
    }
}
