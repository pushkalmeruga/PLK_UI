using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PLK__
{
    class ItemsManager
    {      
        public async Task<ObservableCollection<Item>> GetItems()
        {
            SQLiteHelper sqlHelper = new SQLiteHelper();
            ProfileViewModel profile = sqlHelper.GetUserProfile();
            var jsonFilterData = JsonConvert.SerializeObject(
                                   new
                                   {
                                        ItemType = "",
	                                    Brand = "",
	                                    Model = "",
	                                    PartName = "",
	                                    CustomerUserName = "",
                                        Location = profile.DefaultLocation
                                   });
            string response = await RESTServiceHelper.PostData("/GetItems", jsonFilterData);

            var items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(response);

            return items;

        }
        public async void GetItemsBasedOnFilter()
        {
            SQLiteHelper sqlHelper = new SQLiteHelper();
            ProfileViewModel profile = sqlHelper.GetUserProfile();
            var jsonFilterData = JsonConvert.SerializeObject(
                   new
                   {
                       //UserName = userProfile.UserName,
                       //Password = userProfile.Password,
                       //FirstName = userProfile.FirstName,
                       //LastName = userProfile.LastName,
                       //EmailId = userProfile.EmailId,
                       //DefaultLocation = userProfile.DefaultLocation,
                       //MobileNumber = userProfile.MobileNumber
                   });
        }
    }
}
