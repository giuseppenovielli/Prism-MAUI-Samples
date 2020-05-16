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
    [AutoRegisterForNavigation]
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
            //var navResult = await NavigationService.NavigateAsync("/MenuMasterDetailPage/NavigationPage/TabPageExample");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
        }
    }
}
