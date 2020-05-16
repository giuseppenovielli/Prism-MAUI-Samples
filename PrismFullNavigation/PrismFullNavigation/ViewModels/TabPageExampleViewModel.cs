using System;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class TabPageExampleViewModel : BaseViewModel
    {
    
        public TabPageExampleViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPage";

        }
    }
}
