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
            ShippingViewModel = Startup.ServiceProvider.GetService<ShippingViewModel>();
            NomenclatureViewModel = Startup.ServiceProvider.GetService<NomenclatureViewModel>();
            ReceiveViewModel = Startup.ServiceProvider.GetService<ReceiveViewModel>();
        }
        public ShippingViewModel ShippingViewModel { get; set; }
        public NomenclatureViewModel NomenclatureViewModel { get; set; }
        public ReceiveViewModel ReceiveViewModel { get; set; }
        
        
        public void UpdateShippingOperations()
        {
            ShippingViewModel.FillShippingOperations();
        }
        public void UpdateNomenclatures()
        {
            NomenclatureViewModel.FillNomenclatures();           
        }
        public void UpdateReceiveOperations()
        {
            ReceiveViewModel.FillReceiveOperations();           
        }

        public void UpdateInfo()
        {
            ShippingViewModel.FillShippingOperations();
            NomenclatureViewModel.FillNomenclatures();
            ReceiveViewModel.FillReceiveOperations();
        }
    }
}
