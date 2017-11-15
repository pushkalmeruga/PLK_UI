﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PLK__
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var profile = new SQLiteHelper().GetUserProfile();

            if (profile != null)
            { 
               Navigation.PushAsync(new HamburgerPage(false));
            }

            InitializeComponent();

            BindingContext = new LoginViewModel();
        }

        async void RedirectToProfile(object o, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}
