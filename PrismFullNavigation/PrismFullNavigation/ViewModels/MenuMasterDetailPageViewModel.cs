using System;
using Prism.Commands;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class MenuMasterDetailPageViewModel : BaseViewModel, IMasterDetailPageOptions
    {
        public DelegateCommand PresentedChangedCommand { get; private set; }

        public MenuPageViewModel MenuPageViewModel { get; set; }

        //false => closed after open new detail page
        //true => Remain opened after open new detail page
        public bool IsPresentedAfterNavigation => false;

        public MenuMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PresentedChangedCommand = new DelegateCommand(PresentedChanged);

            MenuPageViewModel = new MenuPageViewModel(navigationService);
        }

        private void PresentedChanged()
        {
            System.Diagnostics.Debug.WriteLine("PresentedChanged");
        }
    }
}
