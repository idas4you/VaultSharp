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
        [JsonProperty("aliases")]
        public List<string> Aliases { get; set; }
        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("direct_group_ids")]
        public List<string> DirectGroupIds { get; set; }
        [JsonProperty("disabled")]
        public bool Disabled { get; set; }
        [JsonProperty("group_ids")]
        public List<string> GroupIds { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("inherited_group_ids")]
        public List<string> InheritedGroupIds { get; set; }
        [JsonProperty("last_update_time")]
        public DateTime LastUpdateTime { get; set; }
        [JsonProperty("merged_entity_ids")]
        public List<string> MergedEntityIds { get; set; }
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
        [JsonProperty("mfa_secrets")]
        public string MfaSecrets { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("namespace_id")]
        public string NamespaceId { get; set; }
        [JsonProperty("policies")]
        public List<string> Policies { get; set; }
    }
}
