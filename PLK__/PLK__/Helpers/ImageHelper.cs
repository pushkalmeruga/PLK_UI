using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace PLK__
{
    public class ImageHelper
    {
        public static ImageSource ToImageSource(byte[] image = null)
        {
            if (image != null)
                return ImageSource.FromStream(() => new MemoryStream(image));
            else
                return ImageSource.FromFile("Profile.png");
        }

        public static async Task<MediaFile> TakePicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Camera is in action", "ok");
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                AllowCropping = true,
                CompressionQuality = 45,
                SaveToAlbum = true,
                Name = DateTime.Now.ToString(),
                PhotoSize = PhotoSize.Medium
            });

            if (file == null)
                await Application.Current.MainPage.DisplayAlert("Error", "Unhandled Error occured", "ok");

            return file;
        }

        public static async Task<MediaFile> SelectPicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error in seletcing the picture", "ok");
            }

            MediaFile file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                CompressionQuality = 45,
                PhotoSize = PhotoSize.Medium
            });

            if (file == null)
                await Application.Current.MainPage.DisplayAlert("Error", "Unhandled Error occured", "ok");

            return file;
        }
    }
}
