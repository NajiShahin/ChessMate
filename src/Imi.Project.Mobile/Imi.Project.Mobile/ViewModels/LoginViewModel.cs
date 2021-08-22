using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Imi.Project.Mobile.Domain.Services.Interfaces;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        private readonly IAuthService authService;
        public LoginViewModel(IAuthService authService)
        {
            this.authService = authService;
        }

        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private string loginMessage;

        public string LoginMessage
        {
            get { return loginMessage; }
            set
            {
                loginMessage = value;
                RaisePropertyChanged(nameof(LoginMessage));
            }
        }


        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            LoginMessage = "";
        }

        public ICommand GoToTabbedPage => new Command(
            async () => {
                if (Username != null && Password != null && Username != "" && Password != "")
                {
                    var token = await authService.GetToken(Username, Password);
                    if (token != null && token != "")
                    {
                        await SecureStorage.SetAsync("oauth_token", token);
                        await CoreMethods.PushPageModel<MainTabbedViewModel>();
                    }
                    else
                    {
                        LoginMessage = "You have filled in a wrong Username and/or password.";
                    }
                }
                else
                {
                    LoginMessage = "Fill in the fields";
                }
            }
        );


        public ICommand Register => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<RegistrationViewModel>();
            }

        );
    }
}
