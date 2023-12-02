using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using PrismFullNavigation.Services.Data;
using PrismFullNavigation.Views;
using PrismFullNavigation.ViewModels;
using Microsoft.Maui.Controls.Compatibility.Hosting;

#if IOS
using PrismFullNavigation.Platforms.iOS.Views;
#endif

namespace PrismFullNavigation;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
        .UseMauiApp<App>()
        .UseMauiCompatibility()
        .ConfigureMauiHandlers(handlers =>
        {
            //Xamarin.Forms Renderers

#if IOS
            handlers.AddCompatibilityRenderer(typeof(Page1ModalPage), typeof(ModalPageCustomRenderer));
            handlers.AddCompatibilityRenderer(typeof(TabbedPageRuntimeModal), typeof(ModalPageCustomRenderer));
            handlers.AddCompatibilityRenderer(typeof(TabModalPage), typeof(ModalPageCustomRenderer));
#endif
        })
        .UsePrism(prism =>

            prism.RegisterTypes(containerRegistry =>
            {

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

            })

            .OnInitialized((IContainerProvider obj) =>
            {

            })

            .OnAppStart(async navigationService =>
            {
                var navResult = await navigationService.NavigateAsync("/" + nameof(NavigationPage) + "/" + nameof(MainPage));

            })
        )
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();

    }
}

