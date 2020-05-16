using System;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class TabbedMasterDetailPageViewModel : BaseViewModel
    {
        public TabbedMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "MasterDetail inside TabbedPage";
        }
    }
}
