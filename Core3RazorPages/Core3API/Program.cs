using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core3API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        //    public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        //Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
        //    .UseStartup<Startup>()
        //    .ConfigureKestrel(options => {
        //        options.ListenLocalhost(44379);
        //    });
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
