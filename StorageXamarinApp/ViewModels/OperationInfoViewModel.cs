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
    public class OperationInfoViewModel
    {
        public OperationInfoViewModel(IOperationService operationService)
        {
            _operationService = operationService;
        }

        private IOperationService _operationService;
        public Operation Operation { get; set; }
        public async Task<string> DeleteOperationAsync()
        {
            var result = await _operationService.DeleteOperation(Operation.Id);
            if (result == "Ok")
            {
                UpdateMainPageInfo(Operation.OperationType);
            }
            return result;
        }
        private static void UpdateMainPageInfo(OperationTypes operationType)
        {
            switch (operationType)
            {
                case OperationTypes.Receiving:
                    Startup.ServiceProvider.GetService<MainPageModel>().UpdateReceiveOperations();
                    break;
                case OperationTypes.Shipping:
                    Startup.ServiceProvider.GetService<MainPageModel>().UpdateShippingOperations();
                    break;
            }

        }
    }
}
