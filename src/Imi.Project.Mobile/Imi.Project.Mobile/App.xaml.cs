using FreshMvvm;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Api;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Imi.Project.Mobile.Domain.Services.Interfaces.NativeApi;
using Imi.Project.Mobile.Domain.Services.Mocking;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IGamesService>(new ApiGameService());
            FreshIOC.Container.Register<IOpeningsService>(new ApiOpeningService());
            FreshIOC.Container.Register<IEventService>(new ApiEventService());
            FreshIOC.Container.Register<IAuthService>(new AuthService());
            FreshIOC.Container.Register(DependencyService.Get<ISoundPlayer>());

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
