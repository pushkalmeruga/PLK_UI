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

        internal ObservableCollection<Item> GetItemsList()
        {
            return new ObservableCollection<Item>()
                {
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 100 },
                    new Item {Brand = "ASUS",ItemName = "Camera",Price = 140 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 170 },
                    new Item {Brand = "ASUS",ItemName = "Camera",Price = 10 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 134 },
                    new Item {Brand = "Lumia",ItemName = "Camera",Price = 1522 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 134 },
                    new Item {Brand = "IPHONE",ItemName = "Camera",Price = 112 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 10 },
                    new Item {Brand = "Micromax",ItemName = "Camera",Price = 200 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 30 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 330 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 310 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 300 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 300 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 300 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 300 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 300 },
                    new Item {Brand = "Samsung",ItemName = "Camera",Price = 300 }
                };
        }

        public decimal Price { get; set; }

        public List<ItemImage> ItemImages { get; set; }


    }
}
