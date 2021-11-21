using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Operations = new ObservableCollection<Operation>();
        }
        private IOperationService _operationService;
        private int _operationsCount;
        public ObservableCollection<Operation> Operations { get; private set; }
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
        public async void FillOperations(OperationTypes operationType)
        {
            var operationsList = await _operationService.GetOperations(operationType);
            Operations.Clear();
            operationsList.ForEach(x => Operations.Add(x));
            OperationsCount = Operations.Where(x => x.OperationType == operationType).Count();
        }
    }
}
