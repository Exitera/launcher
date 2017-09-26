namespace _11thLauncher.Models
{
    public class ApplicationSettings
    {
        #region Properties

        public bool CheckUpdates = true;
        public bool CheckServers = true;
        public bool CheckRepository = false;
        public string Language = "en-US";
        public string Arma3Path = null;
        public StartAction StartAction = StartAction.Nothing;
        public bool MinimizeNotification = false;
        public ThemeStyle ThemeStyle = 0;
        public AccentColor AccentColor = 0;
        public string JavaPath = string.Empty;
        public string Arma3SyncPath = string.Empty;

        public LogLevel LogLevel
        {
            get => ApplicationConfig.MaxLogLevel;
            set => ApplicationConfig.MaxLogLevel = value;
        }

        #endregion
    }
}
