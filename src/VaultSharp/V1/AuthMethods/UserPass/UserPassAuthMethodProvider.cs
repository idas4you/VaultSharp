using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.AuthMethods.UserPass
{
    internal class UserPassAuthMethodProvider : IUserPassAuthMethod
    {
        private readonly Polymath _polymath;

        public UserPassAuthMethodProvider(Polymath polymath)
        {
            Checker.NotNull(polymath, "polymath");
            this._polymath = polymath;
        }

        public async Task CreateUserPassAsync(string userName, CreateUserPassRequest createUserpassRequest)
        {
            Checker.NotNull(createUserpassRequest, "createUserpassRequest");

            await _polymath.MakeVaultApiRequest("v1/auth/userpass/users/" + userName, HttpMethod.Post, createUserpassRequest).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}
