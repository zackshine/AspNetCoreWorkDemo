using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core31API
{
    public class MyCustomXmlSerializerOutputFormatter : XmlSerializerOutputFormatter
    {
        protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
        {

            xmlSerializer = new XmlSerializer(typeof(List<WeatherForecast>) ,new XmlRootAttribute("WeatherForecasts"));
            //applying "empty" namespace will produce no namespaces
            //var emptyNamespaces = new XmlSerializerNamespaces();
            //emptyNamespaces.Add("", "");
            xmlSerializer.Serialize(xmlWriter, value);
        }
    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers(options =>
            //{
            //    options.OutputFormatters.Clear();
            //    options.OutputFormatters.Add(new MyCustomXmlSerializerOutputFormatter());
            //}).AddXmlSerializerFormatters();
            services.AddControllers().AddNewtonsoftJson();
            //services.AddMvcCore(options =>
            //{
            //    options.OutputFormatters.Clear(); // Remove json for simplicity
            //    options.OutputFormatters.Add(new MyCustomXmlSerializerOutputFormatter());
            //});

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
