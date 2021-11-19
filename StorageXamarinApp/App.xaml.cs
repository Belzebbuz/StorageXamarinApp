using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using StorageXamarinApp.ViewModels;


[assembly: ExportFont("HelveticaNowDisplay-Black.ttf", Alias ="Bold")]
[assembly: ExportFont("HelveticaNowDisplay-ExtLt.ttf", Alias ="Thin")]
namespace StorageXamarinApp
{   
    public partial class App : Application
    {
        public App()
        {
            
            Startup.Init();
            InitializeComponent();
            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental" });
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
