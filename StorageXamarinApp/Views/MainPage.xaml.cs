using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.CustomViews;
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
    public partial class MainPage : ContentPage
    {
        private AddNomenclatureView _addNomenclatureView;
        private MainPageModel _model;
        public MainPage()
        {
            InitializeComponent();
            _model = Startup.ServiceProvider.GetService<MainPageModel>();
            BindingContext = _model;
        }

        protected override void OnAppearing()
        {
            _model.UpdateInfo();
        }

        private async void AddNomenclatureButton_Clicked(object sender, EventArgs e)
        {
            _addNomenclatureView = new AddNomenclatureView();
            await Navigation.PushPopupAsync(_addNomenclatureView);
        }

        private void ShippingPage_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            _model.UpdateShippingOperations(); 
        }

        private void ReceivePage_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            _model.UpdateReceiveOperations();
        }

        private async void AddReceiveOperationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AddReceiveOpearionView());
        }
        private async void AddShippingOperationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AddShippingOperationView());
        }
    }
}