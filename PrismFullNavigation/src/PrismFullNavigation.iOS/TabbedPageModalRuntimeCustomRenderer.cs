using PrismFullNavigation.iOS;
using PrismFullNavigation.ViewModels;
using PrismFullNavigation.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPageRuntimeModal), typeof(TabbedPageModalRuntimeCustomRenderer))]
namespace PrismFullNavigation.iOS
{
    public class TabbedPageModalRuntimeCustomRenderer : PageRenderer
    {
        public TabbedPageModalRuntimeCustomRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var leftItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
            {
                _ = ((Element as TabbedPageRuntimeModal).BindingContext as TabbedPageRuntimeModalViewModel).PopModalAsync();

            });
            NavigationController.TopViewController.NavigationItem.LeftBarButtonItem = leftItem;
        }
    }
}
