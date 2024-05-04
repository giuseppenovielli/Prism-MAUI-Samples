using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Ioc;
using PrismFullNavigation.Views;
using PrismFullNavigation.ViewModels;
using Prism.DryIoc;
using DryIoc;
using PrismFullNavigation.Services.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismFullNavigation
{
    public partial class App : VMApp
    {
        public static App Instance { get; private set; }
        public IContainer AppContainer { get; private set; }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }

        protected async override void OnInitialized()
        {
            base.OnInitialized();

            InitializeComponent();

            Instance = this;

            var navResult = await NavigationService.NavigateAsync("/" + nameof(NavigationPage) + "/" + nameof(MainPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterTypes(containerRegistry);

            containerRegistry.RegisterSingleton<IDataService, DataService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MasterDetailNavigationPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuMasterDetailPage, MenuMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<TabbedMasterDetailPage, TabbedMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<TabbedPageRuntimeModal, TabbedPageRuntimeModalViewModel>();
            containerRegistry.RegisterForNavigation<TabbedPageRuntime, TabbedPageRuntimeViewModel>();
            containerRegistry.RegisterForNavigation<TabModalPage, TabModalPageViewModel>();
            containerRegistry.RegisterForNavigation<TabPageExample, TabPageExampleViewModel>();
            containerRegistry.RegisterForNavigation<Page1ClearStackNavPage, Page1ClearStackNavPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1ModalPage, Page1ModalPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1Page, Page1PageViewModel>();
            containerRegistry.RegisterForNavigation<Page2Page, Page2PageViewModel>();
            containerRegistry.RegisterForNavigation<Tab1Page, Tab1PageViewModel>();
            containerRegistry.RegisterForNavigation<Tab2Page, Tab2PageViewModel>();
            
            AppContainer = containerRegistry.GetContainer();
        }
    }
}
