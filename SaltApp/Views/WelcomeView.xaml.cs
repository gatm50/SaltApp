﻿using Cirrious.MvvmCross.WindowsCommon.Views;
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
using Windows.UI.Popups;
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
    public sealed partial class WelcomeView : MvxWindowsPage
    {
        public new WelcomeViewModel ViewModel
        {
            get { return (WelcomeViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public WelcomeView()
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
            this.Comment.Text = LocalizationManager.Instance.WelcomeView.GetCommentString();
            this.RegisterButton.Content = LocalizationManager.Instance.WelcomeView.GetRegisterString();
            this.LoginButton.Content = LocalizationManager.Instance.WelcomeView.GetLoginString();
        }

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

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog(LocalizationManager.Instance.WelcomeView.GetRegisterMessageString());
            await dialog.ShowAsync();
        }
    }
}
