using Cheesebaron.MvxPlugins.Settings.Interfaces;
using Cirrious.MvvmCross.ViewModels;
using SaltApp.Core.Provider;
using SaltApp.Core.Provider.Model;
using SaltApp.Localization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SaltApp.Core.ViewModels
{
    public class NameValueItem : INotifyPropertyChanged
    {
        public NameValueItem() { }

        public NameValueItem(KeyValuePair<string, string> baseObject)
        {
            this.Name = baseObject.Key;
            this.ValueString = baseObject.Value;
        }
        public string Name { get; set; }
        public double Value { get; set; }

        private string _valueString;
        public string ValueString
        {
            get { return _valueString; }
            set
            {
                _valueString = value;
                this.OnPropertyChanged("ValueString");
            }
        }
        public double MaxValue { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : MvxViewModel
    {
        private NameValueItem _dataUsage;
        public NameValueItem DataUsage
        {
            get { return _dataUsage; }
            set
            {
                _dataUsage = value;
                this.RaisePropertyChanged(() => this.DataUsage);
            }
        }

        private NameValueItem _minutesUsage;

        public NameValueItem VoiceUsage
        {
            get { return _minutesUsage; }
            set
            {
                _minutesUsage = value;
                this.RaisePropertyChanged(() => this.VoiceUsage);
            }
        }

        private NameValueItem _smsUsage;
        public NameValueItem SMSUsage
        {
            get { return _smsUsage; }
            set
            {
                _smsUsage = value;
                this.RaisePropertyChanged(() => this.SMSUsage);
            }
        }

        private string _currentTotal;
        public string CurrentTotal
        {
            get { return _currentTotal; }
            set
            {
                _currentTotal = value;
                this.RaisePropertyChanged(() => this.CurrentTotal);
            }
        }

        private string _expirationDate;
        public string ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                _expirationDate = value;
                this.RaisePropertyChanged(() => this.ExpirationDate);
            }
        }

        private string _currentTelephoneNumber;
        public string CurrentTelephoneNumber
        {
            get { return _currentTelephoneNumber; }
            set
            {
                _currentTelephoneNumber = value;
                this.RaisePropertyChanged(() => this.CurrentTelephoneNumber);
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

        public ObservableCollection<NameValueItem> DataPackages { get; set; }
        public ObservableCollection<NameValueItem> VoicePackages { get; set; }
        public ObservableCollection<NameValueItem> MessagesPackages { get; set; }


        private ISettings _settings;
        public MainViewModel(ISettings settings)
        {
            _settings = settings;
            this.VoiceUsage = new NameValueItem();
            this.DataUsage = new NameValueItem();
            this.SMSUsage = new NameValueItem();

            this.CurrentTotal = string.Empty;
            this.DataPackages = new ObservableCollection<NameValueItem>();
            this.VoicePackages = new ObservableCollection<NameValueItem>();
            this.MessagesPackages = new ObservableCollection<NameValueItem>();

            this.LogOutCommand = new MvxCommand<string>(this.LogOut_Execute);
        }

        public async void Init()
        {
            this.IsLoading = true;
            try
            {
                var provider = FactoryProvider.CreateDataProvider(Providers.TigoBolivia);
                var serverReponse = await provider.QueryServer(_settings.GetValue<string>("AccessToken", string.Empty), _settings.GetValue<string>("DefaultLine", string.Empty));

                if (serverReponse == System.Net.HttpStatusCode.OK)
                {
                    var model = provider.ProcessResponse();
                    this.ProcessCollection(model);
                    this.ProcessTotalValues(model);
                    this.CurrentTelephoneNumber = _settings.GetValue<string>("DefaultLine", string.Empty);
                }
            }
            catch (Exception)
            {
            }
            this.IsLoading = false;
        }

        private void ProcessCollection(DataModel model)
        {
            foreach (var item in model.DataCollection)
                this.DataPackages.Add(new NameValueItem(item));

            foreach (var item in model.SMSCollection)
                this.MessagesPackages.Add(new NameValueItem(item));

            foreach (var item in model.VoiceCollection)
                this.VoicePackages.Add(new NameValueItem(item));
        }

        private void ProcessTotalValues(DataModel model)
        {
            this.CurrentTotal = model.TotalAmount;
            this.ExpirationDate = string.Format("{0} {1}",
                LocalizationManager.Instance.MainView.GetExpirationString(),
                model.ExpirationDateTotalAmount);

            if (model.DataUsage > 99)
                this.DataUsage.ValueString = string.Format("{0} GB", Math.Round((model.DataUsage) / 1024, 2));
            else
                this.DataUsage.ValueString = string.Format("{0} MB", model.DataUsage);

            this.SMSUsage.ValueString = string.Format("{0} SMS", model.SMSUsage);
            this.VoiceUsage.ValueString = string.Format("{0} Min", model.VoiceUsage);
        }

        #region Log Out Command
        public IMvxCommand LogOutCommand { get; set; }
        void LogOut_Execute(object parameters)
        {
            _settings.DeleteValue("AccessToken");
            this.ShowViewModel<WelcomeViewModel>();
        }
        #endregion
    }
}
