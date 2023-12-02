using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

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
