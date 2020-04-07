using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;



//using Microsoft.AspNet.OData.Extensions;
using System.Web.Http;
//using Microsoft.OpenApi.Models;
using System.Reflection;
using Newtonsoft.Json;
//using Microsoft.AspNet.OData.Builder;

using Microsoft.Net.Http.Headers;
//using Microsoft.AspNet.OData.Formatter;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Formatter;
using Core22ApiSwaggerOdata.Models;

namespace Core22ApiSwaggerOdata
{
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
            services.AddMvc(op =>
            {
                //op.EnableEndpointRouting = false;
                
            })
            //services.AddMvc(options=> options.EnableEndpointRouting = false)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options =>
            {
                // Use camel case properties in the serializer and the spec (optional)
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                // Use string enums in the serializer and the spec (optional)
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
           
            // registers a Swagger v2.0 document with the name "v1" (default)
            services.AddSwaggerDocument(c => {
                c.DocumentName = "V1";
                c.Title = "GL Controller";
            });
            services.AddOData();

            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {

                app.UseHsts();
            }
            app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseOpenApi(); // Serves the registered OpenAPI/Swagger documents by default on 
            app.UseSwaggerUi3(); // Serves the Swagger UI 3 web ui to view the OpenAPI/Swagger 

           // var builder = new ODataConventionModelBuilder(app.ApplicationServices);
            //builder.EntitySet<Product>("Products");

            app.UseMvc(routeBuilder =>
            {
                //routeBuilder.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Filter().Count().OrderBy();
            });

           
        }
    }
}
