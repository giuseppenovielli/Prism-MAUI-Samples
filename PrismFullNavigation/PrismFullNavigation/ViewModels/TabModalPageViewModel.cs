using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class TabModalPageViewModel : BaseViewModel
    {
    
        public TabModalPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPage Modal";

        }

        public async Task PopModalAsync()
        {
            var navResult = await NavigationService.GoBackAsync(useModalNavigation: true);
        }
    }
}
