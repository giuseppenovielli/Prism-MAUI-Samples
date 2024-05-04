using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using PrismFullNavigation.Platforms.iOS.Renderers;
using PrismFullNavigation.ViewModels;
using PrismFullNavigation.Views;
using UIKit;

[assembly: ExportRenderer(typeof(Page1ModalPage), typeof(ModalPageCustomRenderer))]
[assembly: ExportRenderer(typeof(TabbedPageRuntimeModal), typeof(ModalPageCustomRenderer))]
[assembly: ExportRenderer(typeof(TabModalPage), typeof(ModalPageCustomRenderer))]
namespace PrismFullNavigation.Platforms.iOS.Renderers
{
    public class ModalPageCustomRenderer : PageRenderer
    {
        public ModalPageCustomRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var leftItem = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
            {
                _ = ((Element as ContentPage).BindingContext as BaseViewModel).PopModalAsync();

            });
            NavigationController.TopViewController.NavigationItem.LeftBarButtonItem = leftItem;
        }
    }
}

