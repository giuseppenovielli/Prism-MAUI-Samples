﻿using PrismFullNavigation.Services.Data;

namespace PrismFullNavigation.ViewModels
{
    public class Page1ModalPageViewModel : BaseViewModel
    {
        public bool ButtonIsEnable { get; set; }

        string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, UpdateButtonStatus);
        }


        public DelegateCommand SendCommandClick { get; set; }

        public DelegateCommand ClosePage { get; set; }


        public Page1ModalPageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "Page1 Modal Page";


            SendCommandClick = new DelegateCommand(async delegate
            {
                var navParameters = new NavigationParameters
                {
                    { "name", Name }
                };

                var result = await NavigationService.NavigateAsync("Page2Page", navParameters);


            },
           delegate
           {
               return ButtonIsEnable == true;

           }).ObservesProperty(() => ButtonIsEnable);

            ClosePage = new DelegateCommand(async () =>
            {
                var navResult = await GoBackAsync();
            });
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
