using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoreofM_I
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
            finally
            {
                dataReader.Close();
                command.Dispose();
                cnn.Close();
            }

            return tempList;
        }

        public void InsertAll(List<M_I> insertList)
        {
            SqlCommand command = null;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";

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
            finally
            {
                cnn.Close();
            }
        }

        public void InsertNewMIi(M_I insertMI)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = $"Insert into M_ITable (Owner_Name,Producent,Age,Serial_Number,Producing_Date,Type,Picture) values ('{insertMI.OwnerName}','{insertMI.Producent}',{insertMI.Age},'{insertMI.SerialNumber}','{insertMI.ProdusingDate}','{insertMI.TypeOf}',{insertMI.Image})";

            using (SqlCommand command = new SqlCommand(sql, cnn))
            {
                cnn.Open();
                adapter.UpdateCommand = new SqlCommand(sql, cnn);
                adapter.UpdateCommand.ExecuteNonQuery();
                cnn.Close();
            }
        }

        public void ModifyElement(M_I modifiedMI)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = $"Update M_ITable set Owner_Name = '{modifiedMI.OwnerName}', Producent = '{modifiedMI.Producent}', Age = { modifiedMI.Age }, Serial_Number = '{modifiedMI.SerialNumber}', Producing_Date = '{modifiedMI.ProdusingDate}', Type = '{modifiedMI.TypeOf}', Picture = { modifiedMI.Image } where Serial_Number = '{modifiedMI.SerialNumber}'";

            using (SqlCommand command = new SqlCommand(sql, cnn))
            {
                cnn.Open();
                adapter.UpdateCommand = new SqlCommand(sql, cnn);
                adapter.UpdateCommand.ExecuteNonQuery();
                cnn.Close();
            }
        }

        public void DeleteElement(M_I deletedMI)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = $"Delete M_ITable  where Serial_Number='{deletedMI.SerialNumber}'";

            using (SqlCommand command = new SqlCommand(sql, cnn))
            {
                cnn.Open();
                adapter.UpdateCommand = new SqlCommand(sql, cnn);
                adapter.UpdateCommand.ExecuteNonQuery();
                cnn.Close();
            }
        }

        public void ChangeTable(M_I changedMI, int mode)
        {
            string sql;

            switch (mode)
            {
                case 1:
                    sql = $"Insert into M_ITable (Owner_Name,Producent,Age,Serial_Number,Producing_Date,Type,Picture) values ('{changedMI.OwnerName}','{changedMI.Producent}',{changedMI.Age},'{changedMI.SerialNumber}','{changedMI.ProdusingDate}','{changedMI.TypeOf}',{changedMI.Image})";
                    break;
                case 2:
                    sql = $"Update M_ITable set Owner_Name = '{changedMI.OwnerName}', Producent = '{changedMI.Producent}', Age = { changedMI.Age }, Serial_Number = '{changedMI.SerialNumber}', Producing_Date = '{changedMI.ProdusingDate}', Type = '{changedMI.TypeOf}', Picture = { changedMI.Image } where Serial_Number = '{changedMI.SerialNumber}'";
                    break;
                case 3:
                    sql = $"Delete M_ITable  where Serial_Number='{changedMI.SerialNumber}'";
                    break;
                default:
                    sql = "";
                    break;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();

            using (SqlCommand command = new SqlCommand(sql, cnn))
            {
                cnn.Open();
                adapter.UpdateCommand = new SqlCommand(sql, cnn);
                adapter.UpdateCommand.ExecuteNonQuery();
                cnn.Close();
            }
        }
    }
}
