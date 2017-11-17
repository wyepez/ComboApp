using ComboApp.Models;
using ComboApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Utils;
using Windows.UI.Xaml.Navigation;

namespace ComboApp.ViewModels
{
    public class OrderEditionPageViewModel
        : ViewModelBase
    {
        private IBusinessAssociateService businessAssociateService;

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { Set(ref selectedOrder, value); }
        }

        public ObservableCollection<BusinessAssociate> BusinessAssociates { get; set; } = new ObservableCollection<BusinessAssociate>();

        public OrderEditionPageViewModel(IBusinessAssociateService businessAssociateService)
        {
            this.businessAssociateService = businessAssociateService;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            // Loading buiness associates
            var response = await businessAssociateService.GetNextPageAsync();
            if (response.IsSuccessful)
            {
                BusinessAssociates.AddRange(response.Result.Items);
            }

            SelectedOrder = (Order)parameter;
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        private DelegateCommand showSelectedOrder;
        public DelegateCommand ShowSelectedOrder => showSelectedOrder ?? (showSelectedOrder = new DelegateCommand(async () =>
        {
            await Views.MessageBox.ShowAsync(JsonConvert.SerializeObject(SelectedOrder, Formatting.Indented));
        }));

    }
}
