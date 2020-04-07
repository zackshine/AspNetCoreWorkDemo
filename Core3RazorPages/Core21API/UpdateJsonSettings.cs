using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core21API
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateJsonSettings
    {
        internal static void ConfigureJsonFormatter(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            //settings.Converters.Add(new StringEnumConverter());
        }
    }
}
