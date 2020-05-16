using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismFullNavigation.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        public ObservableCollection<string> MenuItemsList { get; set; }

        string _selectedItem;
        public string SelectedItem
        {
            get
            {
                return _selectedItem;

            }
            set
            {
                SetProperty(ref _selectedItem, value, "SelectedItem");
                NavigateToPageAsync();
            }
        }


        public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {

            MenuItemsList = new ObservableCollection<string>();
            MenuItemsList.Add("TabbedPage");
            MenuItemsList.Add("TabbedPage Runtime Create Pages");
            MenuItemsList.Add("TabbedPage - Modal Page");
            MenuItemsList.Add("TabbedPage Runtime - Modal Page");
            MenuItemsList.Add("PageParameters");
            MenuItemsList.Add("PageParameters - Push Detail");
            MenuItemsList.Add("PageParameters - Modal Page");
            MenuItemsList.Add("MasterDetail inside Detail Page");
            MenuItemsList.Add("MasterDetail inside TabbedPage");
            MenuItemsList.Add("RootPage");

        }


        private async Task NavigateToPageAsync()
        {
            if (SelectedItem != null)
            {
                var index = MenuItemsList.IndexOf(SelectedItem);

                switch (index)
                {
                    case 0:
                        var navResult = await NavigationService.NavigateAsync("NavigationPage/TabPageExample");
                        break;

                    case 1:
                         navResult = await NavigationService.NavigateAsync("NavigationPage/"+
                            "TabbedPageRuntime?" +
                            "createTab=Tab1Page&" +
                            "createTab=Tab2Page");

                        break;
                    case 2:
                        navResult = await NavigationService.NavigateAsync("NavigationPage/TabModalPage", useModalNavigation:true);
                        break;
                    case 3:

                        navResult = await NavigationService.NavigateAsync("NavigationPage/" +
                        "TabbedPageRuntimeModal?" +
                        "createTab=Tab1Page&" +
                        "createTab=Tab2Page", useModalNavigation: true);
                        break;
                    case 4:
                         navResult = await NavigationService.NavigateAsync("NavigationPage/Page1Page");
                        break;

                    case 5:
                        App.Instance.ClearDetailNavStack = false;
                        navResult = await NavigationService.NavigateAsync("NavigationPage/Page1ClearStackNavPage");
                        App.Instance.ClearDetailNavStack = true;
                        break;
                    case 6:
                        navResult = await NavigationService.NavigateAsync("NavigationPage/Page1ModalPage", useModalNavigation:true);
                        break;
                    case 7:
                         navResult = await NavigationService.NavigateAsync("NavigationPage/MenuMasterDetailPage");
                        break;
                    case 8:
                        navResult = await NavigationService.NavigateAsync("NavigationPage/TabbedMasterDetailPage");
                        break;
                    case 9:
                        navResult = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
                        break;
                }

                SelectedItem = null;
            }
        }
    }
}
