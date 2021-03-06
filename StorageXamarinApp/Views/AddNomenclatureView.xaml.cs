using System;
using Rg.Plugins.Popup.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StorageXamarinApp.ViewModels;

namespace StorageXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNomenclatureView : Rg.Plugins.Popup.Pages.PopupPage
    {
        private AddNomenclatureViewModel _viewModel;
        public AddNomenclatureView()
        {
            InitializeComponent();
            _viewModel = Startup.ServiceProvider.GetService<AddNomenclatureViewModel>();
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            var answer = await _viewModel.PostNewNomenclature(EntryName.Text, EntryUnit.Text);
            if (answer != "Ok")
            {
                await DisplayAlert("Something go wrong!", answer, "Ok");
            }
            await Navigation.PopPopupAsync();
        }
    }
}