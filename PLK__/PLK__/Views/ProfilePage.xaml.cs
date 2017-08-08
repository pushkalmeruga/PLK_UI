using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            try
            {
                ProfileViewModel profile = new SQLiteHelper().GetUserProfile();

                if (profile != null && !profile.CanSaveAsNewUser)
                {
                    BindingContext = profile;
                    LocationList.Items.Add(profile.DefaultLocation);

                }
                else
                {
                    BindingContext = new ProfileViewModel();
                    LocationList.Items.ToList().AddRange(new List<string>
                {
                    "Hyderabad",
                    "Bangalore",
                    "Vizag",
                    "Amritsar",
                    "Ranchi",
                    "Delhi"
                });
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            InitializeComponent();
        }
    }
}
