namespace HasDbHelper
{
    public class ConnectInformation
    {
        public static string _Connect = Settings.Settings.Set();
        public static string DAL
        {
            get => _Connect;
        }
    }
}
