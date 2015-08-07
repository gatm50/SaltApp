using Cirrious.MvvmCross.ViewModels;

namespace SaltApp.Core.ViewModels
{
    public class WelcomeViewModel : MvxViewModel
    {
        public WelcomeViewModel()
        {
            this.LoginCommand = new MvxCommand(this.Login_Execute);
        }

        #region Login Command
        public IMvxCommand LoginCommand { get; set; }
        void Login_Execute()
        {
            this.ShowViewModel<LoginViewModel>();
        }
        #endregion
    }
}
