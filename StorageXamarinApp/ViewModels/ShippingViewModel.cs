using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.ViewModels
{
    public class ShippingViewModel: BaseViewModel
    {
        public ShippingViewModel(IShippingService shippingService)
        {
            _shippingService = shippingService;
            FillShippingOperations();
        }
        private IShippingService _shippingService;
        private List<Operation> _shippingOperations;
        public List<Operation> ShippingOperations
        {
            get
            {
                return _shippingOperations;
            }
            set
            {
                if (_shippingOperations != value)
                {
                    _shippingOperations = value;
                    OnPropertyChanged("ShippingOperations");
                }
            }
        }
        public async void FillShippingOperations()
        {
            ShippingOperations = await _shippingService.GetShippingOperations();
        }
    }
}
