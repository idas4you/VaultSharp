using System.Threading.Tasks;
using VaultSharp.V1.Commons;

namespace VaultSharp.V1.AuthMethods.UserPass
{
    public interface IUserPassAuthMethod
    {

        Task CreateUserPassAsync(string userName, CreateUserPassRequest createUserpassRequest);
    }
}