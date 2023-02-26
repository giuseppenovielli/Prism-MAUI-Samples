using PrismFullNavigation.iOS;
using PrismFullNavigation.ViewModels;
using PrismFullNavigation.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Page1ModalPage), typeof(Page1ModalPageCustomRenderer))]
namespace PrismFullNavigation.iOS
{
    public class Page1ModalPageCustomRenderer : PageRenderer
    {
        public Page1ModalPageCustomRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var leftItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
            {
                _ = ((Element as Page1ModalPage).BindingContext as Page1ModalPageViewModel).PopModalAsync();

            });
            NavigationController.TopViewController.NavigationItem.LeftBarButtonItem = leftItem;
        }
    }
}
