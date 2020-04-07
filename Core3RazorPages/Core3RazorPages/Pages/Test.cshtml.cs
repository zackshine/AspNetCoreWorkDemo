using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core3RazorPages
{
    public class TestModel : PageModel
    {
        public string Amount { get; set; }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            if (context.HttpContext.Request.Method == "POST")
            {
                if (context.HttpContext.Request.Form.ContainsKey("__RequestVerificationToken"))
                {
                    var currentToken = context.HttpContext.Request.Form["__RequestVerificationToken"].ToString();
                    var lastToken = context.HttpContext.Session.GetString("LastProcessedToken");

                    if (lastToken == currentToken)
                    {
                        context.ModelState.AddModelError(string.Empty, "Double form submission detected.");
                    }
                    else
                    {
                        context.HttpContext.Session.SetString("LastProcessedToken", currentToken);
                    }

                }
            }

            base.OnPageHandlerSelected(context);
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                return new BadRequestResult();
            }

            return Page();
        }
    }
}