using Microsoft.Extensions.DependencyInjection;
using Refit;
using StorageXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.Services
{
    public interface IShippingService
    {
        Task<List<Operation>> GetShippingOperations();
        Task<string> PostOperation(Operation operation);
    }
    public class ShippingService: IShippingService
    {
        public ShippingService(IStorageServer storageServer)
        {
            _storageServer = storageServer;
        }
        private readonly IStorageServer _storageServer;
        private List<Operation> _shippingOperations;

        public async Task<List<Operation>> GetShippingOperations()
        {
            try
            {
                var userAccount = Startup.ServiceProvider.GetService<IAccountService>().GetUserAccount();
                _shippingOperations = await _storageServer.GetShippingOperations(userAccount.Id);
            }
            catch (ApiException ex)
            {
                ex.ToString();
            }

            return _shippingOperations;
        }

        public async Task<string> PostOperation(Operation operation)
        {
            try
            {
                await _storageServer.PostOperation(operation);
                return "Ok";
            }
            catch (ApiException ex)
            {
                return ex.ToString();
            }
        }
    }
}
