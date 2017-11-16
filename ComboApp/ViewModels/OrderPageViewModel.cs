using ComboApp.Models;
using ComboApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Utils;
using Windows.UI.Xaml.Navigation;

namespace ComboApp.ViewModels
{
    public class OrderPageViewModel
        : ViewModelBase
    {
        private IOrderService orderService;

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { Set(ref selectedOrder, value); EditCommand.RaiseCanExecuteChanged(); }
        }

        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

        public OrderPageViewModel(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var response = await orderService.GetAsync();
            if (response.IsSuccessful)
            {
                Orders.AddRange(response.Result);
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        private DelegateCommand editCommand;
        public DelegateCommand EditCommand => editCommand ?? (editCommand = new DelegateCommand(
            execute: () => NavigationService.Navigate(typeof(Views.OrderEditionPage), SelectedOrder),
            canexecute: () => SelectedOrder != null));

    }
}
