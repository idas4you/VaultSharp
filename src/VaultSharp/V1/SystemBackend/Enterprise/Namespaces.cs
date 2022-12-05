using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.SystemBackend.Enterprise
{
    public class Namespaces
    {
        [JsonProperty("custom_metadata")]
        public Dictionary<string, string> CustomMetadata { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
