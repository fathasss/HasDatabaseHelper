using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasDbHelper
{
    public class HasDbHelper
    {
        public static DataTable ExecuteProcedure(string procedureName,object[] parameters) => Controllers.RunSqlContoller.ExecuteProcedure(procedureName, parameters);
        public static DataTable ExecuteQuery(string procedureName,object[] parameters) => Controllers.RunSqlContoller.ExecuteQuery(procedureName, parameters);
        public static int ExecuteNonQuery(string procedureName,object[] parameters) => Controllers.RunSqlContoller.ExecuteNonQuery(procedureName, parameters);
        public static object ExecuteScalar(string procedureName,object[] parameters) => Controllers.RunSqlContoller.ExecuteScalar(procedureName, parameters);    
    }
}
