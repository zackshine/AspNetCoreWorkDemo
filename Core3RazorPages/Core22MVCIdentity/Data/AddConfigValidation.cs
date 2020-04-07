using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22MVCIdentity.Data
{

    public class ValidateConfigFilter: IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<RequestServicesContainerMiddleware>();
                next(builder);
            };
        }
    }

    public class IdentityStartupSettings: IValidateConfig
    {
        string Name { get; set; }
    }

    public interface IValidateConfig
    {
    }
    public static class Extensions
    {
        public static IServiceCollection AddConfigValidation<T>(this IServiceCollection services, IConfiguration config)
             where T : class, IValidateConfig, new()
        {
            services.Configure<T>(config);

            services.AddSingleton(resolver =>
            {
                var configValue = resolver.GetRequiredService<IOptions<T>>().Value;
                return configValue;
            });
            services.AddTransient<IStartupFilter, ValidateConfigFilter>();


            services.AddSingleton<IValidateConfig>(provider => provider.GetRequiredService<T>());

            return services;
        }
    }
    
}
