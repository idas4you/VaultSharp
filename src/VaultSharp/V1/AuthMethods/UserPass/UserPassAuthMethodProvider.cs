﻿using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task CreateUserPassAsync(string userName, string password, string mountPoint = AuthMethodDefaultPaths.UserPass)
        {
            Checker.NotNull(userName, "userName");
            Checker.NotNull(password, "password");

            await _polymath.MakeVaultApiRequest("v1/auth/" + mountPoint.Trim('/') + "/users/" + userName.Trim('/'), HttpMethod.Post, new { password }).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task UpdatePasswordAsync(string userName, string password, string mountPoint = AuthMethodDefaultPaths.UserPass)
        {
            Checker.NotNull(userName, "userName");
            Checker.NotNull(password, "password");

            await _polymath.MakeVaultApiRequest("v1/auth/" + mountPoint.Trim('/') + "/users/" + userName.Trim('/') + "/password", HttpMethod.Post, new { password }).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteUser(string userName, string mountPoint = AuthMethodDefaultPaths.UserPass)
        {
            Checker.NotNull(userName, "userName");

            await _polymath.MakeVaultApiRequest("v1/auth/" + mountPoint.Trim('/') + "/users/" + userName.Trim('/'), HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}
