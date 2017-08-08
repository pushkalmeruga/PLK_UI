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
    public partial class HamburgerPage : MasterDetailPage
    {
        public HamburgerPage(bool updateProfileInfo)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            RedirectToProfilePage(updateProfileInfo);            

            InitializeComponent();
        }

        private async void RedirectToProfilePage(bool updateProfileInfo)
        {
            if (updateProfileInfo)
            {
                bool result = await DisplayAlert("Update Details", "Please update the Mobile number and default location", "Ok", "Cancel");
                if (result)
                    await Navigation.PushAsync(new ProfilePage());
            }
        }
    }
}
