using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace monorail_web_v3.Test
{
    public static class Configuration
    {
        public static IConfigurationRoot BuildAppSettings(this IConfigurationBuilder configBuilder)
        {
            const string configFolder = "Config";
            const string appSettingsFile = "appsettings.json";

            var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var appSettingFilePath = Path.Combine(projectPath, configFolder, appSettingsFile);

            var configuration = configBuilder
                .AddJsonFile(appSettingFilePath, false, true)
                .Build();

            return configuration;
        }
    }
}