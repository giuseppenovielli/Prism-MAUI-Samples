using System;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class TabbedPageRuntimeViewModel : BaseViewModel
    {
    
        public TabbedPageRuntimeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPageRuntime";

        }
    }
}
