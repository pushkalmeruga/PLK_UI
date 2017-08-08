using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLK__.ViewModels;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewItemPage : ContentPage
    {
        public ViewItemPage(Item item)
        {
            InitializeComponent();

            BindingContext = new ViewItemViewModel(item);
        }

        private async void CallUser(object sender, EventArgs e)
        {
            try
            {
                bool res = await DisplayAlert("Do you want to call 9900595356..??", "", "Ok", "Cancel");

                if (res)
                {
                    IPhoneCallTask phoneDialer = CrossMessaging.Current.PhoneDialer;
                    if (phoneDialer.CanMakePhoneCall)
                        phoneDialer.MakePhoneCall("9900595356");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
