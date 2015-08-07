using SaltApp.Core.Provider.Model;
using System.Net;
using System.Threading.Tasks;

namespace SaltApp.Core.Provider.Interfaces
{
    public interface IDataProvider
    {
        Task<HttpStatusCode> QueryServer(string accessToken, string telephoneNumber);
        DataModel ProcessResponse();
    }
}
