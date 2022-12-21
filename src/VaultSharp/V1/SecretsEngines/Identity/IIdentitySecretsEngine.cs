using System.Threading.Tasks;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.SecretsEngines.Identity
{
    /// <summary>
    /// Identity Secrets Engine.
    /// </summary>
    public interface IIdentitySecretsEngine
    {
        /// <summary>
        /// Use this endpoint to generate a signed ID (OIDC) token.
        /// </summary>
        /// <param name="roleName"><para>[required]</para>
        /// The name of the role against which to generate a signed ID token.
        /// </param>
        /// <param name="mountPoint"><para>[optional]</para>
        /// The mount point for the backend. Defaults to <see cref="SecretsEngineMountPoints.Identity" />
        /// Provide a value only if you have customized the Azure mount point.</param>
        /// <param name="wrapTimeToLive">
        /// <para>[optional]</para>
        /// The TTL for the token and can be either an integer number of seconds or a string duration of seconds.
        /// </param>
        /// <returns>
        /// The secret with the <see cref="IdentityToken" /> as the data.
        /// </returns>
        Task<Secret<IdentityToken>> GetTokenAsync(string roleName, string mountPoint = null, string wrapTimeToLive = null);

        /// <summary>
        /// This endpoint can verify the authenticity and active state of a signed ID token.
        /// </summary>
        /// <param name="token"><para>[required]</para>
        /// A signed OIDC compliant ID token.
        /// </param>
        /// <param name="clientId"><para>[optional]</para>
        /// Specifying the client ID optimizes validation time
        /// </param>
        /// <param name="mountPoint"><para>[optional]</para>
        /// The mount point for the backend. Defaults to <see cref="SecretsEngineMountPoints.Identity" />
        /// Provide a value only if you have customized the Azure mount point.</param>
        /// <param name="wrapTimeToLive">
        /// <para>[optional]</para>
        /// The TTL for the token and can be either an integer number of seconds or a string duration of seconds.
        /// </param>
        /// <returns>
        /// Indicates if the token is active.
        /// </returns>
        Task<Secret<bool>> IntrospectTokenAsync(string token, string clientId = null, string mountPoint = null, string wrapTimeToLive = null);

        /// <summary>
        /// This endpoint creates or updates an Entity.
        /// </summary>
        /// <param name="createEntityReqeust"></param>
        /// <returns></returns>
        Task<Secret<IdentityInfo>> CreateEntity(CreateEntityReqeust createEntityReqeust, string wrapTimeToLive = null);

        /// <summary>
        /// This endpoint queries the entity by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Secret<IdentityInfo>> GetEntityById(string id, string wrapTimeToLive = null);

        /// <summary>
        /// This endpoint creates a new alias for an entity.
        /// </summary>
        /// <param name="createEntityAliasReqeust"></param>
        /// <returns></returns>
        Task<Secret<CreateEntityAliasInfo>> CreateEntityAlias(CreateEntityAliasInfo createEntityAliasReqeust, string wrapTimeToLive = null);
    }
}