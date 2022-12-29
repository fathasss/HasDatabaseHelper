using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace HasDbHelper.Models
{
    public class RunSqlModels
    {
        public static DataTable Query(String consulta, IList<SqlParameter> parametros)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(ConnectInformation.DAL);
                SqlCommand command = new SqlCommand();
                SqlDataAdapter da;
                try
                {
                    command.Connection = connection;
                    command.CommandText = consulta;
                    if (parametros != null)
                        command.Parameters.AddRange(parametros.ToArray());
                    da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static int NonQuery(string query, IList<SqlParameter> parametros)
        {
            try
            {
                DataSet dt = new DataSet();
                SqlConnection connection = new SqlConnection(ConnectInformation.DAL);
                SqlCommand command = new SqlCommand();
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    command.Parameters.AddRange(parametros.ToArray());
                    return command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static object Scalar(string query, List<SqlParameter> parametros)
        {
            try
            {
                DataSet dt = new DataSet();
                SqlConnection connection = new SqlConnection(ConnectInformation.DAL);
                SqlCommand command = new SqlCommand();
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = query;
                    command.Parameters.AddRange(parametros.ToArray());
                    return command.ExecuteScalar();
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
