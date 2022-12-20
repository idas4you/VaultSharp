using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.Identity
{
    public class IdentityInfo
    {
        [JsonProperty("bucket_key_hash")]
        public string BucketKeyHash { get; set; }
        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }
        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        ///  Identifier of the entity.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("last_update_time")]
        public DateTime LastUpdateTime { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("aliases")]
        public List<string> Aliases { get; set; }
        [JsonProperty("policies")]
        public List<string> Policies { get; set; }
    }
}
