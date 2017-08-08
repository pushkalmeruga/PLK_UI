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
        public static ObservableCollection<MasterMenu> GetMasterMenuItems()
        {
            return new ObservableCollection<MasterMenu>()
                {
                    new MasterMenu() {image =  "https://d30y9cdsu7xlg0.cloudfront.net/png/9355-200.png",DisplayName = "Profile"},
                    new MasterMenu() {image =  "https://d30y9cdsu7xlg0.cloudfront.net/png/9355-200.png",DisplayName = "Sell Item"},
                    new MasterMenu() {image =  "https://d30y9cdsu7xlg0.cloudfront.net/png/9355-200.png",DisplayName = "Logout"}
                };
        }
    }
}
