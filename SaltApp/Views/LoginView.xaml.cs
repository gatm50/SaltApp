using Cirrious.MvvmCross.WindowsCommon.Views;
using SaltApp.Common;
using SaltApp.Core.ViewModels;
using SaltApp.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SaltApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : MvxWindowsPage
    {
        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public LoginView()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.InitializeLocalization();
        }

        public void InitializeLocalization()
        {
            this.UserName.Text = LocalizationManager.Instance.LoginView.GetUserNameString();
            this.Password.Text = LocalizationManager.Instance.LoginView.GetPasswordString();
            this.Login.Content = LocalizationManager.Instance.LoginView.GetLoginString();
        }

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
                ViewModel = null;

            base.OnNavigatedTo(e);
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            navigationHelper.OnNavigatedFrom(e);
        }
    }
}
