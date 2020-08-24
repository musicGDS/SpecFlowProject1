using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpecFlowProject1
{
    public class ConfigReader
    {
        public IConfiguration Configuration;
        public ConfigReader()
        {
            var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile(Path.Combine("specflow.json"))
    .AddEnvironmentVariables();
            Configuration = configurationBuilder.Build();
        }
        public string GetValue(string key)
        {
            string result = Configuration.GetConnectionString(key);
            return result;
        }
    }
}
