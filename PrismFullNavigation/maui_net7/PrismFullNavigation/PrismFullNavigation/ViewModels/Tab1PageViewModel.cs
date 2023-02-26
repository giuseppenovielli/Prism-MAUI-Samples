using System;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using PrismFullNavigation.Services.Data;
using PrismFullNavigation.Views;

namespace PrismFullNavigation.ViewModels
{
    public class Tab1PageViewModel : BaseViewModel, IActiveAware
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


        public Tab1PageViewModel(
            INavigationService navigationService,
            IDataService dataService) : base(navigationService, dataService)
        {
            TitlePage = "Tab1";


            SendCommandClick = new DelegateCommand(async delegate
            {
                var navParameters = new NavigationParameters();
                navParameters.Add("name", Name);
                //navParameters.Add(KnownNavigationParameters.SelectedTab, nameof(Tab2Page));

                //var result = await NavigationService.NavigateAsync(nameof(Tab2Page), navParameters);

                var result = await NavigationService.CreateBuilder()
                    .AddTabbedSegment(b => b.SelectedTab(nameof(Tab2Page)))
                    .WithParameters(navParameters)
                    .NavigateAsync();

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

        protected virtual void RaiseIsActiveChanged()
        {
            if (IsActive)
            {
                TitlePage = $"Tab1(Selected)";

            }
            else
            {
                TitlePage = "Tab1";

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
