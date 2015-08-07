
using System.Net;
namespace SaltApp.Core.Provider.Model
{
    public class AuthenticationModel
    {
        public string ProvideUserId { get; set; }
        public string DefaultLine { get; set; }
        public string AccessToken { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
