using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class TabbedPageRuntimeViewModel : BaseViewModel
    {
    
        public TabbedPageRuntimeViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPageRuntime";

        }
    }
}
