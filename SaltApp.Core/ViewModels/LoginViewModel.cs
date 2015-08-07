using Cheesebaron.MvxPlugins.Settings.Interfaces;
using Cirrious.MvvmCross.ViewModels;
using SaltApp.Core.Provider;
using SaltApp.Localization;
using System.Text;

namespace SaltApp.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                this.RaisePropertyChanged(() => this.UserName);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.RaisePropertyChanged(() => this.Password);
            }
        }

        private string _validationMessage;
        public string ValidationMessage
        {
            get { return _validationMessage; }
            set
            {
                _validationMessage = value;
                this.RaisePropertyChanged(() => this.ValidationMessage);
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                this.RaisePropertyChanged(() => this.IsLoading);
            }
        }

        private ISettings _settings;
        public LoginViewModel(ISettings settings)
        {
            _settings = settings;
            this.LoginCommand = new MvxCommand(this.Login_Execute);
            this.IsLoading = false;
        }

        #region Login Command
        public IMvxCommand LoginCommand { get; set; }
        async void Login_Execute()
        {
            if (!this.ValidateData())
                return;

            this.IsLoading = true;
            var authProvider = FactoryProvider.CreateAuthenticator(Providers.TigoBolivia);
            var authModel = await authProvider.Authenticate(this.UserName, this.Password);

            if (authModel == null)
                this.ValidationMessage = LocalizationManager.Instance.LoginView.GetNetworkProblemsMessageString();

            if (authModel.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _settings.AddOrUpdateValue("UserName", this.UserName);
                _settings.AddOrUpdateValue("Password", this.Password);
                _settings.AddOrUpdateValue("ProvideUserId", authModel.ProvideUserId);
                _settings.AddOrUpdateValue("DefaultLine", authModel.DefaultLine);
                _settings.AddOrUpdateValue("AccessToken", authModel.AccessToken);

                this.ShowViewModel<MainViewModel>();
            }
            else
            {
                if (authModel.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                    authModel.StatusCode == System.Net.HttpStatusCode.NotFound)
                    this.ValidationMessage = LocalizationManager.Instance.LoginView.GetCredentialValidationMessageString();
                else if (authModel.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                    this.ValidationMessage = LocalizationManager.Instance.LoginView.GetNetworkProblemsMessageString();
            }

            this.IsLoading = false;
        }
        #endregion

        private bool ValidateData()
        {
            this.ValidationMessage = string.Empty;
            bool isValid = true;
            var sb = new StringBuilder();

            if (string.IsNullOrEmpty(this.Password))
            {
                isValid = false;
                sb.AppendLine(LocalizationManager.Instance.LoginView.GetPasswordValidationMessageString());
            }
            if (string.IsNullOrEmpty(this.UserName))
            {
                isValid = false;
                sb.AppendLine(LocalizationManager.Instance.LoginView.GetUserNameValidationMessageString());
            }

            this.ValidationMessage = sb.ToString();
            return isValid;
        }
    }
}
