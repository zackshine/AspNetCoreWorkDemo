using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Data
{
    public interface IPushNotificationRepository
    {


        string Add();
    }

    public class PushNotificationRepository : IPushNotificationRepository
    {
        IServiceScopeFactory _serviceScopeFactory;
        public PushNotificationRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
      
        public string Add()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                return "sss";
            }

            
        }
    }
}
