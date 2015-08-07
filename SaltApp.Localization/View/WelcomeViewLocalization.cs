
namespace SaltApp.Localization.View
{
    public class WelcomeViewLocalization
    {
        private Languages _language;
        public WelcomeViewLocalization(Languages language)
        {
            _language = language;
        }

        public string GetCommentString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Una iniciativa de www.betterecosystem.com";
                case Languages.English:
                    return "An initiative of www.betterecosystem.com";
                case Languages.Portuguese:
                    return "Uma iniciativa de www.betterecosystem.com";
                default:
                    return string.Empty;
            }
        }

        public string GetLoginString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Entrar";
                case Languages.English:
                    return "Login";
                case Languages.Portuguese:
                    return "Entrar";
                default:
                    return string.Empty;
            }
        }

        public string GetRegisterString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Registro";
                case Languages.English:
                    return "Register";
                case Languages.Portuguese:
                    return "Registro";
                default:
                    return string.Empty;
            }
        }

        public string GetRegisterMessageString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Lamentablemente no podemos registrarlo por problemas tecnicos. Por favor registrese desde las aplicaciones oficiales.";
                case Languages.English:
                    return "Unfortunately we cannot register because there are technical troubles. Please create an account in the official Application.";
                case Languages.Portuguese:
                    return "Registro";
                default:
                    return string.Empty;
            }
        }
    }
}
