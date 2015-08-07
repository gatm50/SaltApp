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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SaltApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : MvxWindowsPage
    {
        public new MainViewModel ViewModel
        {
            get { return (MainViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public MainView()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.InitializeLocalization();
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

        public void InitializeLocalization()
        {
            this.Minutes.Text = LocalizationManager.Instance.MainView.GetTitleMinuteString();
            this.Data.Text = LocalizationManager.Instance.MainView.GetTitleDataString();
            this.SMS.Text = LocalizationManager.Instance.MainView.GetTitleSMSString();

            this.logout.Label = LocalizationManager.Instance.MainView.GetSignoutCommandString();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.BackStack.Clear();

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
