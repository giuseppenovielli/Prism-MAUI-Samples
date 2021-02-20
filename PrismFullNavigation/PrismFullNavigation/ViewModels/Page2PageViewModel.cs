using Prism.Commands;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class Page2PageViewModel : BaseViewModel
    {
        public bool ButtonIsEnable { get; set; }

        public string ReturnText { get; set; }

        string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, UpdateButtonStatus);
        }


        public DelegateCommand SendCommandClick { get; set; }


        public Page2PageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "Page2";


            SendCommandClick = new DelegateCommand(async delegate
            {
                //Set parameters to Send
                var navParameters = new NavigationParameters();
                navParameters.Add("name", Name);

                //Navigate back to Page1Page
                var result = await NavigationService.GoBackAsync(navParameters);


            },
           delegate
           {
               return ButtonIsEnable == true ? true : false;

           }).ObservesProperty(() => ButtonIsEnable);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            //Get Parameters from Page1Page
            if (parameters.ContainsKey("name"))
            {
                Name = parameters["name"] as string;
            }

            var isTabbed = false;
            parameters.TryGetValue("isTabbed", out isTabbed);


            if (!isTabbed)
            {
                ReturnText = "Return name to Page1";
            }
            else
            {
                ReturnText = "Return name to TabbedPage";

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
