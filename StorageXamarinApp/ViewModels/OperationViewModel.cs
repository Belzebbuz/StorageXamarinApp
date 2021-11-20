using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.ViewModels
{
    public class OperationViewModel:BaseViewModel
    {
        public OperationViewModel(IOperationService operationService)
        {
            _operationService = operationService;
        }
        private IOperationService _operationService;
        private List<Operation> _operations;
        public List<Operation> Operations
        {
            get
            {
                return _operations;
            }
            set
            {
                if (_operations != value)
                {
                    _operations = value;
                    OnPropertyChanged("Operations");
                }
            }
        }
        public async void FillOperations(OperationTypes operationType)
        {
            Operations = await _operationService.GetOperations(operationType);
        }
    }
}
