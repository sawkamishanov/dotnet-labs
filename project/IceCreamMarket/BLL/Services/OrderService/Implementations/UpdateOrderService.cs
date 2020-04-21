using System;
using System.Threading.Tasks;
using BLL.Services.OrderService.Contracts;
using Data.Contracts;
using Domain.Contracts;
using Domain.Entities;

namespace BLL.Services.OrderService.Implementations
{
    public class UpdateOrderService: IUpdateOrderService
    {
        private IOrderDataAccess DataAccess { get; }
        private IOrderService OrderService { get; }
        
        public UpdateOrderService(IOrderDataAccess dataAccess, IOrderService orderService)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            OrderService = orderService ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            
            await DataAccess.Update(order);
        }

        public async Task DeleteOrder(IOrderIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            
            await DataAccess.Delete(identity);
        }
    }
}