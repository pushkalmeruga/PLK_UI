using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLK__
{
    public class MasterMenuViewModel
    {
        public string UserName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public static ObservableCollection<MasterMenu> GetMasterMenuItems()
        {
            return new ObservableCollection<MasterMenu>()
                {
                    new MasterMenu() {image =  "Profile.png",DisplayName = "Edit Profile"},
                    new MasterMenu() {image =  "SellItem.png", DisplayName = "Sell Item"},
                    new MasterMenu() {image =  "Logout.png", DisplayName = "Logout"}
                };
        }
    }
}
