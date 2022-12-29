using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using VaultSharp.Core;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SecretsEngines.SSH
{
    internal class SSHSecretsEngineProvider : ISSHSecretsEngine
    {
        private readonly Polymath _polymath;

        public SSHSecretsEngineProvider(Polymath polymath)
        {
            _polymath = polymath;
        }

        public async Task<Secret<SSHCredentials>> GetCredentialsAsync(string roleName, string ipAddress, string username = null, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(roleName, "roleName");
            Checker.NotNull(ipAddress, "ipAddress");

            var requestData = new { ip = ipAddress, username = username };

            return await _polymath.MakeVaultApiRequest<Secret<SSHCredentials>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.SSH, "/creds/" + roleName.Trim('/'), HttpMethod.Post, requestData, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<SignedKeyResponse>> SignKeyAsync(string roleName, SignKeyRequest signKeyRequest, string mountPoint = null)
        {
            Checker.NotNull(roleName, "roleName");
            Checker.NotNull(signKeyRequest, "signKeyRequest");

            return await _polymath.MakeVaultApiRequest<Secret<SignedKeyResponse>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.SSH, "/sign/" + roleName.Trim('/'), HttpMethod.Post, signKeyRequest).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<SSHRoles>> ReadRole(string name, string mountPoint = null)
        {
            Checker.NotNull(name, "name");

            return await _polymath.MakeVaultApiRequest<Secret<SSHRoles>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.SSH, "/roles/" + name, HttpMethod.Get).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }


        public async Task<Secret<SignedKeyResponse>> CreateRole(string name, SSHRoles sshRoles, string mountPoint = null)
        {
            Checker.NotNull(name, "name");
            Checker.NotNull(sshRoles, "sshRoles");

            return await _polymath.MakeVaultApiRequest<Secret<SignedKeyResponse>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.SSH, "/roles/" + name, HttpMethod.Post, sshRoles).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteRole(string name, string mountPoint = null)
        {
            Checker.NotNull(name, "name");
            
            await _polymath.MakeVaultApiRequest(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.SSH, "/roles/" + name, HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<SSHCaInfo>> SubmitCaInformation(SubmitCARequest submitCARequest = null, string mountPoint = null)
        {
            submitCARequest = submitCARequest ?? new SubmitCARequest();

            return await _polymath.MakeVaultApiRequest<Secret<SSHCaInfo>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.SSH, "/config/ca", HttpMethod.Post, submitCARequest).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteCaInformation(string mountPoint = null)
        {
            await _polymath.MakeVaultApiRequest<Secret<SSHCaInfo>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.SSH, "/config/ca", HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }
    }
}