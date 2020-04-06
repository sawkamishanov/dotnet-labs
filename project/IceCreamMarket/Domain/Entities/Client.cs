using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client: IEntityIdentity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}