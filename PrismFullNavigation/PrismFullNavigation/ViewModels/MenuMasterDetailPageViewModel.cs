using Prism.Commands;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class MenuMasterDetailPageViewModel : BaseViewModel
    {
        public DelegateCommand PresentedChangedCommand { get; private set; }

        public MenuMasterDetailPageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "MasterDetail";
            PresentedChangedCommand = new DelegateCommand(PresentedChanged);
        }

        private void PresentedChanged()
        {
            System.Diagnostics.Debug.WriteLine("PresentedChanged");
        }
    }
}
