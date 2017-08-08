using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLK__.ViewModels
{
    public class ViewItemViewModel
    {
        public Item SelectedItem { get; set; }

        public ViewItemViewModel(Item item)
        {
            this.SelectedItem = item;
        }
    }
}
