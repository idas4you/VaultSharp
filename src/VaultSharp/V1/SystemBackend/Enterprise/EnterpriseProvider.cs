﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SystemBackend.Enterprise
{
    /// <summary>
    /// Enterprise System backend APIs
    /// </summary>
    internal class EnterpriseProvider : IEnterprise
    {
        private readonly Polymath _polymath;

        public EnterpriseProvider(Polymath polymath)
        {
            _polymath = polymath;
        }

        public async Task<Secret<ControlGroup>> GetControlGroupConfigAsync()
        {
            return await _polymath.MakeVaultApiRequest<Secret<ControlGroup>>("v1/sys/config/control-group", HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task ConfigureControlGroupAsync(string maxTimeToLive)
        {
            await _polymath.MakeVaultApiRequest("v1/sys/config/control-group", HttpMethod.Put, new { max_ttl = maxTimeToLive }).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteControlGroupConfigAsync()
        {
            await _polymath.MakeVaultApiRequest("v1/sys/config/control-group", HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<ControlGroupRequestStatus>> AuthorizeControlGroupAsync(string accessor)
        {
            return await _polymath.MakeVaultApiRequest<Secret<ControlGroupRequestStatus>>("v1/sys/control-group/authorize", HttpMethod.Post, new { accessor = accessor }).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<ControlGroupRequestStatus>> CheckControlGroupStatusAsync(string accessor)
        {
            return await _polymath.MakeVaultApiRequest<Secret<ControlGroupRequestStatus>>("v1/sys/control-group/request", HttpMethod.Post, new { accessor = accessor }).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<License>> GetLicenseAsync()
        {
            return await _polymath.MakeVaultApiRequest<Secret<License>>("v1/sys/license", HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task InstallLicenseAsync(string licenseText)
        {
            var requestData = new
            {
                text = licenseText
            };

            await _polymath.MakeVaultApiRequest<Secret<License>>("v1/sys/license", HttpMethod.Put, requestData).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<ListInfo>> GetRGPPoliciesAsync()
        {
            return await _polymath.MakeVaultApiRequest<Secret<ListInfo>>("v1/sys/policies/rgp?list=true", HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<RGPPolicy>> GetRGPPolicyAsync(string policyName)
        {
            return await _polymath.MakeVaultApiRequest<Secret<RGPPolicy>>("v1/sys/policies/rgp/" + policyName, HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task WriteRGPPolicyAsync(RGPPolicy policy)
        {
            var requestData = new
            {
                policy = policy.Policy
            };

            await _polymath.MakeVaultApiRequest("v1/sys/policies/rgp/" + policy.Name, HttpMethod.Put, requestData).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteRGPPolicyAsync(string policyName)
        {
            await _polymath.MakeVaultApiRequest("v1/sys/policies/rgp/" + policyName, HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<ListInfo>> GetEGPPoliciesAsync()
        {
            return await _polymath.MakeVaultApiRequest<Secret<ListInfo>>("v1/sys/policies/egp?list=true", HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<EGPPolicy>> GetEGPPolicyAsync(string policyName)
        {
            return await _polymath.MakeVaultApiRequest<Secret<EGPPolicy>>("v1/sys/policies/egp/" + policyName, HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task WriteEGPPolicyAsync(EGPPolicy policy)
        {
            var requestData = new
            {
                policy = policy.Policy
            };

            await _polymath.MakeVaultApiRequest("v1/sys/policies/egp/" + policy.Name, HttpMethod.Put, requestData).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteEGPPolicyAsync(string policyName)
        {
            await _polymath.MakeVaultApiRequest("v1/sys/policies/egp/" + policyName, HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<NamespaceList>> ReadAllNameSpaceAsync()
        {
            return await _polymath.MakeVaultApiRequest<Secret<NamespaceList>>("v1/sys/namespaces?list=true", HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<NamespaceInfo>> CreateNameSpaceAsync(string path, Dictionary<string, string> customMetadata)
        {
            return await _polymath.MakeVaultApiRequest<Secret<NamespaceInfo>>("v1/sys/namespaces/" + path, HttpMethod.Post, customMetadata).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<NamespaceInfo>> ReadNameSpaceAsync(string path)
        {
            return await _polymath.MakeVaultApiRequest<Secret<NamespaceInfo>>("v1/sys/namespaces/" + path, HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<NamespaceInfo>> DeleteNameSpaceAsync(string path)
        {
            return await _polymath.MakeVaultApiRequest<Secret<NamespaceInfo>>("v1/sys/namespaces/" + path, HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}