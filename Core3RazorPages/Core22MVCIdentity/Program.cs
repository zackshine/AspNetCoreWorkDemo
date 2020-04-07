using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core22MVCIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
        //    var config = new ConfigurationBuilder()
        //.AddJsonFile("appsettings.json", optional: false)
        //.Build();


        //    //config.GetSection("WebProtocolSettings").Bind(settings_Web);

        //    var host = new WebHostBuilder()
        //            .UseIISIntegration()
        //            .UseKestrel()
        //            .UseContentRoot(Directory.GetCurrentDirectory())
        //            .UseStartup<Startup>()
        //            //.UseUrls(settings_Web.Url + ":" + settings_Web.Port)
        //            .Build();

        //    host.Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
