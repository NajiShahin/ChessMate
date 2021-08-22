using FreshMvvm;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RegistrationViewModel : FreshBasePageModel
    {
        private readonly IAuthService authService;
        public RegistrationViewModel(IAuthService authService)
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
                RaisePropertyChanged(nameof(username));
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(nameof(Email));
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

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                RaisePropertyChanged(nameof(DateOfBirth));
            }
        }

        private string streetName;

        public string StreetName
        {
            get { return streetName; }
            set
            {
                streetName = value;
                RaisePropertyChanged(nameof(StreetName));
            }
        }

        private int houseNumber;

        public int HouseNumber
        {
            get { return houseNumber; }
            set
            {
                houseNumber = value;
                RaisePropertyChanged(nameof(HouseNumber));
            }
        }

        private string postalCode;

        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                RaisePropertyChanged(nameof(PostalCode));
            }
        }

        private string cityName;

        public string CityName
        {
            get { return cityName; }
            set
            {
                cityName = value;
                RaisePropertyChanged(nameof(CityName));
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

        public ICommand Register => new Command(
           async () =>
           {
               try
               {

                   await authService.Register(Username, FirstName, LastName, Email, Password, DateOfBirth, StreetName, HouseNumber, PostalCode, CityName);
                   var token = await authService.GetToken(Username, Password);
                   if (token != null && token != "")
                   {
                       await SecureStorage.SetAsync("oauth_token", token);
                       await CoreMethods.PushPageModel<MainTabbedViewModel>();
                   }
                   else
                   {
                       LoginMessage = "An error occured";
                   }
               }
               catch
               {
                   LoginMessage = "An error occured";

               }
           }
       );

    }
}
