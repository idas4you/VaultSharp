using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.SecretsEngines.Identity
{
    public class CreateEntityReqeust
    {
        /// <summary>
        /// Name of the entity.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// ID of the entity.If set, updates the corresponding existing entity.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Metadata to be associated with the entity.
        /// </summary>
        [JsonProperty("metadata")] 
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Policies to be tied to the entity.
        /// </summary>
        [JsonProperty("policies")] 
        public List<string> Policies { get; set; }

        /// <summary>
        /// Whether the entity is disabled.Disabled entities' associated tokens cannot be used, but are not revoked.
        /// </summary>
        [JsonProperty("disabled")] 
        public bool Disabled { get; set; } = false;
    }
}
