using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PLK__.ViewModels
{
    public class ViewItemViewModel
    {
        public ViewItemViewModel(Item item)
        {
            this.PartName = item.PartName;
            this.Model = item.Model;
            this.Brand = item.Brand;
            this.Price= item.Price;
            this.MobileNumber = item.MobileNumber;
            this.EmailId = item.EmailId;
            this.Description = item.Description;
            this.ItemImages = item.ItemImages;
        }

        public string PartName { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Description { get; set; }
        public List<byte[]> ItemImages { get; set; }

    }
}
