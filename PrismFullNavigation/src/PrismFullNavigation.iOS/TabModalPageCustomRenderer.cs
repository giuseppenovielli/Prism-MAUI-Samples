using PrismFullNavigation.iOS;
using PrismFullNavigation.ViewModels;
using PrismFullNavigation.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabModalPage), typeof(TabModalPageCustomRenderer))]
namespace PrismFullNavigation.iOS
{
    public class TabModalPageCustomRenderer : PageRenderer
    {
        public TabModalPageCustomRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var leftItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
            {
                _ = ((Element as TabModalPage).BindingContext as TabModalPageViewModel).PopModalAsync();

            });
            NavigationController.TopViewController.NavigationItem.LeftBarButtonItem = leftItem;
        }
    }
}
