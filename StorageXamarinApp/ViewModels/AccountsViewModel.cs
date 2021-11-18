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
            FillAccounts();
        }

        private IAccountService _accountService;
        private List<Account> _accounts;

        public List<Account> Accounts
        {
            get { return _accounts; }
            set 
            { 
                if(_accounts != value)
                {
                    _accounts = value;
                    OnPropertyChanged("Accounts");
                }
            }
        }

        public async void FillAccounts()
        {
            Accounts = await _accountService.GetAccounts();
        }
    }
}
