using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PrismFullNavigation.Views
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            On<iOS>().SetUseSafeArea(true);

        }
    }
}
