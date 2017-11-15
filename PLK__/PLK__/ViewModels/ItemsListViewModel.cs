using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PLK__.ViewModels;

namespace PLK__
{
    public class ItemsListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _itemsList;
        public ObservableCollection<Item> ItemsList
        {
            get
            {
                if (_itemsList == null)
                {
                    return GetItemsBasedOnFilter().Result;
                    //return new ObservableCollection<Item>()
                    //{
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 100 },
                    //    new Item {Brand = "ASUS",PartName = "Camera",Price = 140 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 170 },
                    //    new Item {Brand = "ASUS",PartName = "Camera",Price = 10 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 134 },
                    //    new Item {Brand = "Lumia",PartName = "Camera",Price = 1522 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 134 },
                    //    new Item {Brand = "IPHONE",PartName = "Camera",Price = 112 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 10 },
                    //    new Item {Brand = "Micromax",PartName = "Camera",Price = 200 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 30 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 330 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 310 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 300 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 300 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 300 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 300 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 300 },
                    //    new Item {Brand = "Samsung",PartName = "Camera",Price = 300 }
                    //};
                }
                else
                    return _itemsList;
            }
            set
            {
                _itemsList = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task<ObservableCollection<Item>> GetItemsBasedOnFilter()
        {
            var items = await new ItemsManager().GetItemsBasedOnFilter().ConfigureAwait(false);
            return items;
        }
    }
}
