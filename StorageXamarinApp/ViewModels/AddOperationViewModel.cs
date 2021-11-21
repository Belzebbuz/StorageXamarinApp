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
    public class AddOperationViewModel
    {
        public AddOperationViewModel(IOperationService operationService, INomenclatureService nomenclatureService)
        {
            _operationService = operationService;
            _nomenclatureService = nomenclatureService;
        }
        private IOperationService _operationService;
        private INomenclatureService _nomenclatureService;
        public async Task<string> PostNewOperation(int nomenclatureId, int count, OperationTypes operationType)
        {
            if (nomenclatureId > 0 && count > 0)
            {
                Operation operation = await ConfigureOperation(nomenclatureId, count, operationType); 
                if (operation != null)
                {
                    var result = await _operationService.PostOperation(operation);
                    if (result == "Ok")
                    {
                        UpdateMainPageInfo(operationType);
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

        private static void UpdateMainPageInfo(OperationTypes operationType)
        {
            switch(operationType)
            {
                case OperationTypes.Receiving:
                    Startup.ServiceProvider.GetService<MainPageModel>().UpdateReceiveOperations();
                    break;
                case OperationTypes.Shipping:
                    Startup.ServiceProvider.GetService<MainPageModel>().UpdateShippingOperations();
                    break;
            }
        }

        public async Task<string> GetNomenclatureName(string id)
        {
            if(int.TryParse(id, out int nomenclatureId))
            {
                var nomenclature = await _nomenclatureService.GetNomenclature(nomenclatureId);
                if (nomenclature != null)
                {
                    return nomenclature.Name;
                }
                return "Not found";
            }
            else
            {
                return string.Empty;
            }
                
        }

        private async Task<Operation> ConfigureOperation(int nomenclatureId, int count, OperationTypes operationType)
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
                OperationType = operationType,
                Nomenclature = nomenclature
            };
        }
    }
}
