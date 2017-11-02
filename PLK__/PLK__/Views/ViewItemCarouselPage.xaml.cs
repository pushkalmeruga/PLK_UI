using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewItemCarouselPage : CarouselPage
    {
        public ViewItemCarouselPage(Item item)
        {
            BindingContext = item;
            //InitializeComponent();
        }
    }
}