using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;
using PrismFullNavigation.Views;


namespace PrismFullNavigation.ViewModels
{
    public class MenuMasterDetailPageViewModel : BaseViewModel
    {
        public DelegateCommand PresentedChangedCommand { get; private set; }

        public ObservableCollection<MenuItem> MenuItemsList { get; set; }

        MenuItem _selectedItem;
        public MenuItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value, NavigateToPageAsync);
        }

        public MenuMasterDetailPageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "MasterDetail";
            PresentedChangedCommand = new DelegateCommand(PresentedChanged);

            MenuItemsList = new ObservableCollection<MenuItem>();

            MenuItemsList.Add(new MenuItem("TabbedPage"));
            MenuItemsList.Add(new MenuItem("TabbedPage - Modal"));
            MenuItemsList.Add(new MenuItem("TabbedPage Runtime"));
            MenuItemsList.Add(new MenuItem("TabbedPage Runtime - Modal"));
            MenuItemsList.Add(new MenuItem("PageParameters"));
            MenuItemsList.Add(new MenuItem("PageParameters - Push Detail - Working"));
            MenuItemsList.Add(new MenuItem("PageParameters - Push Detail - Not Working"));
            MenuItemsList.Add(new MenuItem("PageParameters - Modal Page"));
            MenuItemsList.Add(new MenuItem("MasterDetail inside Detail Page"));
            MenuItemsList.Add(new MenuItem("MasterDetail inside TabbedPage"));
            MenuItemsList.Add(new MenuItem("RootPage"));
        }

        private async void NavigateToPageAsync()
        {
            if (SelectedItem != null)
            {
                var index = MenuItemsList.IndexOf(SelectedItem);

                switch (index)
                {
                    case 0:
                        var navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(TabPageExample));
                        break;

                    case 1:
                        //navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(TabModalPage), useModalNavigation: true);
                        break;

                    case 2:
                        navResult = await NavigationService.NavigateAsync("NavigationPage/" +
                            "TabbedPageRuntime?" +
                            "createTab=Tab1Page&" +
                            "createTab=Tab2Page");
                        break;
                    case 3:
                        //navResult = await NavigationService.NavigateAsync("NavigationPage/" +
                        //    "TabbedPageRuntimeModal?" +
                        //    "createTab=Tab1Page&" +
                        //    "createTab=Tab2Page", useModalNavigation: true);
                        break;
                    case 4:
                        navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(Page1Page));
                        break;
                    case 5:
                        DataService.ClearDetailPageStack = false;
                        navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(Page1ClearStackNavPage));
                        DataService.ClearDetailPageStack = true;
                        break;
                    case 6:
                        navResult = await NavigationService.NavigateAsync(nameof(MasterDetailNavigationPage) + "/" + nameof(Page1ClearStackNavPage));
                        break;
                    case 7:
                        //navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(Page1ModalPage), useModalNavigation: true);
                        break;
                    case 8:
                        navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(MenuMasterDetailPage) + "/" + nameof(NavigationPage) + "/" + nameof(Page1Page));
                        break;
                    case 9:
                        navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(TabbedMasterDetailPage));
                        break;
                    case 10:
                        navResult = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
                        break;
                }

                SelectedItem = null;
            }
        }

        private void PresentedChanged()
        {
            System.Diagnostics.Debug.WriteLine("PresentedChanged");
        }
    }

    public class MenuItem
    {
        public string Item { get; set; }

        public MenuItem(string item)
        {
            Item = item;
        }
    }
}
