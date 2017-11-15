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
        public async Task<ObservableCollection<Item>> GetItemsBasedOnFilter()
        {
            ProfileViewModel profile = new SQLiteHelper().GetUserProfile();

            var jsonFilterData = JsonConvert.SerializeObject(
                                   new
                                   {
                                        Location = profile.DefaultLocation,
                                        IsSold = false
                                   });

            string response = await RESTServiceHelper.PostData("/GetItems", jsonFilterData).ConfigureAwait(false);

            var items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(response);

            return items;

        }
      

        public async Task<bool> SaveItem(SellItemViewModel item)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(
                                       new
                                       {
                                           IsSold = item.IsSold,
                                           ItemType = item.ItemType,
                                           PartName = item.PartName,
                                           CustomerUserName = item.CustomerUserName,
                                           Model = item.Model,
                                           Brand = item.Brand,
                                           Price = item.Price,
                                           MobileNumber = item.MobileNumber,
                                           EmailId = item.EmailId,
                                           Location = item.Location,
                                           ItemImages = item.ItemImages
                                       });

                var result = await RESTServiceHelper.PostData("/saveItem", jsonData);

                return bool.Parse(result);
            }
            catch (Exception)
            {
                return false;
            }
        }                       
    }
}
