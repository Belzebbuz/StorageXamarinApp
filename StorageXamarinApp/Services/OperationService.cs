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
    public interface IOperationService
    {
        Task<List<Operation>> GetOperations(OperationTypes operationType);

        Task<string> PostOperation(Operation operation);
        Task<string> DeleteOperation(int id);
    }
    public class OperationService : IOperationService
    {
        public OperationService(IStorageServer storageServer)
        {
            _storageServer = storageServer;
        }
        private readonly IStorageServer _storageServer;
        private List<Operation> _receiveOperations;

        public async Task<List<Operation>> GetOperations(OperationTypes operationType)
        {
            try
            {
                var userAccount = Startup.ServiceProvider.GetService<IAccountService>().GetUserAccount();
                switch (operationType)
                {
                    case OperationTypes.Receiving:
                        _receiveOperations = await _storageServer.GetReceiveOperations(userAccount.Id);
                        break;
                    case OperationTypes.Shipping:
                        _receiveOperations = await _storageServer.GetShippingOperations(userAccount.Id);
                        break;
                    default:
                        break;
                }                
            }
            catch (ApiException ex)
            {
                ex.ToString();
            }

            return _receiveOperations;
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

        public async Task<string> DeleteOperation(int id)
        {
            try
            {
                await _storageServer.DeleteOperation(id);
                return "Ok";
            }
            catch (ApiException ex)
            {

                return ex.Message;
            }
        }
    }
}
