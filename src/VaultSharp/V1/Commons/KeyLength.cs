using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.Commons
{
    public class KeyLength
    {
        [JsonProperty("rsa")]
        List<int> RSA { get; set; }
        [JsonProperty("EC")]
        int EC { get; set; }
        [JsonProperty("ecdsa-sha2-nistp521")]
        int EcdsaSha2Nistp521 { get; set; }
    }
}
