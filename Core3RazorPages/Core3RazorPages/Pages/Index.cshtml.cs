using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core3RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmailService emailService;
        public IndexModel(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        public void OnGet()
        {
            var result = emailService.Send();
        }
    }
}
