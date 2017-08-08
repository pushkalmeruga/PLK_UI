using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PLK__
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public ProfileViewModel()
        {
            SaveProfileCommand = new Command(async () => await SaveUserProfile(), () => !IsCallRunning);
        }
        private bool isCallRunning = false;
        private bool canSaveAsNewUser = true;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string DefaultLocation { get; set; }
        public bool CanSaveAsNewUser {
            get
            {
                return canSaveAsNewUser;
            }
            set
            {
                canSaveAsNewUser = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UserName));
            }
        }
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
                SaveProfileCommand.ChangeCanExecute();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command SaveProfileCommand { get; }

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task SaveUserProfile()
        {
            try
            {
                Profile profile = new Profile();
                string response;

                IsCallRunning = true;

                if (CanSaveAsNewUser)
                    response = await profile.SaveProfile(this);
                else
                    response = await profile.UpdateProfile(this);

                IsCallRunning = false;

                if(response == "true")
                    await Application.Current.MainPage.Navigation.PushAsync(new HamburgerPage(false));
                else
                    await Application.Current.MainPage.DisplayAlert("Failure", response, "Ok");
            }
            catch (Exception)
            {
                IsCallRunning = false;

                await Application.Current.MainPage.DisplayAlert("Failure", "User did not saved successfully. Try again", "Ok");
            }
        }
    }
}
