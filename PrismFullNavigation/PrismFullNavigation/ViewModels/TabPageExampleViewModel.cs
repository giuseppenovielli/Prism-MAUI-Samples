using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class TabPageExampleViewModel : BaseViewModel
    {
        public TabPageExampleViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPage";

        }
    }
}
