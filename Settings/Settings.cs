namespace HasDbHelper.Settings
{
    public class Settings
    {
        private string ConnectionName = "Server=myHasAdmin;Database=projects;User Id=has_admin;Password=***********;";
        private int Project = 1; //Project Id güncellendiğinde ConnectionString doldurulacak.
        public string ConnectionString
        {
            get { return ConnectionName; }
            set { ConnectionName = value; }
        }
        public int ProjectId 
        {
            get { return Project; }
            set { Project = 0; } 
        }

        public static string Set()
        {
            string result = string.Empty;
            Settings data = new Settings();
            var query = "SELECT ConnString FROM PROJECTS p WHERE p.ProjectId = " + data.ProjectId;
            result = Models.AdminSettingSet.RunSet(query, data.ConnectionString);
            return result;
        }
    }
}
