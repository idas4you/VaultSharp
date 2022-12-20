using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VaultSharp.V1.AuthMethods.UserPass
{
    /// <summary>
    /// Userpass creation options.
    /// </summary>
    public class CreateUserPassRequest
    {
        /// <summary>
        /// The name of the token role.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
