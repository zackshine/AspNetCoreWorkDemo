using Core31MVC.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core31MVC.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message)
        {
            List<Employee> listUser = new List<Employee>() { 
                new Employee()
                {
                    Id =1,
                    Name = "Edward"
                },
                new Employee()
                {
                    Id =2,
                    Name = "Ryan"
                }
            };
            object[] args = { listUser, user, message };
            await Clients.All.SendCoreAsync("ReceiveMessage", args);
            //await Clients.All.SendAsync("ReceiveMessage", listUser, user, message);
        }
    }
}
