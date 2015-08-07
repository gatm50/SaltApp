using Cheesebaron.MvxPlugins.Settings.Interfaces;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using SaltApp.Core.ViewModels;

namespace SaltApp.Core
{
    public class MyAppStart
    : MvxNavigatingObject
    , IMvxAppStart
    {
        public void Start(object hint = null)
        {
            var settings = Mvx.Resolve<ISettings>();
            if (string.IsNullOrEmpty(settings.GetValue<string>("AccessToken", string.Empty)))
                this.ShowViewModel<WelcomeViewModel>();
            else
                this.ShowViewModel<MainViewModel>();
        }
    }
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart(new MyAppStart());
        }
    }
}