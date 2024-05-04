using System.Collections.ObjectModel;
using System.Diagnostics;
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

            MenuItemsList = new ObservableCollection<MenuItem>()
            {
                new MenuItem("0: TabbedPage"),
                new MenuItem("1: TabbedPage - Modal"),
                new MenuItem("2: TabbedPage Runtime"),
                new MenuItem("3: TabbedPage Runtime - Modal"),
                new MenuItem("4: PageParameters"),
                new MenuItem("5: PageParameters - Push Detail"),
                new MenuItem("6: PageParameters - Modal Page"),
                new MenuItem("7: MasterDetail inside Detail Page"),
                new MenuItem("8: MasterDetail inside TabbedPage"),
                new MenuItem("9: RootPage")
            };

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
                        var result = await NavigationService.CreateBuilder()
                            .AddSegment(nameof(NavigationPage), s => s.UseModalNavigation())
                            .AddSegment(nameof(TabModalPage))
                            .NavigateAsync();
                        break;

                    case 2:

                        navResult = await NavigationService.CreateBuilder()
                            .AddSegment(nameof(NavigationPage))
                            .AddTabbedSegment(
                                nameof(TabbedPageRuntime),
                                (Prism.Navigation.Builder.ITabbedSegmentBuilder obj) =>
                                {
                                    obj.CreateTab(nameof(Tab1Page));
                                    obj.CreateTab(nameof(Tab2Page));
                                })
                            .NavigateAsync();

                        break;
                    case 3:

                        navResult = await NavigationService.CreateBuilder()
                            .AddSegment(nameof(NavigationPage), useModalNavigation: true)
                            .AddTabbedSegment(
                                nameof(TabbedPageRuntimeModal),
                                (Prism.Navigation.Builder.ITabbedSegmentBuilder obj) =>
                                {
                                    obj.CreateTab(nameof(Tab1Page));
                                    obj.CreateTab(nameof(Tab2Page));
                                })
                            .NavigateAsync();

                        break;
                    case 4:
                        navResult = await NavigationService.NavigateAsync(nameof(NavigationPage) + "/" + nameof(Page1Page));
                        break;
                    case 5:

                        navResult = await NavigationService.CreateBuilder()
                            .AddSegment(nameof(NavigationPage))
                            .AddSegment(nameof(Page1ClearStackNavPage))
                            .NavigateAsync();

                        break;
                    case 6:
                        navResult = await NavigationService.CreateBuilder()
                            .AddSegment(nameof(NavigationPage), useModalNavigation:true)
                            .AddSegment(nameof(Page1ModalPage))
                            .NavigateAsync();
                        break;
                    case 7:
                        navResult = await NavigationService.CreateBuilder()
                                .AddSegment(nameof(MenuMasterDetailPage))
                                .AddSegment(nameof(NavigationPage))
                                .AddSegment(nameof(Page1Page))
                                .NavigateAsync();
                        break;
                    case 8:
                        navResult = await NavigationService.CreateBuilder()
                                .AddSegment(nameof(NavigationPage))
                                .AddSegment(nameof(TabbedMasterDetailPage))
                                .NavigateAsync();
                        break;
                    case 9:
                        navResult = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
                        break;
                }

                SelectedItem = null;
            }
        }

        private void PresentedChanged()
        {
            Debug.WriteLine("PresentedChanged");
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
