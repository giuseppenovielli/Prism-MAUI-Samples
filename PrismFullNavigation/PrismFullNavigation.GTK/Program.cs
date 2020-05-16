using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace PrismFullNavigation.GTK
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Gtk.Application.Init();
            Forms.Init();

            var app = new App(null);
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("Xamarin Forms Prism Full Navigation Example");
            window.Show();

            Gtk.Application.Run(); ;
        }
    }
}
