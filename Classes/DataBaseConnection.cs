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
            string selectAllString = "Select Owner_Name,Producent,Age,Serial_Number,Producing_Date,Type,Picture from M_ITable";
            var tempList = new List<M_I>();

            cnn.Open();

            var command = new SqlCommand(selectAllString, cnn);
            SqlDataReader dataReader = command.ExecuteReader();

            try
            {
                while (dataReader.Read())
                {
                    tempList.Add(new M_I(dataReader.GetString(0), dataReader.GetString(1), Convert.ToInt32(dataReader.GetValue(2)), dataReader.GetString(3), dataReader.GetDateTime(4), dataReader.GetString(5), Convert.FromBase64String(dataReader.GetString(6))));
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

        public void ChangeTable(M_I changedMI, int mode)
        {
            string sql;

            switch (mode)
            {
                case 1:
                    sql = $"Insert into M_ITable (Owner_Name,Producent,Age,Serial_Number,Producing_Date,Type,Picture) values('" + $"{changedMI.OwnerName}" + "','" + $"{changedMI.Producent}" + "','" + $"{changedMI.Age}" + "','" + $"{changedMI.SerialNumber}" + "'," + $"{changedMI.ProdusingDate.Year}/{changedMI.ProdusingDate.Month}/{changedMI.ProdusingDate.Day}" + ",'" + $"{changedMI.TypeOf}" + "','" + $"{Convert.ToBase64String(changedMI.ImageBuffer)}" + "')";
                    break;
                case 2:
                    sql = $"Update M_ITable set Owner_Name='" + $"{changedMI.OwnerName}" + "',Producent ='" + $"{changedMI.Producent}" + "',Age =" + $"{ changedMI.Age }" + ",Producing_Date=" + $"{changedMI.ProdusingDate.Year}/{changedMI.ProdusingDate.Month}/{changedMI.ProdusingDate.Day}" + ",Type='" + $"{changedMI.TypeOf}" + "',Picture='" + $"{Convert.ToString(changedMI.ImageBuffer)}" + "' where Serial_Number='" + $"{changedMI.SerialNumber}" + "'";
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
