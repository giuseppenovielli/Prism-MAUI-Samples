using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class TabbedPageRuntimeModalViewModel : BaseViewModel
    {
    
        public TabbedPageRuntimeModalViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPageRuntimeModal";

        }


        public async Task PopModalAsync()
        {
            var navResult = await NavigationService.GoBackAsync(null, true, true);
        }
    }
}
