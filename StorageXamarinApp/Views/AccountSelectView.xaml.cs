using Microsoft.Extensions.DependencyInjection;
using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.Models;
using StorageXamarinApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StorageXamarinApp.Views
{
    public partial class AccountSelectView : Rg.Plugins.Popup.Pages.PopupPage
    {
        public event EventHandler<ItemTappedEventArgs> AccountSelected;
        public AccountSelectView()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<AccountsViewModel>();                        
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        { 
            Navigation.PopPopupAsync();            
        }

        private void AccountItem_Clicked(object sender, ItemTappedEventArgs e)
        {           
            AccountSelected?.Invoke(sender, e);
            (sender as ListView).SelectedItem = null;
            Navigation.PopPopupAsync();
        }
    }
}