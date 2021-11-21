using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        
        public AccountsViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            Accounts = new ObservableCollection<Account>();
        }

        private IAccountService _accountService;
        public ObservableCollection<Account> Accounts { get; private set; }

        public async void FillAccounts()
        {
            var accountsList = await _accountService.GetAccounts();
            Accounts.Clear();
            accountsList.ForEach(account => Accounts.Add(account));
        }
    }
}
