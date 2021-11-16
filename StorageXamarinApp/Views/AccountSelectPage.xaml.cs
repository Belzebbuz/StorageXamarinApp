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
    public partial class AccountSelectPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public event EventHandler<AccountSelectedEventArgs> AccountSelected;
        public AccountSelectPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<AccountsViewModel>();                        
        }

        private void Button_Clicked(object sender, EventArgs e)
        { 
            Navigation.PopPopupAsync();            
        }

        private void AccountItem_Clicked(object sender, AccountSelectedEventArgs e)
        {           
            e.Name = (e.Item as AccountModel).Name;
            AccountSelected?.Invoke(sender, e);
            (sender as ListView).SelectedItem = null;
            Navigation.PopPopupAsync();
        }
    }

    public class AccountSelectedEventArgs : ItemTappedEventArgs
    {
        public AccountSelectedEventArgs(object group, object item, int itemIndex) : base(group, item, itemIndex)
        {
        }

        public string Name { get; set; }
    }
}