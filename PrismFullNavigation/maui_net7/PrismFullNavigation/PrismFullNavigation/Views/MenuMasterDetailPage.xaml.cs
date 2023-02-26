using Prism.Navigation;


namespace PrismFullNavigation.Views
{
    public partial class MenuMasterDetailPage : FlyoutPage, IFlyoutPageOptions
    {
        public static readonly BindableProperty IsPresentedAfterNavigationProperty =
            BindableProperty.Create(
                nameof(IsPresentedAfterNavigation),
                typeof(bool),
                typeof(MenuMasterDetailPage),
                false);



        public MenuMasterDetailPage()
        {
            InitializeComponent();
        }

        public bool IsPresentedAfterNavigation
        {
            get => (bool)GetValue(IsPresentedAfterNavigationProperty);
            set => SetValue(IsPresentedAfterNavigationProperty, value);
        }
    }
}
