using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenuPage : ContentPage
    {
        public MasterMenuPage()
        {
            InitializeComponent();           

            MenuItems.ItemsSource = MasterMenuViewModel.GetMasterMenuItems();
        }

        private async void OnMenuItemTap(object sender, ItemTappedEventArgs e)
        {
            var masterMenu = e.Item as MasterMenu;

            ((ListView)sender).SelectedItem = null;

            switch (masterMenu.DisplayName)
            {
                case "Edit Profile":
                    await Navigation.PushAsync(new ProfilePage());
                    break;
                case "Logout":
                    await new LoginManager().Logout();
                    await Navigation.PushAsync(new LoginPage());
                    break;
                case "Sell Item":
                    await Navigation.PushAsync(new SellItem());
                    break;
                default:
                    await DisplayAlert("", "", "OK");
                    break;

            }            
        }

        protected override void OnAppearing()
        {
            var user = new SQLiteHelper().GetUserProfile();

            BindingContext = new MasterMenuViewModel() { UserName = user.UserName, ProfilePicture = user.ProfilePicture };

            ProfilePicture.Source = ImageHelper.ToImageSource(user.ProfilePicture);
        }
    }
}
