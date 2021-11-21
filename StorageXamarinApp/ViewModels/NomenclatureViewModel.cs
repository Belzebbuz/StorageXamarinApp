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
    public class NomenclatureViewModel:BaseViewModel
    {
        public NomenclatureViewModel(INomenclatureService nomenclatureService)
        {
            _nomenclatureService = nomenclatureService;
            Nomenclatures = new ObservableCollection<Nomenclature>();
        }
        private INomenclatureService _nomenclatureService;
        public ObservableCollection<Nomenclature> Nomenclatures { get; private set; }
        private int _nomenclatureCount;

        public int NomenclatureCount
        {
            get { return _nomenclatureCount; }
            set 
            {
                if (_nomenclatureCount != value)
                {
                    _nomenclatureCount = value;
                    OnPropertyChanged("NomenclatureCount");
                }
                
            }
        }

        public async void FillNomenclatures()
        {
            var nomenclatureList = await _nomenclatureService.GetNomenclatures();
            Nomenclatures.Clear();
            nomenclatureList.ForEach(nom => Nomenclatures.Add(nom));
            NomenclatureCount = Nomenclatures.Count;
        }
    }
}
