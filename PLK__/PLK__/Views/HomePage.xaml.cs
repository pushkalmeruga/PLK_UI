using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PLK__.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {       
        public HomePage()
        {
            InitializeComponent();

            ItemsList.ItemsSource = new ItemViewModel().ItemsList;
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            DisplayAlert("Item Selected", "", "Ok");

            Navigation.PushAsync(new ViewItemPage((Item)e.Item));
                       
            ((ListView)sender).SelectedItem = null;
        }

        private async void FilterItems(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterPage());
        }
    }
}
