using SaltApp.Localization.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltApp.Localization
{
    public enum Languages
    {
        Spanish,
        English,
        Portuguese
    }

    public class LocalizationManager
    {
        private static volatile LocalizationManager instance;
        private static object syncRoot = new Object();

        public static LocalizationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LocalizationManager();
                    }
                }

                return instance;
            }
        }

        public WelcomeViewLocalization WelcomeView { get; private set; }
        public MainViewLocalization MainView { get; private set; }
        public LoginViewLocalization LoginView { get; private set; }
        public AboutViewLocalization AboutView { get; private set; }

        public void InitializeObjects(Languages language)
        {
            this.WelcomeView = new WelcomeViewLocalization(language);
            this.MainView = new MainViewLocalization(language);
            this.LoginView = new LoginViewLocalization(language);
            //this.AboutView = new AboutViewLocalization(language);
        }
    }
}
