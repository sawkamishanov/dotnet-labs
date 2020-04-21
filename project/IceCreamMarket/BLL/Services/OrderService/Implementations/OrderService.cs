using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.OrderService.Contracts;
using Data.Contracts;
using Domain;
using Domain.Entities;

namespace BLL.Services.OrderService.Implementations
{
    public class OrderService: IOrderService
    {
        private IRepository<Order> DataAccess { get; }
        private IDiscountService DiscountService { get; }

        public OrderService(IRepository<Order> dataAccess, IDiscountService discountService)
        {
            DataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            DiscountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
        }

        public async Task MakeOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            
            DiscountService.GetDiscount(order);
            
            await DataAccess.Create(order);
        }

        public async Task<Order> GetOrder(IEntityIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            
            var result = await DataAccess.Get(identity);

            if (result == null)
            {
                throw new InvalidOperationException($"Not find by id: {identity.Id}");
            }

            return result;
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await DataAccess.Get();
        }
    }
}