using Prism.Commands;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;
using PrismFullNavigation.Views;

namespace PrismFullNavigation.ViewModels
{
    public class Page1ClearStackNavPageViewModel : BaseViewModel
    {
        public bool ButtonIsEnable { get; set; }

        string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, UpdateButtonStatus);
        }


        public DelegateCommand SendCommandClick { get; set; }


        public Page1ClearStackNavPageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "Page1 - Push Detail Page";

            SendCommandClick = new DelegateCommand(async delegate
            {
                var navParameters = new NavigationParameters();
                navParameters.Add("name", Name);

                var result = await NavigationService.NavigateAsync(nameof(Page2Page), navParameters);


            },
           delegate
           {
               return ButtonIsEnable == true ? true : false;

           }).ObservesProperty(() => ButtonIsEnable);
        }

 

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

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
