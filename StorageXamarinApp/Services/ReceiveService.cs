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
    public interface IReceiveService
    {
        Task<List<Operation>> GetReceiveOperations();

        Task<string> PostOperation(Operation operation);
    }
    public class ReceiveService : IReceiveService
    {
        public ReceiveService(IStorageServer storageServer)
        {
            _storageServer = storageServer;
        }
        private readonly IStorageServer _storageServer;
        private List<Operation> _receiveOperations;

        public async Task<List<Operation>> GetReceiveOperations()
        {
            try
            {
                var userAccount = Startup.ServiceProvider.GetService<IAccountService>().GetUserAccount();
                _receiveOperations = await _storageServer.GetReceiveOperations(userAccount.Id);
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
    }
}
