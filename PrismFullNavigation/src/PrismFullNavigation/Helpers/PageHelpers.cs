using PrismFullNavigation.Extensions;

namespace PrismFullNavigation.Helpers
{
    public static class PageHelpers
	{
        public static Microsoft.Maui.Controls.Page GetCurrentPage()
        {
            var currentPage = Microsoft.Maui.Controls.Application.Current.MainPage;
            if (currentPage is Microsoft.Maui.Controls.FlyoutPage flyoutPage)
            {
                var flyoutPageDetail = flyoutPage.Detail;
                var navigation = flyoutPageDetail.Navigation;

                var navigationModalStack = navigation.ModalStack;
                if (navigationModalStack.Count() > 0)
                    return navigationModalStack.Last();

                var navigationStack = navigation.NavigationStack;
                return navigationStack.Last();
            }

            return currentPage;
        }

        public static bool IsCurrentPageModal() => GetCurrentPage().IsModal();
    }
}

