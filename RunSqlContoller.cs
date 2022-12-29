using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HasDbHelper.Controllers
{
    public class RunSqlContoller
    {
        public static DataTable ExecuteProcedure(string PROC_NAME, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");
                DataTable a = new DataTable();
                List<SqlParameter> filters = new List<SqlParameter>();

                string query = "EXEC " + PROC_NAME;

                bool first = true;
                for (int i = 0; i < parameters.Length; i += 2)
                {
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));
                    query += (first ? " " : ", ") + ((string)parameters[i]);
                    first = false;
                }

                a = Models.RunSqlModels.Query(query, filters);
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ExecuteQuery(string query, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");
                DataTable a = new DataTable();
                List<SqlParameter> filters = new List<SqlParameter>();

                for (int i = 0; i < parameters.Length; i += 2)
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));

                a = Models.RunSqlModels.Query(query, filters);
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ExecuteNonQuery(string query, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to procedure. Expected an even number.");
                List<SqlParameter> filters = new List<SqlParameter>();

                for (int i = 0; i < parameters.Length; i += 2)
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));
                return Models.RunSqlModels.NonQuery(query, filters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object ExecuteScalar(string query, params object[] parameters)
        {
            try
            {
                if (parameters.Length % 2 != 0)
                    throw new ArgumentException("Wrong number of parameters sent to query. Expected an even number.");
                List<SqlParameter> filters = new List<SqlParameter>();

                for (int i = 0; i < parameters.Length; i += 2)
                    filters.Add(new SqlParameter(parameters[i] as string, parameters[i + 1]));
                return Models.RunSqlModels.Scalar(query, filters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
