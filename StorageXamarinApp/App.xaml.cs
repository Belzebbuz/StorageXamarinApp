﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageXamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            Startup.Init();
            InitializeComponent();            
            MainPage = new MainPage();
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
