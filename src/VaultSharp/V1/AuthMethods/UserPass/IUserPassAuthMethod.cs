using System.Threading.Tasks;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.AuthMethods.UserPass
{
    public interface IUserPassAuthMethod
    {
        /// <summary>
        /// Create a new user or update an existing user. This path honors the distinction between the create and update capabilities inside ACL policies.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="mountPoint"></param>
        /// <returns></returns>
        Task CreateUserPassAsync(string userName, string password, string mountPoint = AuthMethodDefaultPaths.UserPass);


        /// <summary>
        /// Update password for an existing user.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="mountPoint"></param>
        /// <returns></returns>
        Task UpdatePasswordAsync(string userName, string password, string mountPoint = AuthMethodDefaultPaths.UserPass);

        /// <summary>
        /// This endpoint deletes the user from the method.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="mountPoint"></param>
        /// <returns></returns>
        Task DeleteUser(string userName, string mountPoint = AuthMethodDefaultPaths.UserPass);
    }
}