using Newtonsoft.Json.Linq;
using SaltApp.Core.Provider.Interfaces;
using SaltApp.Core.Provider.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SaltApp.Core.Provider.Concrete
{
    public class TBoliviaAuthenticationProvider : IAuthentication
    {
        public async Task<AuthenticationModel> Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
