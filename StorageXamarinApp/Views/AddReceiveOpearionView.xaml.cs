using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReceiveOpearionView : Rg.Plugins.Popup.Pages.PopupPage
    {
        AddOperationViewModel _viewModel;
        public AddReceiveOpearionView()
        {
            InitializeComponent();
            _viewModel = Startup.ServiceProvider.GetService<AddOperationViewModel>();
        }
        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(EntryNomenclatureId.Text, out int nomenclatureId) &&
                int.TryParse(EntryCount.Text, out int count))
            {
                var answer = await _viewModel.PostNewOperation(nomenclatureId, count, Models.OperationTypes.Receiving);
                if (answer != "Ok")
                {
                    await DisplayAlert("Error!", answer, "Ok");
                }
                await Navigation.PopPopupAsync();
            }
            else
            {
                await DisplayAlert("Error!", "Values must be integers", "Ok");
                await Navigation.PopPopupAsync();
            }
            
        }

        private async void EntryNomenclatureId_TextChanged(object sender, TextChangedEventArgs e)
        {
            NomenclatureName.Text = await _viewModel.GetNomenclatureName(EntryNomenclatureId.Text);
        }
    }
}