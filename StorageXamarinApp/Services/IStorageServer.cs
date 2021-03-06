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
        Task<List<Account>> GetAccounts();

        [Get("/nomenclatures")]
        Task<List<Nomenclature>> GetNomenclatures();

        [Post("/nomenclatures")]
        Task<Nomenclature> PostNomenclature([Body]Nomenclature nomenclature);

        [Get("/operations/{accountId}/1")]
        Task<List<Operation>> GetShippingOperations(int accountId);

        [Get("/operations/{accountId}/0")]
        Task<List<Operation>> GetReceiveOperations(int accountId);

        [Post("/operations")]
        Task PostOperation([Body]Operation operation);

        [Get("/nomenclatures/{Id}")]
        Task<Nomenclature> GetNomenclature(int Id);

        [Delete("/operations/{Id}")]
        Task DeleteOperation(int Id);
    }
}
