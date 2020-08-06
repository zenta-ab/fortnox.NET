using Microsoft.Extensions.Configuration;
using System;

namespace FortnoxNET.Tests.Config
{
    public static class TestHelper
    {
        public static IConfigurationRoot GetConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", false)
                .Build();
        }

        public static FortnoxConnectionSettings GetFortnoxConnectionSettings()
        {
            var fortnoxConfiguration = new FortnoxConnectionSettings();

            var config = GetConfigurationRoot(Environment.CurrentDirectory);
            config.Bind(fortnoxConfiguration);

            return fortnoxConfiguration;
        }
    }
}
