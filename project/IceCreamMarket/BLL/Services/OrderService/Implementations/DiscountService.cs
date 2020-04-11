using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.OrderService.Repositories;
using Data.Implementations;
using Data.Repositories;
using Domain.Entities;

namespace BLL.Services.OrderService.Implementations
{
    public class DiscountService: IDiscountService
    {
        private const int SMALL_DISCOUNT = 5;
        private const int AV_DISCOUNT = 10;
        private const int BIG_DISCOUNT = 15;

        public decimal GetDiscount(Order order)
        {
            var numberOfOrders = order.Orders.Count();

            if (numberOfOrders <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return 0;
        }
    }
}