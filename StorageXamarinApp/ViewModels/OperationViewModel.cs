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
        private int _operationsCount;

        public int OperationsCount
        {
            get { return _operationsCount; }
            set 
            {
                if (_operationsCount != value)
                {
                    _operationsCount = value;
                    OnPropertyChanged("OperationsCount");
                }
                
            }
        }

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
            OperationsCount = Operations.Where(x => x.OperationType == operationType).Count();
        }
    }
}
