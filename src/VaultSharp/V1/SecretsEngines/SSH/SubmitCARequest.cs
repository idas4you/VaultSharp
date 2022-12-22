using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VaultSharp.V1.SecretsEngines.SSH
{
    public class SubmitCARequest
    {
        /// <summary>
        /// Specifies the private key part the SSH CA key pair; required if generate_signing_key is false.
        /// </summary>
        [JsonProperty("private_key")] 
        public string PrivateKey;

        /// <summary>
        /// Specifies the public key part of the SSH CA key pair; required if generate_signing_key is false.
        /// </summary>
        [JsonProperty("public_key")] 
        public string PublicKey;

        /// <summary>
        /// Specifies if Vault should generate the signing key pair internally.If true, an RSA key pair is generated, and the generated public key is returned so you can add it to your configuration.If false, then you must provide private_key and public_key, but these can be of any valid signing key type.
        /// </summary>
        [JsonProperty("enerate_signing_key")] 
        public bool EnerateSigningKey { get; set; } = true;
        /// <summary>
        /// Specifies the desired key type for the generated SSH CA key when generate_signing_key is set to true. Valid values are OpenSSH key type identifiers(ssh-rsa, ecdsa-sha2-nistp256, ecdsa-sha2-nistp384, ecdsa-sha2-nistp521, or ssh-ed25519) or an algorithm(rsa, ec, or ed25519). Note: In FIPS 140-2 mode, the following algorithms are not certified and thus should not be used: ed25519.
        /// </summary>
        [JsonProperty("key_type")] 
        public string KeyType { get; set; } = "ssh-rsa";

        /// <summary>
        /// Specifies the desired key bits for the generated SSH CA key when generate_signing_key is set to true. This is only used for variable length keys(such as ssh-rsa, where the value of key_bits specifies the size of the RSA key pair to generate; with the default 0 value resulting in a 4096-bit key) or when the ec algorithm is specified in key_type(where the value of key_bits identifies which NIST P-curve to use; 256, 384, or 521, with the default 0 value resulting in a NIST P-256 key).
        /// </summary>
        [JsonProperty("key_bits")] 
        public int KeyBits { get; set; } = 0;
    }
}
