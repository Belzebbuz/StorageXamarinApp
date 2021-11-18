using Refit;
using StorageXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();
        Account GetUserAccount();
        void SetUserAccount(Account account);
    }
    public class AccountsService : IAccountService
    {
        public AccountsService(IStorageServer storageServer)
        {
            _storageServer = storageServer;
        }
        private readonly IStorageServer _storageServer;
        private List<Account> _accounts;
        private Account _userAccount;
        public async Task<List<Account>> GetAccounts()
        {
            try
            {
                _accounts = await _storageServer.GetAccounts();
            }
            catch (ApiException ex)
            {
                ex.ToString();
            }

            return _accounts;
        }
        public Account GetUserAccount() => _userAccount;
        public void SetUserAccount(Account account)
        {
            if (account != null)
                _userAccount = account;
        }

    }
}
