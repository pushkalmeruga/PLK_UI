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
        public string ItemName { get; set; }
        public string ItemModel { get; set; }
        public string ItemType { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public List<ItemImage> ItemImages { get; set; }
    }
}
