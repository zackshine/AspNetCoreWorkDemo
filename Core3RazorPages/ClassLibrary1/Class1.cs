using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ClassLibrary1.LoggerStartupAssembly))]

namespace ClassLibrary1
{
    public class LoggerStartupAssembly : IHostingStartup
    {

        //public static IWebHostEnvironment Envir { get; }

        //public LoggerStartupAssembly() : this(Envir)
        //{

        //}
        //public LoggerStartupAssembly(IWebHostEnvironment env)
        //{
        //    Console.WriteLine(env.EnvironmentName);

        //}

        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices(services =>
            //{
            //    services.AddScoped<IEmailService, EmailService>();
            //    var x1 = builder.GetSetting("Environment");
            //    var x2 = builder.GetSetting("EnvironmentKey");

            //});
            var x3 = builder.GetSetting("Environment");
            //var x4 = builder.GetSetting("EnvironmentKey");

            //throw new NotImplementedException();
        }
    }

   
}