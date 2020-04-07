using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public interface IEmailService
    {
        string Send();
    }
    public class EmailService: IEmailService
    {
        private readonly IHostingEnvironment env;
        public EmailService(IHostingEnvironment env)
        {
            this.env = env;
        }
        public string Send()
        {
            return env.EnvironmentName;
        }
    }
}
