using System.Collections.Generic;

namespace SaltApp.Core.Provider.Model.Providers
{
    public class Detail
    {
        public string ix { get; set; }
        public string wallet { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public string expirationDate { get; set; }
        public double balanceAmount { get; set; }
    }

    public class TResponse
    {
        public List<Detail> wallets { get; set; }
    }

    public class TBoliviaApiResponse
    {
        public TResponse response { get; set; }
    }

    public class TBoliviaRootObject
    {
        public TBoliviaApiResponse TigoApiResponse { get; set; }
    }
}
