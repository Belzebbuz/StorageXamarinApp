using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.Models;
using StorageXamarinApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StorageXamarinApp
{
    public partial class MainPage : ContentPage
    {
        private AccountSelectPage _accountSelectPage;
        public MainPage()
        {
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            _accountSelectPage = new AccountSelectPage();
            _accountSelectPage.AccountSelected += (sender, e) => SelectButton.Text = e.Name;
        }
        private void SelectButton_Clicked(object sender, EventArgs e)
        {            
            Navigation.PushPopupAsync(_accountSelectPage);
        }
    }
}
