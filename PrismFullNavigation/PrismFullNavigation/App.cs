using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Ioc;
using Prism.DryIoc;
using PrismFullNavigation.Views;
using PrismFullNavigation.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismFullNavigation
{
    public partial class App : PrismApplication
    {
        public static App Instance { get; private set; }
        public bool ClearDetailNavStack { get; set; }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }

        protected async override void OnInitialized()
        {
            InitializeComponent();

            Instance = this;

            ClearDetailNavStack = true;


           var navResult = await NavigationService.NavigateAsync("/NavigationPage/MainPage");
           // var navResult = await NavigationService.NavigateAsync("/MenuMasterDetailPage/NavigationPage/TabPageExample");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuMasterDetailPage, MenuMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1ClearStackNavPage, Page1ClearStackNavPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1ModalPage, Page1ModalPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1Page, Page1PageViewModel>();
            containerRegistry.RegisterForNavigation<Page2Page, Page2PageViewModel>();
            containerRegistry.RegisterForNavigation<Tab1Page, Tab1PageViewModel>();
            containerRegistry.RegisterForNavigation<Tab2Page, Tab2PageViewModel>();
            containerRegistry.RegisterForNavigation<TabbedMasterDetailPage, TabbedMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<TabbedPageRuntimeModal, TabbedPageRuntimeModalViewModel>();
            containerRegistry.RegisterForNavigation<TabbedPageRuntime, TabbedPageRuntimeViewModel>();
            containerRegistry.RegisterForNavigation<TabModalPage, TabModalPageViewModel>();
            containerRegistry.RegisterForNavigation<TabPageExample, TabPageExampleViewModel>();

        }
    }
}
