using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.Identity
{
    public class EntityAliasInfo
    {

        [JsonProperty("canonical_id")] 
        public string CanonicalId{get;set;}
        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("last_update_time")] 
        public DateTime LastUpdateTime { get; set; }
        [JsonProperty("local")] 
        public bool Local { get; set; }
        [JsonProperty("merged_from_canonical_ids")] 
        public List<string> MergedFromCanonicalIds { get; set; }
        [JsonProperty("metadata")] 
        public Dictionary<string, string> Metadata { get; set; }
        [JsonProperty("mount_accessor")] 
        public string MountAccessor { get; set; }
        [JsonProperty("mount_path")] 
        public string MountPath { get; set; }
        [JsonProperty("mount_type")] 
        public string MountType { get; set; }
        [JsonProperty("name")] 
        public string Name { get; set; }
    }
}
