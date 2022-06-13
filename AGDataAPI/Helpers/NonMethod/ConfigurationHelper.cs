using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AGDataAPI.Helpers.NonMethod
{
    public static class ConfigurationHelper
    {
        private static IConfiguration config;
        public static string getConfigValue(string configSection, string keyName)
        {
            config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", false, true)
           .Build();
            string appValue = ConfigExtenstions.GetValue<string>(config, configSection, keyName);

            return appValue;
        }

        public static string getConnectionString(this IConfiguration config, string keyName)
        {
            return ConfigExtenstions.getConnectionString(config, keyName);
        }
    }

    public static class ConfigExtenstions
    {
        public static T GetValue<T>(this IConfiguration configuration, string configSection, string keyName)
        {
            return (T)Convert.ChangeType(configuration[$"{configSection}:{keyName}"], typeof(T));
        }

        public static string getConnectionString(this IConfiguration configuration, string keyName)
        {
            return configuration.GetConnectionString(keyName);
        }
    }
}
