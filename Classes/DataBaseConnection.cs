using System;
using System.Collections.Generic;
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

        public List<M_I> SelectAll()
        {
            string selectAllString = "Select Owner_Name,Producent,Age,Serial_Number,Producing_Date,Type,Image from M_ITable";
            var tempList = new List<M_I>();

            cnn.Open();

            var command = new SqlCommand(selectAllString, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    tempList.Add(new M_I(dataReader.GetString(0), dataReader.GetString(1), Convert.ToInt32(dataReader.GetValue(2)), dataReader.GetString(3), Convert.ToDateTime(dataReader.GetString(4)), dataReader.GetString(5), dataReader.GetString(7)));
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

            return tempList;
        }

        public void InsertAll(List<M_I> insertList)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql;

            cnn.Open();

            try
            {
                foreach (M_I item in insertList)
                {
                    sql = $"Insert into M_ITable (Owner_Name,Producent,Age,Serial_Number,Producing_Date,Type,Picture) values ({item.OwnerName},{item.Producent},{item.Age},{item.SerialNumber},{item.ProdusingDate},{item.TypeOf},{item.Image})";
                    command = new SqlCommand(sql, cnn);
                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
