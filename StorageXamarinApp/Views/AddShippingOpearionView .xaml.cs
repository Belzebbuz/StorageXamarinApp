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
    public partial class AddShippingOperationView : Rg.Plugins.Popup.Pages.PopupPage
    {
        AddShippingOperationViewModel _viewModel;
        public AddShippingOperationView()
        {
            InitializeComponent();
            _viewModel = Startup.ServiceProvider.GetService<AddShippingOperationViewModel>();
        }
        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                int nomenclatureId = int.Parse(EntryNomenclatureId.Text);
                int count = int.Parse(EntryCount.Text);
                var answer = await _viewModel.PostNewOperation(nomenclatureId, count);
                if (answer != "Ok")
                {
                    await DisplayAlert("Error!", answer, "Ok");
                }
                await Navigation.PopPopupAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", ex.Message, "Ok");
                await Navigation.PopPopupAsync();
            }
            
        }
    }
}