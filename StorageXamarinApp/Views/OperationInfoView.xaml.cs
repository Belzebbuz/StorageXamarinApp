using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.Models;
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
    public partial class OperationInfoView : Rg.Plugins.Popup.Pages.PopupPage
    {
        private OperationInfoViewModel _viewModel;
        public OperationInfoView(Operation operation)
        {
            InitializeComponent();
            _viewModel = Startup.ServiceProvider.GetService<OperationInfoViewModel>();
            _viewModel.Operation = operation;
            BindingContext = _viewModel;
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var answer = await _viewModel.DeleteOperationAsync();
            if (answer == "Ok")
            {
                await Navigation.PopPopupAsync();
            }
            else
            {
                await DisplayAlert("Error!", answer, "Ok");
                await Navigation.PopPopupAsync();
            }
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}