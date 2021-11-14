using StorageXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.Services
{
    public interface IAccountService
    {
        List<Account> GetAccountsList();
    }
    public class AccountsFillService : IAccountService
    {
        public AccountsFillService()
        {
            _accounts = new List<Account>()
            {
                new Account("General"),
                new Account("Manager"),
                new Account("Director"),
                new Account("Main"),
                new Account("Super storager"),
                new Account("Genius")
            };
        }
        private List<Account> _accounts;

        public List<Account> GetAccountsList()
        {
            return _accounts;
        }
    }
}
