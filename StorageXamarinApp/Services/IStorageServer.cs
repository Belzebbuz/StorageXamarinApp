using Refit;
using StorageXamarinApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace StorageXamarinApp.Services
{
    public interface IStorageServer
    {
        [Get("/accounts")]
        Task<List<AccountModel>> GetAccounts();
    }
}
