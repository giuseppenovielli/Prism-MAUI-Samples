﻿using PrismFullNavigation.Services.Data;
using PrismFullNavigation.Views;

namespace PrismFullNavigation.ViewModels
{
    public class Tab2PageViewModel : BaseViewModel, IActiveAware
    {
        public bool ButtonIsEnable { get; set; }

        string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, UpdateButtonStatus);
        }

        public event EventHandler IsActiveChanged;
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set {
                SetProperty(ref _isActive, value, RaiseIsActiveChanged); 
            }
        }


        public DelegateCommand SendCommandClick { get; set; }
        public DelegateCommand SendPage2CommandClick { get; set; }
        public DelegateCommand ClosePage { get; set; }


        public Tab2PageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "Tab2";


            SendCommandClick = new DelegateCommand(async delegate
            {
                var navParameters = new NavigationParameters
                {
                    { "name", Name }
                };

                var result = await NavigationService.CreateBuilder()
                    .AddTabbedSegment(nameof(TabPageExample), b => b.SelectedTab(nameof(Tab1Page)))
                    .WithParameters(navParameters)
                    .NavigateAsync();

            },
           delegate
           {
               return ButtonIsEnable == true ? true : false;

           }).ObservesProperty(() => ButtonIsEnable);




            SendPage2CommandClick = new DelegateCommand(async delegate
            {
                var navParameters = new NavigationParameters
                {
                    { "name", Name },
                    { "isTabbed", true }
                };

                var result = await NavigationService.NavigateAsync(nameof(Page2Page), navParameters);


            },
          delegate
          {
              return ButtonIsEnable == true ? true : false;

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

        protected virtual void RaiseIsActiveChanged()
        {
            if (IsActive)
            {
                TitlePage = $"Tab2(Selected)";

            }
            else
            {
                TitlePage = "Tab2";

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
