using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class TabbedMasterDetailPageViewModel : BaseViewModel
    {
        public MenuMasterDetailPageViewModel MenuMasterDetailPageVM1 { get; set; }
        public MenuMasterDetailPageViewModel MenuMasterDetailPageVM2 { get; set; }
        public MenuMasterDetailPageViewModel MenuMasterDetailPageVM3 { get; set; }

        public TabbedMasterDetailPageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            //MenuMasterDetailPageVM1 = new MenuMasterDetailPageViewModel(navigationService);
            //MenuMasterDetailPageVM2 = new MenuMasterDetailPageViewModel(navigationService);
            //MenuMasterDetailPageVM3 = new MenuMasterDetailPageViewModel(navigationService);

        }


        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "MasterDetail inside TabbedPage";
        }
    }
}
