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
    public class AddNomenclatureViewModel
    {
        public AddNomenclatureViewModel(INomenclatureService nomenclatureService)
        {
            _nomenclatureService = nomenclatureService;
        }
        private INomenclatureService _nomenclatureService;
        public async Task<string> PostNewNomenclature(string name, string unit)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(unit))
            {
                var result = await _nomenclatureService.PostNomenclature(new Nomenclature { Name = name, Unit = unit });
                if (result == "Ok")
                {
                    Startup.ServiceProvider.GetService<MainPageModel>().UpdateNomenclatures();
                    return "Ok";
                }
                else
                {
                    return result;
                }                    
            }
            else
            {
                return "All fields must be filled";
            }
            
        }
    }
}
