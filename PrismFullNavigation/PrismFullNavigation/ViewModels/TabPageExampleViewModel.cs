using System;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class TabPageExampleViewModel : BaseViewModel
    {
        public Tab1PageViewModel TabPage1 { get; set; }
        public Tab2PageViewModel TabPage2 { get; set; }

        public TabPageExampleViewModel(INavigationService navigationService) : base(navigationService)
        {
            TabPage1 = new Tab1PageViewModel(navigationService);
            TabPage2 = new Tab2PageViewModel(navigationService);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            TitlePage = "TabbedPage";

            
        }
    }
}
