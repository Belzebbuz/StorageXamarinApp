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
    public class MainPageModel: BaseViewModel
    {
        public MainPageModel()
        {            
            ShippingViewModel = Startup.ServiceProvider.GetService<OperationViewModel>();
            NomenclatureViewModel = Startup.ServiceProvider.GetService<NomenclatureViewModel>();
            ReceiveViewModel = Startup.ServiceProvider.GetService<OperationViewModel>();
            
        }
        public OperationViewModel ShippingViewModel { get; set; }
        public NomenclatureViewModel NomenclatureViewModel { get; set; }
        public OperationViewModel ReceiveViewModel { get; set; }
        private Account _user;
        public Account User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }        

        public void UpdateShippingOperations()
        {
            ShippingViewModel.FillOperations(OperationTypes.Shipping);
        }
        public void UpdateNomenclatures()
        {
            NomenclatureViewModel.FillNomenclatures();           
        }
        public void UpdateReceiveOperations()
        {
            ReceiveViewModel.FillOperations(OperationTypes.Receiving);           
        }

        public void UpdateInfo()
        {
            UpdateShippingOperations();
            UpdateNomenclatures();
            UpdateReceiveOperations();
            User = Startup.ServiceProvider.GetService<IAccountService>().GetUserAccount();
        }
    }
}
