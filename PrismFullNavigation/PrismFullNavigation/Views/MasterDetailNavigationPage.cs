﻿using Prism.Navigation;
using Xamarin.Forms;

namespace PrismFullNavigation.Views
{
    public class MasterDetailNavigationPage : NavigationPage, INavigationPageOptions
    {
        public MasterDetailNavigationPage()
        {
        }


        public bool ClearNavigationStackOnNavigation
        {
            get { return true; }
        }

        public void Destroy()
        {

        }
        
    }
}
