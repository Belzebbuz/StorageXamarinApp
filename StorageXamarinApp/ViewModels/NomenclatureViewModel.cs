using StorageXamarinApp.Models;
using StorageXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.ViewModels
{
    public class NomenclatureViewModel:BaseViewModel
    {
        public NomenclatureViewModel(INomenclatureService nomenclatureService)
        {
            _nomenclatureService = nomenclatureService;
        }
        private INomenclatureService _nomenclatureService;
        private List<Nomenclature> _nomenclatures;
        public List<Nomenclature> Nomenclatures
        {
            get
            {
                return _nomenclatures;
            }
            set
            {
                if (_nomenclatures != value)
                {
                    _nomenclatures = value;
                    OnPropertyChanged("Nomenclatures");
                }
            }
        }
        public async void FillNomenclatures()
        {
            Nomenclatures = await _nomenclatureService.GetNomenclatures();
        }
    }
}
