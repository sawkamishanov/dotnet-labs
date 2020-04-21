using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts;

namespace Domain.Entities
{
    public class Order: IOrderIdentity
    {
        public int? OrderId { get; set; }
        
        public IEnumerable<IceCream> Orders { get; set; }

        public decimal Price
        {
            get
            {
                decimal result = 0;
                foreach (var order in Orders)
                {
                    result += order.Price;
                }

                return result;
            }

            set
            {
                foreach (var order in Orders)
                {
                    Price += order.Price;
                }
            }
        }

        public int Count => Orders?.Count() ?? 0;

        public DateTime Date { get; set; }
    }
}