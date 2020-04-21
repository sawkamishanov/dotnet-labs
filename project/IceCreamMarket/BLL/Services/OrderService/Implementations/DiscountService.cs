using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.OrderService.Contracts;
using Data.Implementations;
using Data.Contracts;
using Domain.Entities;

namespace BLL.Services.OrderService.Implementations
{
    public class DiscountService: IDiscountService
    {
        private const int SMALL_DISCOUNT = 3; // 10
        private const int AV_DISCOUNT = 6; // 15
        private const int BIG_DISCOUNT = 9; // 30

        public void GetDiscount(Order order)
        {
            var numberOfOrders = order.Count;

            if (numberOfOrders < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (numberOfOrders == 0)
            {
                return;
            }

            if (numberOfOrders >= SMALL_DISCOUNT && numberOfOrders < AV_DISCOUNT)
            {
                order.Price *= 0.1m;
            }
            else if (numberOfOrders >= AV_DISCOUNT && numberOfOrders < BIG_DISCOUNT)
            {
                order.Price *= 0.15m;
            }
            else
            {
                order.Price *= 0.30m;
            }
        }
    }
}