using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLK__.ViewModels
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            ItemsList = new Item().GetItemsList();            
        }

        public ObservableCollection<Item> ItemsList { get; set; }
    }
}
