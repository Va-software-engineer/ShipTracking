using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ShipTracking.Generic.Infrastructure
{
    public static class ConfigSettings
    {
        private static readonly string _environmentPath = string.Empty;

        private static readonly string _SQLConnectionString = string.Empty;
        private static readonly int _pageSize;

        static ConfigSettings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var appSetting = root.GetSection("AppSettings");
           
            _environmentPath = Directory.GetCurrentDirectory();

            _SQLConnectionString = root.GetConnectionString("SQLConnection");
            _pageSize = Convert.ToInt32(appSetting.GetSection("PageSize").Value);
        }

        public static string EnvironmentPath
        {
            get => _environmentPath;
        }

        public static string SQLConnectionString
        {
            get => _SQLConnectionString;
        }

        public static int PageSize
        {
            get => _pageSize;
        }
    }
}