using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.SystemBackend.Enterprise
{
    public class NamespaceList
    {
        [JsonProperty("key_info")]
        public Dictionary<string, NamespaceInfo> KeyInfo { get; set; }

        [JsonProperty("keys")]
        public List<string> Keys { get; set; }
    }

    public class NamespaceInfo
    {
        [JsonProperty("custom_metadata")]
        public Dictionary<string, string> CustomMetadata { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
