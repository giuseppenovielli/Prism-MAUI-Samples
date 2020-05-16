using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismFullNavigation.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand MasterDetailClickCommand { get; private set; }
        public ICommand TabbedPageClickCommand { get; private set; }
        public ICommand PageClickCommand { get; private set; }

        public ICommand PageModalClickCommand { get; private set; }
        public ICommand TabbedPageModalClickCommand { get; private set; }


        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            TitlePage = "StartPage";

            MasterDetailClickCommand = new Command(async () => await MasterDetailClick());
            TabbedPageClickCommand = new Command(async () => await TabbedPageClick());
            PageClickCommand = new Command(async () => await PageClickAsync());

            PageModalClickCommand = new Command(async () => await PageModalClick());
            TabbedPageModalClickCommand = new Command(async () => await TabbedPageModalClick());


        }


        private async Task PageClickAsync()
        {
            var navResult = await NavigationService.NavigateAsync("Page1Page");

        }

        private async Task TabbedPageClick()
        {
            var navResult = await NavigationService.NavigateAsync("TabPageExample");

        }

        private async Task MasterDetailClick()
        {
            var navResult = await NavigationService.NavigateAsync("/MenuMasterDetailPage/NavigationPage/Page1Page");
        }


        private async Task TabbedPageModalClick()
        {
            var navResult = await NavigationService.NavigateAsync("NavigationPage/TabModalPage", useModalNavigation:true);
        }

        private async Task PageModalClick()
        {
            var navResult = await NavigationService.NavigateAsync("NavigationPage/Page1ModalPage", useModalNavigation: true);

        }
    }
}
