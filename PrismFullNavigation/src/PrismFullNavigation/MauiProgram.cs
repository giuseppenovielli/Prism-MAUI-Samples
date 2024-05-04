using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using PrismFullNavigation.Services.Data;
using PrismFullNavigation.ViewModels;
using PrismFullNavigation.Views;

namespace PrismFullNavigation;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
        .UseMauiApp<App>()
        .UseMauiCompatibility()
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        })
        .ConfigureMauiHandlers(handlers =>
        {

        })
        .UsePrism(prism =>

            prism.ConfigureServices(services => {
                Debug.WriteLine("MAUI BUILDER - ConfigureServices IServiceCollection");
                // Register services with the IServiceCollection
                //services.AddSingleton<IFoo, Foo>();
            })

            .ConfigureLogging(builder => {
                builder.AddDebug();
            })

            .RegisterTypes(containerRegistry =>
            {
                Debug.WriteLine("MAUI BUILDER - RegisterTypes IContainerRegistry");

                containerRegistry.RegisterSingleton<IDataService, DataService>();

                //containerRegistry.RegisterForNavigation<MasterDetailNavigationPage>();

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
                Debug.WriteLine("MAUI BUILDER - OnInitialized IContainerRegistry");

                var eventAggregator = obj.Resolve<IEventAggregator>();
                eventAggregator?.GetEvent<NavigationRequestEvent>().Subscribe(context => {

                    Debug.WriteLine("\nNAVIGATIONSERVICE");
                    Debug.WriteLine("Uri = " + context.Uri);
                    Debug.WriteLine("Parameters = "+context.Parameters);
                    Debug.WriteLine("Type = " + context.Type);
                    Debug.WriteLine("Cancelled = "+context.Cancelled);
                    Debug.WriteLine("NAVIGATIONSERVICE RESULT");
                    Debug.WriteLine("Success = "+context.Result.Success);
                    Debug.WriteLine("Context = "+context.Result.Context);

                    var exc = context.Result.Exception;
                    if (exc != null)
                    {
                        Debug.WriteLine("NAVIGATIONSERVICE EXCEPTION");
                        Debug.WriteLine("Exception = " + exc);
                        Debug.WriteLine("Data = " + exc.Data);
                        Debug.WriteLine("HelpLink = " + exc.HelpLink);
                        Debug.WriteLine("HResult = " + exc.HResult);
                        Debug.WriteLine("InnerException = " + exc.InnerException);
                        Debug.WriteLine("Message = " + exc.Message);
                        Debug.WriteLine("Source = " + exc.Source);
                        Debug.WriteLine("StackTrace = " + exc.StackTrace);
                        Debug.WriteLine("TargetSite = " + exc.TargetSite);
                    }
                    
                    
                });
            })

            .CreateWindow(async navigationService =>
            {
                Debug.WriteLine("MAUI BUILDER - CreateWindow INavigationService");

                var navResult = await navigationService.NavigateAsync("/" + nameof(NavigationPage) + "/" + nameof(MainPage));
            })
        );
        


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();

    }
}

