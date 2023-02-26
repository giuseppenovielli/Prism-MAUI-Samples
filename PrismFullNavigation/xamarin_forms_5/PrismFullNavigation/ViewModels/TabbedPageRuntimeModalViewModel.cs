using System.Threading.Tasks;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class TabbedPageRuntimeModalViewModel : BaseViewModel
    {
    
        public TabbedPageRuntimeModalViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
        }

        public override void Initialize(
            INavigationParameters parameters)
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
