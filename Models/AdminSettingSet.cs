using System.Data.SqlClient;
using System.Data;

namespace HasDbHelper.Models
{
    public class AdminSettingSet
    {
        public static string RunSet(string query, string connectionStr)
        {
            string result = string.Empty;
            SqlDataAdapter sqlData = new SqlDataAdapter();
            DataTable dt = new DataTable();
            var cmd = new SqlCommand();
            var conn = new SqlConnection(connectionStr);
            {
                conn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                sqlData = new SqlDataAdapter(cmd);
                sqlData.Fill(dt);
                conn.Close();
            }
            var settingRow = dt.NewRow();
            return settingRow["ConnString"].ToString();
        }
    }
}
