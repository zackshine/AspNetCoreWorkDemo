using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class Input2
    {
        [DataMember]
        [JsonProperty("inputs2")]
        public List<object> inputs { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public object description { get; set; }
        [DataMember]
        [JsonProperty("name")]
        public string name { get; set; }
        [DataMember]
        public bool multiple { get; set; }
    }




    public class Input
    {
        [JsonProperty("inputs")]
        public IEnumerable<Input2> Input2 { get; set; }
        public object type { get; set; }
        public object description { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        public bool multiple { get; set; }
    }
    public class ContractsInputViewModel
    {

        [JsonProperty("inputs")]
        public List<Input> Inputs { get; set; }
        [JsonProperty("constraints")]
        public List<object> constraints { get; set; }

    } 
}
