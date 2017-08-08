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
    public partial class TabbedHomePage : TabbedPage
    {
        public TabbedHomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            SetHomePage();
        }

        private void SetHomePage()
        {
            this.Children.Add(new NavigationPage(new HomePage())
            {
                Title = "Items",
            });

            this.Children.Add(new NavigationPage(new ProfilePage())
            {
                Title = "Profile",
            });
        }
    }
}
