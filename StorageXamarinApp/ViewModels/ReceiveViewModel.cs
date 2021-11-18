using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.ViewModels
{
    public class ReceiveViewModel:BaseViewModel
    {
        public ReceiveViewModel(IReceiveService receiveService)
        {
            _receiveService = receiveService;
            FillReceiveOperations();
        }
        private IReceiveService _receiveService;
        private List<Operation> _receiveOperations;
        public List<Operation> ReceiveOperations
        {
            get
            {
                return _receiveOperations;
            }
            set
            {
                if (_receiveOperations != value)
                {
                    _receiveOperations = value;
                    OnPropertyChanged("ReceiveOperations");
                }
            }
        }
        public async void FillReceiveOperations()
        {
            ReceiveOperations = await _receiveService.GetReceiveOperations();
        }
    }
}
