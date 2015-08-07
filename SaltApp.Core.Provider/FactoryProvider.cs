using SaltApp.Core.Provider.Concrete;
using SaltApp.Core.Provider.Interfaces;
using System;

namespace SaltApp.Core.Provider
{
    public enum Providers
    {
        TigoBolivia,
        VivaBolivia
    }

    public static class FactoryProvider
    {
        public static IAuthentication CreateAuthenticator(Providers provider)
        {
            switch (provider)
            {
                case Providers.TigoBolivia:
                    return new TBoliviaAuthenticationProvider();
                case Providers.VivaBolivia:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        public static IDataProvider CreateDataProvider(Providers provider)
        {
            switch (provider)
            {
                case Providers.TigoBolivia:
                    return new TBoliviaDataProvider();
                case Providers.VivaBolivia:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
