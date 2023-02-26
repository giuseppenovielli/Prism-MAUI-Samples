using Prism.Commands;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;
using PrismFullNavigation.Views;

namespace PrismFullNavigation.ViewModels
{
    public class Page1PageViewModel : BaseViewModel
    {
        public bool ButtonIsEnable { get; set; }

        string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, UpdateButtonStatus);
        }


        public DelegateCommand SendCommandClick { get; set; }


        public Page1PageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "Page1";


            SendCommandClick = new DelegateCommand(async delegate
            {
                //Set parameters to Send
                var navParameters = new NavigationParameters();
                navParameters.Add("name", Name);

                //Navigate to Page2Page
                var result = await NavigationService.NavigateAsync(nameof(Page2Page), navParameters);


            },
           delegate
           {
               return ButtonIsEnable == true ? true : false;

           }).ObservesProperty(() => ButtonIsEnable);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            if (parameters.GetNavigationMode() == Prism.Navigation.NavigationMode.Back)
            {
                System.Diagnostics.Debug.WriteLine("NavigationMode.Back");
            }
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //Return data parameters from Page2Page
            if (parameters.ContainsKey("name"))
            {
                Name = parameters["name"] as string;
            }
        }

   

        private void UpdateButtonStatus()
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                ButtonIsEnable = true;
            }
            else
            {
                ButtonIsEnable = false;

            }
        }
    }
}
