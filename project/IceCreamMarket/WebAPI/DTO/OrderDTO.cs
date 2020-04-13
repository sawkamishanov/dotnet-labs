using System.Collections.Generic;

namespace WebAPI.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public IEnumerable<IceCreamDTO> Orders { get; set; }
    }
}