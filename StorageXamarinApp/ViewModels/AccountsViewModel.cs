using StorageXamarinApp.Models;
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
        public AccountsViewModel()
        {
            Accounts = new ObservableCollection<Account>()
            {
                new Account("General"),
                new Account("Manager"),
                new Account("Director"),
                new Account("Main"),
                new Account("Super storager"),
                new Account("Genius")
            };
        }

        public ObservableCollection<Account> Accounts { get; private set; }
        public Account SelectedAccount { get; private set; }
    }
}
