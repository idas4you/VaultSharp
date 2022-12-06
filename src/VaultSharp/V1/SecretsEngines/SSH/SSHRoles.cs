using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SecretsEngines.SSH
{
    public class SSHRoles
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("admin_user")]
        public string AdminUser { get; set; }
        [JsonProperty("default_user")]
        public string DefaultUser { get; set; }
        [JsonProperty("default_user_template")]
        public bool DefaultUserTemplate { get; set; }
        [JsonProperty("cidr_list")]
        public string CidrList { get; set; }
        [JsonProperty("exclude_cidr_list")]
        public string ExcludeCidrList { get; set; }
        [JsonProperty("port")]
        public int Port { get; set; }
        [JsonProperty("key_type")]
        public string KeyType { get; set; }
        [JsonProperty("key_bits")]
        public int KeyBits { get; set; }
        [JsonProperty("install_script")]
        public string InstallScript { get; set; }
        [JsonProperty("allowed_users")]
        public string AllowedUsers { get; set; }
        [JsonProperty("allowed_users_template")]
        public bool AllowedUsersTemplate { get; set; }
        [JsonProperty("allowed_domains")]
        public string AllowedDomains { get; set; }
        [JsonProperty("allowed_domains_template")]
        public bool AllowedDomainsTemplate { get; set; }
        [JsonProperty("key_option_specs")]
        public string KeyOptionSpecs { get; set; }
        [JsonProperty("ttl")]
        public string Ttl { get; set; }
        [JsonProperty("max_ttl")]
        public string MaxTtl { get; set; }
        [JsonProperty("allowed_critical_options")]
        public string AllowedCriticalOptions { get; set; }
        [JsonProperty("allowed_extensions")]
        public string AllowedExtensions { get; set; }
        [JsonProperty("default_critical_options")]
        public Dictionary<string, string> DefaultCriticalOptions { get; set; }
        [JsonProperty("default_extensions")]
        public Dictionary<string, string> DefaultExtensions { get; set; }
        [JsonProperty("allow_user_certificates")]
        public bool AllowUserCertificates { get; set; }
        [JsonProperty("allow_host_certificates")]
        public bool AllowHostCertificates { get; set; }
        [JsonProperty("allow_bare_domains")]
        public bool AllowBareDomains { get; set; }
        [JsonProperty("allow_subdomains")]
        public bool AllowSubdomains { get; set; }
        [JsonProperty("allow_user_key_ids")]
        public bool AllowUserKeyIds { get; set; }
        [JsonProperty("key_id_format")]
        public string KeyIdFormat { get; set; }
        [JsonProperty("allowed_user_key_lengths")]
        public Dictionary<string, KeyLength> AllowedUserKeyLengths { get; set; }
        [JsonProperty("algorithm_signer")]
        public string AlgorithmSigner { get; set; }
        [JsonProperty("not_before_duration")]
        public string NotBeforeDuration { get; set; }

        public SSHRoles()
        {
            KeyBits = 1024;
            AlgorithmSigner = "default";
            NotBeforeDuration = "30s";
        }
    }
}
