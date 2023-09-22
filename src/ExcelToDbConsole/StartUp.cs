using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDbConsole
{
    public class StartUp
    {
        public AppSetting appSetting { get; set; }
        public StartUp()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();

            //appSetting = configuration.GetSection("AppSetting")
        }
        

    }
}
