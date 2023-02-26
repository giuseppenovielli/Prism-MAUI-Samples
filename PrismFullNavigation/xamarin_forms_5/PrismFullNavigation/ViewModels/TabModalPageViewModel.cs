using System.Threading.Tasks;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class TabModalPageViewModel : BaseViewModel
    {
        public TabModalPageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPage Modal";

        }

        public async Task PopModalAsync()
        {
            var navResult = await NavigationService.GoBackAsync(null, true, true);
        }
    }
}
