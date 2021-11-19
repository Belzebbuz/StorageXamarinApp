using Refit;
using StorageXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.Services
{
    public interface INomenclatureService
    {
        Task<List<Nomenclature>> GetNomenclatures();
        Task<string> PostNomenclature(Nomenclature nomenclature);
        Task<Nomenclature> GetNomenclature(int nomenclatureId);
    }
    public class NomenclatureService : INomenclatureService
    {        
        public NomenclatureService(IStorageServer storageServer)
        {
            _storageServer = storageServer;
        }
        private readonly IStorageServer _storageServer;
        private List<Nomenclature> _nomenclatures;
        public async Task<List<Nomenclature>> GetNomenclatures()
        {
            try
            {
                _nomenclatures = await _storageServer.GetNomenclatures();
            }
            catch (ApiException ex)
            {
                ex.ToString();
            }

            return _nomenclatures;
        }

        public async Task<string> PostNomenclature(Nomenclature nomenclature)
        {
            try
            {
                await _storageServer.PostNomenclature(nomenclature);
                return "Ok";
            }
            catch (ApiException ex)
            {
                return ex.ToString();
            }
             
        }

        public async Task<Nomenclature> GetNomenclature(int nomenclatureId)
        {
            try
            {
                return await _storageServer.GetNomenclature(nomenclatureId);
            }
            catch (ApiException ex)
            {
                return null;
            }
        }
    }
}
