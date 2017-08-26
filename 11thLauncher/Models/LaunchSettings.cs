﻿namespace _11thLauncher.Models
{
    public class LaunchSettings
    {
        public LaunchOption LaunchOption;
        public LaunchPlatform Platform;
        public string Server = "";
        public string Port = "";
        public string Password = "";

        public LaunchSettings()
        {
            LaunchOption = LaunchOption.Normal;
            Platform = LaunchPlatform.X86;
        }
    }
}