using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Plugin.Media;
using System.IO;
using Plugin.Media.Abstractions;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private ProfileViewModel profileViewModel = new ProfileViewModel();
        public ProfilePage()
        {
            InitializeComponent();

            try
            {
                ProfileViewModel profile = new SQLiteHelper().GetUserProfile();

                if (profile != null && !profile.CanSaveAsNewUser)
                {
                    BindingContext = profileViewModel = profile;

                    if (profile.ProfilePicture == null)
                        ProfilePicture.Source = "Profile.png";
                }
                else
                {
                    ProfilePicture.Source = "Profile.png";
                    BindingContext = new ProfileViewModel();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void ChangeImageEvent(object sender, EventArgs e)
        {
            string res = await DisplayActionSheet("Click on any button to continue", "", "Cancel", new string[] {"Take Picture", "Select Picture","Remove Picture" });

            switch (res)
            {
                case "Take Picture":
                    TakePicture();
                    break;
                case "Select Picture":
                    SelectPicture();
                    break;
                case "Remove Picture":
                    RemovePicture();
                    break;
            }            
        }

        private void RemovePicture()
        {
            ProfilePicture.Source = ImageHelper.ToImageSource();

            profileViewModel.ProfilePicture = null;
        }

        private async void TakePicture()
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "Camera is in action", "ok");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                AllowCropping = true,
                CompressionQuality = 45,
                SaveToAlbum = true,
                Name = DateTime.Now.ToString(),
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
                return;

            UpdateProfilePicture(file);

        }

        private async void SelectPicture()
        {            
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "Error in seletcing the picture", "ok");
                return;
            }

            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                CompressionQuality = 45,
                PhotoSize = PhotoSize.Medium
            });

            if (file == null)
                return;

            UpdateProfilePicture(file);
        }

        private void UpdateProfilePicture(MediaFile file)
        {
            MemoryStream memoryStream = new MemoryStream();

            Stream stream = file.GetStream();

            ProfilePicture.Source = ImageSource.FromStream(() => file.GetStream());

            stream.CopyTo(memoryStream);

            profileViewModel.ProfilePicture = memoryStream.ToArray();
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}
