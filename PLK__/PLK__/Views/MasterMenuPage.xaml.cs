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
                case "Profile":
                    await Navigation.PushAsync(new ProfilePage());
                    break;
                case "Logout":
                    await new Login().Logout();
                    await Navigation.PushAsync(new LoginPage());
                    break;
                default:
                    await DisplayAlert("", "", "OK");
                    break;

            }            
        }
    }
}
