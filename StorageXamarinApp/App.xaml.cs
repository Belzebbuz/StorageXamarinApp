using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using StorageXamarinApp.ViewModels;



namespace StorageXamarinApp
{   
    public partial class App : Application
    {
        public App()
        {
            
            Startup.Init();
            InitializeComponent();

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
