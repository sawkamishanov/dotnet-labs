using System;
using System.Threading.Tasks;
using BLL.Services.OrderService.Repositories;
using Data.Repositories;
using Domain;
using Domain.Entities;

namespace BLL.Services.OrderService.Implementations
{
    public class UpdateOrderService: IUpdateOrderService
    {
        private IRepository<Order> DataAccess { get; }
        private IOrderService OrderService { get; }
        
        public UpdateOrderService(IRepository<Order> dataAccess, IOrderService orderService)
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

        public async Task DeleteOrder(IEntityIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            
            await DataAccess.Delete(identity);
        }
    }
}