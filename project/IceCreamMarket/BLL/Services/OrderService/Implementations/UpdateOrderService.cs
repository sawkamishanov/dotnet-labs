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
        
        public UpdateOrderService(IOrderDataAccess dataAccess)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            
            return await DataAccess.UpdateOrder(order);
        }

        public async Task<bool> DeleteOrder(IOrderIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            
            return await DataAccess.DeleteOrder(identity);
        }
    }
}