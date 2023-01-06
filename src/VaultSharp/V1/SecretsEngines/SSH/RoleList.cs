using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.SSH
{
    public class RoleList
    {
        [JsonProperty("key_info")]
        public Dictionary<string, SSHRoles> KeyInfo { get; set; }

        [JsonProperty("keys")]
        public List<string> Keys { get; set; }
    }
}
