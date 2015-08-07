using SaltApp.Core.Provider.Model;
using System.Threading.Tasks;

namespace SaltApp.Core.Provider.Interfaces
{
    public interface IAuthentication
    {
        Task<AuthenticationModel> Authenticate(string userName, string password);
    }
}
