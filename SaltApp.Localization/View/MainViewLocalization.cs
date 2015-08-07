
namespace SaltApp.Localization.View
{
    public class MainViewLocalization
    {
        private Languages _language;
        public MainViewLocalization(Languages language)
        {
            _language = language;
        }

        public string GetExpirationString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Expiración";
                case Languages.English:
                    return "Expiration";
                case Languages.Portuguese:
                    return "Expiração";
                default:
                    return string.Empty;
            }
        }

        public string GetTitleDataString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "DATOS DISPONIBLES";
                case Languages.English:
                    return "DATA AVAILABLE";
                case Languages.Portuguese:
                    return "OS DADOS DISPONIVEIS";
                default:
                    return string.Empty;
            }
        }

        public string GetTitleSMSString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "SMS DISPONIBLES";
                case Languages.English:
                    return "SMS AVAILABLE";
                case Languages.Portuguese:
                    return "SMS DISPONIVEIS";
                default:
                    return string.Empty;
            }
        }

        public string GetTitleMinuteString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "MINUTOS DISPONIBLES";
                case Languages.English:
                    return "MINUTES AVAILABLE";
                case Languages.Portuguese:
                    return "MINUTOS DISPONIVEIS";
                default:
                    return string.Empty;
            }
        }

        public string GetSignoutCommandString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "cerrar sesion";
                case Languages.English:
                    return "sign out";
                case Languages.Portuguese:
                    return "fechar sessão";
                default:
                    return string.Empty;
            }
        }

        public string GetAboutCommandString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "acerca de SaltApp";
                case Languages.English:
                    return "about SaltApp";
                case Languages.Portuguese:
                    return "sobre o SaltApp";
                default:
                    return string.Empty;
            }
        }
    }
}
