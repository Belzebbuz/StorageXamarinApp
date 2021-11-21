using Rg.Plugins.Popup.Extensions;
using StorageXamarinApp.CustomViews;
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
            ReceiveListView.Refreshing += ReceiveListView_Refreshing;
            NomenclatureListView.Refreshing += NomenclatureListView_Refreshing;
            ShippingListView.Refreshing += ShippingListView_Refreshing;
        }

        private void ShippingListView_Refreshing(object sender, EventArgs e)
        {
            ShippingListView.IsRefreshing = true;
            _model.UpdateShippingOperations();
            ShippingListView.IsRefreshing = false;
        }

        private void NomenclatureListView_Refreshing(object sender, EventArgs e)
        {
            NomenclatureListView.IsRefreshing = true;
            _model.UpdateNomenclatures();
            NomenclatureListView.IsRefreshing= false;
        }

        private void ReceiveListView_Refreshing(object sender, EventArgs e)
        {
            ReceiveListView.IsRefreshing = true;
            _model.UpdateReceiveOperations();
            ReceiveListView.IsRefreshing = false;
        }

        private async void AddNomenclatureButton_Clicked(object sender, EventArgs e)
        {
            _addNomenclatureView = new AddNomenclatureView();
            await Navigation.PushPopupAsync(_addNomenclatureView);
        }
        private async void AddReceiveOperationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AddReceiveOpearionView());
        }
        private async void AddShippingOperationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new AddShippingOperationView());
        }

        private async void ListOperation_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushPopupAsync(new OperationInfoView(e.Item as Operation));
        }
    }
}