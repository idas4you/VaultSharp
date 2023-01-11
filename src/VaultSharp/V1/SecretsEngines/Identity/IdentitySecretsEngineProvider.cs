using System.Net.Http;
using System.Threading.Tasks;
using VaultSharp.Core;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SecretsEngines.Identity
{
    internal class IdentitySecretsEngineProvider : IIdentitySecretsEngine
    {
        private readonly Polymath _polymath;

        public IdentitySecretsEngineProvider(Polymath polymath)
        {
            _polymath = polymath;
        }

        public async Task<Secret<IdentityToken>> GetTokenAsync(string roleName, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(roleName, "roleName");

            return await _polymath.MakeVaultApiRequest<Secret<IdentityToken>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Identity, "/oidc/token/" + roleName.Trim('/'), HttpMethod.Get, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<bool>> IntrospectTokenAsync(string token, string clientId = null, string mountPoint = null, string wrapTimeToLive = null)
        {
            Checker.NotNull(token, "token");

            return await _polymath.MakeVaultApiRequest<Secret<bool>>(mountPoint ?? _polymath.VaultClientSettings.SecretsEngineMountPoints.Identity, "/oidc/introspect", HttpMethod.Post, new { token, client_id = clientId }, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<IdentityInfo>> CreateEntity(CreateEntityReqeust createEntityReqeust, string wrapTimeToLive = null)
        {
            Checker.NotNull(createEntityReqeust, "createEntityReqeust");

            return await _polymath.MakeVaultApiRequest<Secret<IdentityInfo>>(_polymath.VaultClientSettings.SecretsEngineMountPoints.Identity, "/entity", HttpMethod.Post, createEntityReqeust, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<CreateEntityAliasInfo>> CreateEntityAlias(CreateEntityAliasInfo createEntityAliasInfo, string wrapTimeToLive = null)
        {
            Checker.NotNull(createEntityAliasInfo, "createEntityAliasInfo");
            return await _polymath.MakeVaultApiRequest<Secret<CreateEntityAliasInfo>>(_polymath.VaultClientSettings.SecretsEngineMountPoints.Identity, "/entity-alias", HttpMethod.Post, createEntityAliasInfo, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<IdentityInfo>> GetEntityByName(string name, string wrapTimeToLive = null)
        {
            Checker.NotNull(name, "name");
            return await _polymath.MakeVaultApiRequest<Secret<IdentityInfo>>(_polymath.VaultClientSettings.SecretsEngineMountPoints.Identity, "/entity/name/" + name, HttpMethod.Get, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task<Secret<IdentityInfo>> CreateEntityByName(string name, CreateEntityReqeust createEntityAliasReqeust, string wrapTimeToLive = null)
        {
            Checker.NotNull(name, "name");
            Checker.NotNull(createEntityAliasReqeust, "createEntityAliasReqeust");

            return await _polymath.MakeVaultApiRequest<Secret<IdentityInfo>>(_polymath.VaultClientSettings.SecretsEngineMountPoints.Identity, "/entity/name/" + name, HttpMethod.Post, createEntityAliasReqeust, wrapTimeToLive: wrapTimeToLive).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

        public async Task DeleteEntityByName(string name)
        {
            Checker.NotNull(name, "name");

            await _polymath.MakeVaultApiRequest(_polymath.VaultClientSettings.SecretsEngineMountPoints.Identity, "/entity/name/" + name, HttpMethod.Delete).ConfigureAwait(_polymath.VaultClientSettings.ContinueAsyncTasksOnCapturedContext);
        }

    }
}