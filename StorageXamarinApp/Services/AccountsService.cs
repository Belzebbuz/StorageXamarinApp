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
        Task<List<AccountModel>> GetAccounts();
    }
    public class AccountsService : IAccountService
    {
        public AccountsService(IStorageServer storageServer)
        {
            _storageServer = storageServer;
        }
        private IStorageServer _storageServer;
        private List<AccountModel> _accounts;
        public async Task<List<AccountModel>> GetAccounts()
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

    }
}
