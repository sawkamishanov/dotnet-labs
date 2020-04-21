using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.OrderService.Contracts;
using Data.Contracts;
using Domain.Contracts;
using Domain.Entities;

namespace BLL.Services.OrderService.Implementations
{
    public class OrderService: IOrderService
    {
        private IOrderDataAccess DataAccess { get; }
        private IDiscountService DiscountService { get; }

        public OrderService(IOrderDataAccess dataAccess, IDiscountService discountService)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            DiscountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
        }

        public async Task<Order> MakeOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            
            DiscountService.GetDiscount(order);
            
            return await DataAccess.CreateOrder(order);
        }

        public async Task<Order> GetOrder(IOrderIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            
            var result = await DataAccess.Get(identity);

            if (result == null)
            {
                throw new InvalidOperationException($"Not find by id: {identity.OrderId}");
            }

            return result;
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await DataAccess.Get();
        }
    }
}