using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.SSH
{
    public class SSHCaInfo
    {
        /// <summary>
        /// Gets or sets the public key.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
    }
}
