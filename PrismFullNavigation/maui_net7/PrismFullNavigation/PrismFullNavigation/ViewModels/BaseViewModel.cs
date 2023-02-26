using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class BaseViewModel : BindableBase, IDestructible, IApplicationLifecycleAware, IPageLifecycleAware, INavigationAware, IInitialize, INavigationPageOptions
    {
        public string TitlePage { get; set; }

        public INavigationService NavigationService { get; }
        public IDataService DataService { get; }

        public bool ClearNavigationStackOnNavigation => DataService.ClearDetailPageStack;

        public BaseViewModel(
            INavigationService navigationService,
            IDataService dataService)
        {
            NavigationService = navigationService;
            DataService = dataService;
        }

        public virtual void OnResume()
        {

        }

        public virtual void OnSleep()
        {

        }

        public virtual void OnAppearing()
        {

        }

        public virtual void OnDisappearing()
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public void Destroy()
        {
        }

        public async Task PopModalAsync()
        {
            var navResult = await NavigationService.GoBackAsync();
        }
    }
}
