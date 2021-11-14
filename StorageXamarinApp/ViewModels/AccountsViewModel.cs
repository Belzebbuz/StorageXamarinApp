using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.ViewModels
{
    public class AccountsViewModel
    {
        public AccountsViewModel(IAccountService accountService)
        {
            Accounts = accountService.GetAccountsList();
        }

        public List<Account> Accounts { get; private set; }
    }
}
