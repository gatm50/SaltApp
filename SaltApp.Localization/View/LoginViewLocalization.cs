using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltApp.Localization.View
{
    public class LoginViewLocalization
    {
        private Languages _language;
        public LoginViewLocalization(Languages language)
        {
            _language = language;
        }

        public string GetUserNameString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Nombre de Usuario";
                case Languages.English:
                    return "User Name";
                case Languages.Portuguese:
                    return "Nome de Utilizador";
                default:
                    return string.Empty;
            }
        }

        public string GetPasswordString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Contraseña";
                case Languages.English:
                    return "Password";
                case Languages.Portuguese:
                    return "Senha";
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

        public string GetUserNameValidationMessageString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "! El nombre de usurio es requerido";
                case Languages.English:
                    return "! The User Name is Required";
                case Languages.Portuguese:
                    return "Entrar";
                default:
                    return string.Empty;
            }
        }

        public string GetPasswordValidationMessageString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "! La Contraseña es requerida";
                case Languages.English:
                    return "! The password is required";
                case Languages.Portuguese:
                    return "Entrar";
                default:
                    return string.Empty;
            }
        }
        public string GetCredentialValidationMessageString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Sus credenciales no son validas";
                case Languages.English:
                    return "Your credetials are not valid";
                case Languages.Portuguese:
                    return "Entrar";
                default:
                    return string.Empty;
            }
        }

        public string GetNetworkProblemsMessageString()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Intente de nuevo, la red esta inestable";
                case Languages.English:
                    return "Please Try again, network problems";
                case Languages.Portuguese:
                    return "Entrar";
                default:
                    return string.Empty;
            }
        }
    }
}
