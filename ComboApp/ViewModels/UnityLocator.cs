using ComboApp.Services;
using Unity;

namespace ComboApp.ViewModels
{
    public class UnityLocator
    {
        private readonly UnityContainer container = new UnityContainer();

        public OrderPageViewModel OrderPageViewModel => container.Resolve<OrderPageViewModel>();
        public OrderEditionPageViewModel OrderEditionPageViewModel => container.Resolve<OrderEditionPageViewModel>();

        public UnityLocator()
        {
            //container.RegisterType<IOrderService, OrderService>();
            //container.RegisterType<IBusinessAssociateService, BusinessAssociateService>();

            container.RegisterType<IOrderService, OrderOfflineService>();
            container.RegisterType<IBusinessAssociateService, BusinessAssociateOfflineService>();
        }
    }
}
