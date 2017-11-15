using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PLK__
{
    public class SellItemViewModel : INotifyPropertyChanged
    {
        public SellItemViewModel()
        {
            SaveItemCommand = new Command(async () => await SaveItem());
        }
        public bool IsSold { get; set; }
        public string ItemType { get; set; }
        public string PartName { get; set; }
        public string CustomerUserName { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public List<byte[]> ItemImages { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command SaveItemCommand { get; }

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task SaveItem()
        {
            var navigation = Application.Current.MainPage.Navigation;

            try
            {
                ItemsManager manager = new ItemsManager();

                var user = new SQLiteHelper().GetUserProfile();

                this.IsSold = false;
                this.CustomerUserName = user.UserName;
                this.EmailId = user.EmailId;
                this.Location = user.DefaultLocation;
                this.MobileNumber = user.MobileNumber;

                bool isSaved = await manager.SaveItem(this);

                if(isSaved)
                { 
                    //navigation.RemovePage(navigation.NavigationStack[navigation.NavigationStack.Count - 1]);
                    await navigation.PopAsync(true);
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Failure", "Item did not saved successfully. Try again", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Failure", "Item did not saved successfully. Try again", "Ok");
            }
        }
    }
}
