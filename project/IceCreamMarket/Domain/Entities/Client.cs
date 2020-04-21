using System.Collections.Generic;
using Domain.Contracts;

namespace Domain.Entities
{
    public class Client: IClientIdentity
    {
        public int? ClientId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}