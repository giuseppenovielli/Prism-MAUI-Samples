using System.Windows.Input;
using PrismFullNavigation.Services.Data;
using PrismFullNavigation.Views;


namespace PrismFullNavigation.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand MasterDetailClickCommand { get; private set; }
        public ICommand TabbedPageClickCommand { get; private set; }
        public ICommand PageClickCommand { get; private set; }

        public ICommand PageModalClickCommand { get; private set; }
        public ICommand TabbedPageModalClickCommand { get; private set; }


        public MainPageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
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
            var navResult = await NavigationService.NavigateAsync(nameof(Page1Page));
        }

        private async Task TabbedPageClick()
        {
            var navResult = await NavigationService.NavigateAsync(nameof(TabPageExample));

        }

        private async Task MasterDetailClick()
        {
            var navResult = await NavigationService.NavigateAsync("/" + nameof(MenuMasterDetailPage) + "/" + nameof(NavigationPage) + "/" + nameof(Page1Page));
        }


        private async Task TabbedPageModalClick()
        {
            var result = await NavigationService.CreateBuilder()
                    .AddSegment(nameof(NavigationPage), useModalNavigation: true)
                    .AddSegment(nameof(TabModalPage))
                    .NavigateAsync();
        }

        private async Task PageModalClick()
        {
            var result = await NavigationService.CreateBuilder()
                    .AddSegment(nameof(NavigationPage), useModalNavigation: true)
                    .AddSegment(nameof(Page1ModalPage))
                    .NavigateAsync();
        }
    }
}
