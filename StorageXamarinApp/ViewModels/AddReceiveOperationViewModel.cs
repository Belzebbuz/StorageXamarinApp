using Microsoft.Extensions.DependencyInjection;
using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.ViewModels
{
    public class AddReceiveOperationViewModel
    {
        public AddReceiveOperationViewModel(IReceiveService receiveService, INomenclatureService nomenclatureService)
        {
            _receiveService = receiveService;
            _nomenclatureService = nomenclatureService;
        }
        private IReceiveService _receiveService;
        private INomenclatureService _nomenclatureService;
        public async Task<string> PostNewOperation(int nomenclatureId, int count)
        {
            if (nomenclatureId > 0 && count > 0)
            {
                Operation operation = await ConfigureOperation(nomenclatureId, count); 
                if (operation != null)
                {
                    var result = await _receiveService.PostOperation(operation);
                    if (result == "Ok")
                    {
                        Startup.ServiceProvider.GetService<MainPageModel>().UpdateReceiveOperations();
                        return "Ok";
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    return $"Nomenclature with id {nomenclatureId} not found!";
                }
 
            }
            else
            {
                return "All fields must be greater than zero!";
            }

        }

        private async Task<Operation> ConfigureOperation(int nomenclatureId, int count)
        {
            Nomenclature nomenclature = await _nomenclatureService.GetNomenclature(nomenclatureId);
            if (nomenclature == null)
            {
                return null;
            }
            Account account = Startup.ServiceProvider.GetService<IAccountService>().GetUserAccount();
            return new Operation 
            { 
                Account = account, 
                Count = count, 
                DateTime = DateTime.Now, 
                OperationType = OperationTypes.Receiving,
                Nomenclature = nomenclature
            };
        }
    }
}
