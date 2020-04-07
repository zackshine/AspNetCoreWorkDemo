using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3API.Middlewares
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Request.EnableBuffering(); // now you can do it

            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                context.Items.Add("body", body); // there are ways to pass data from middleware to controllers downstream. this is one. see https://stackoverflow.com/questions/46601757/c-sharp-dotnet-core-2-pass-data-from-middleware-filter-to-controller-method for more

                // Reset the request body stream position so the next middleware can read it
                context.Request.Body.Position = 0;
            }

            // Call the next delegate/middleware in the pipeline
            await next(context);
        }
    }
}
