using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.CustomViews;
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
            _accountSelectPage.AccountSelected += _accountSelectPage_AccountSelected;
        }
        protected override void OnDisappearing()
        {
            _accountSelectPage.AccountSelected -= _accountSelectPage_AccountSelected;
        }

        private void _accountSelectPage_AccountSelected(object sender, AccountSelectedEventArgs e)
        {
            SelectButton.Text = e.Name;
            if (StartButton.Scale != 1)
            {
                UIAnimations.AnimateInOutScaleRotation(StartButton);
            }

        }

        private void SelectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(_accountSelectPage);
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            UIAnimations.AnimateClickScale(StartButton);
        }
    }
}
