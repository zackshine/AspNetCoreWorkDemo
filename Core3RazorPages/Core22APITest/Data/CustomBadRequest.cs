using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core22APITest.Data
{
    public class CustomBadRequest : ValidationProblemDetails
    {
        public CustomBadRequest(ActionContext context)
        {
            //Title = "Invalid arguments to the API";
            //Detail = "The inputs supplied to the API are invalid";
            //Status = 400;
            ConstructErrorMessages(context);
            Type = context.HttpContext.TraceIdentifier;
        }

        private void ConstructErrorMessages(ActionContext context)
        {
            var myerror = "Cannot deserialize the current JSON array (e.g. [1,2,3]) into type 'Core22APITest.Controllers.TestBindController+RetrieveMultipleResponse' because the type requires a JSON object (e.g. {\"name\":\"value\"}) to deserialize correctly.\r\nTo fix this error either change the JSON to a JSON object (e.g. {\"name\":\"value\"}) or change the deserialized type to an array or a type that implements a collection interface (e.g. ICollection, IList) like List<T> that can be deserialized from a JSON array. JsonArrayAttribute can also be added to the type to force it to deserialize from a JSON array.\r\nPath '', line 1, position 1.";
            foreach (var keyModelStatePair in context.ModelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    if (errors.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errors[0]);
                        if(errorMessage == myerror)
                        {
                            Errors.Add(key, new[] { "Cannot deserialize" });
                        }
                        else
                        {
                            Errors.Add(key, new[] { errorMessage });
                        }
                        
                    }
                    else
                    {
                        var errorMessages = new string[errors.Count];
                        for (var i = 0; i < errors.Count; i++)
                        {
                            errorMessages[i] = GetErrorMessage(errors[i]);
                            if (errorMessages[i] == myerror)
                            {
                                errorMessages[i] =  "Cannot deserialize" ;
                            }
                        }

                        Errors.Add(key, errorMessages);
                    }
                }
            }
        }

        string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?
                "The input was not valid." :
            error.ErrorMessage;
        }
    }
}
