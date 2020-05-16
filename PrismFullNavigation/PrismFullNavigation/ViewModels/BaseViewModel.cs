using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class BaseViewModel : BindableBase, IDestructible, IApplicationLifecycleAware, IPageLifecycleAware, INavigationAware, IInitialize, INavigationPageOptions
    {
        public string TitlePage { get; set; }

        public INavigationService NavigationService { get; }

        //MasterDetailPage
        //When choose Master page
        //true => Don't push page to detail stack navigation, but clear navigation stack detail page
        //false => push page to detail stack navigation
        public virtual bool ClearNavigationStackOnNavigation => App.Instance.ClearDetailNavStack;

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
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
    }
}
