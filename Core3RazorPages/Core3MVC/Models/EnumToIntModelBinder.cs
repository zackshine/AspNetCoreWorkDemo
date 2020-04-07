using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class EnumToIntModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var value = valueProviderResult.Values;

            int sum = 0;

            // read each character in input string  
            foreach (var item in value)
            {
                sum += int.Parse(item);
            }

            bindingContext.Result = ModelBindingResult.Success(sum);

            return Task.CompletedTask;
        }
    }
}
