using Prism.Navigation;
using Xamarin.Forms;

namespace PrismFullNavigation.Views
{
    public class MasterDetailNavigationPage : NavigationPage, INavigationPageOptions
    {
        public bool ClearNavigationStackOnNavigation => false;

        public MasterDetailNavigationPage()
        {
        }

    }
}
