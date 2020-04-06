using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order: IEntityIdentity
    {
        public int? Id { get; set; }
        public IEnumerable<IceCream> Orders { get; set; }
        public double Price;
        public DateTime Date { get; set; }
    }
}