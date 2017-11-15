using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLK__
{
    public class Item
    {
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
        public string Description { get; set; }
        public List<byte[]> ItemImages { get; set; }

    }
}
