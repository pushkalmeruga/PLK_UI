using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellItem : ContentPage
    {
        public SellItemViewModel sellItemViewModel = new SellItemViewModel() { ItemImages = new List<byte[]>() };

        public SellItem()
        {
            InitializeComponent();
            BindingContext = sellItemViewModel;
        }

        private async void OnPlusIconTapped(object sender, EventArgs e)
        {
            string res = await DisplayActionSheet("Click on any button to continue", "", "Cancel", new string[] { "Take Picture", "Select Picture" });

            switch (res)
            {
                case "Take Picture":
                    TakePicture();
                    break;
                case "Select Picture":
                    SelectPicture();
                    break;
            }
        }

        private async void OnItemImageTapped(object sender, EventArgs e)
        {
            string res = await DisplayActionSheet("Click on any button to continue", "", "Cancel", new string[] { "View Picture", "Remove Picture" });

            switch (res)
            {
                case "View Picture":
                    TakePicture();
                    break;
                case "Remove Picture":
                    RemovePicture();
                    break;
            }
        }

        private void RemovePicture()
        {
            //ProfilePicture.Source = ImageHelper.ToImageSource();

            //profileViewModel.ProfilePicture = null;
        }

        private async void TakePicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
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

            UpdateItemImage(file);
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

            UpdateItemImage(file);
        }

        private void UpdateItemImage(MediaFile file)
        {
            try
            {
                TapGestureRecognizer tapper = new TapGestureRecognizer();
                tapper.Tapped += OnItemImageTapped;
                tapper.NumberOfTapsRequired = 1;

                MemoryStream memoryStream = new MemoryStream();

                Stream stream = file.GetStream();

                stream.CopyTo(memoryStream);

                Image image = new Image()
                {
                    Source = ImageSource.FromStream(() => file.GetStream()),
                    HeightRequest = 75,
                    WidthRequest = 75
                };
                
                image.GestureRecognizers.Add(tapper);

                ItemImages.Children.Add(image);

                ImagesScrollView.Content = ItemImages;

                sellItemViewModel.ItemImages.Add(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}