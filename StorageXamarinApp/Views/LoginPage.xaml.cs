using Microsoft.Extensions.DependencyInjection;
using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.CustomViews;
using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using StorageXamarinApp.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        private AccountSelectView _accountSelectPage;
        private Account _selectedAccount;
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            _accountSelectPage = new AccountSelectView();
            _accountSelectPage.AccountSelected += _accountSelectPage_AccountSelected;
        }
        protected override void OnDisappearing()
        {
            _accountSelectPage.AccountSelected -= _accountSelectPage_AccountSelected;
        }

        private void _accountSelectPage_AccountSelected(object sender, ItemTappedEventArgs e)
        {
            SelectButton.Text = (e.Item as Account).Name;
            _selectedAccount = e.Item as Account;
            if (StartButton.Scale != 1)
            {
                UIAnimations.AnimateInOutScale(StartButton);
            }

        }

        private void SelectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(_accountSelectPage);
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            UIAnimations.AnimateClickScale(StartButton);
            Startup.ServiceProvider.GetService<IAccountService>().SetUserAccount(_selectedAccount);
            Navigation.PushAsync(new MainPage());
        }
    }
}
