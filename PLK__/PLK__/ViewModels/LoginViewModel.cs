using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PLK__
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            GetProfileDetailsCommand = new Command(async() => await GetProfileDetails(),() => !IsCallRunning);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isCallRunning = false;

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsCallRunning
        {
            get
            {
                return isCallRunning;
            }
            set
            {
                isCallRunning = value;
                OnPropertyChanged();
                GetProfileDetailsCommand.ChangeCanExecute();
            }
        }

        public Command GetProfileDetailsCommand { get; }

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        async Task GetProfileDetails()
        {
            try
            {
                IsCallRunning = true;
                bool isLoggedInSuccessfully = await new Login().GetProfile(this.Username, this.Password);
                IsCallRunning = false;
                if (isLoggedInSuccessfully)
                    await Application.Current.MainPage.Navigation.PushAsync(new HamburgerPage(false));
                else
                    await Application.Current.MainPage.DisplayAlert("Failed", "Username/Password invalid..!!", "OK");
            }
            catch (Exception ex)
            {
                IsCallRunning = false;
                await Application.Current.MainPage.DisplayAlert("Failed", "Something went wrong in the application..!!", "OK"); ;
            }
        }

    }
}
