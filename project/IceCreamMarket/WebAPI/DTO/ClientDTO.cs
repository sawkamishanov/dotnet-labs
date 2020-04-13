using System.Collections.Generic;

namespace WebAPI.DTO   
{
    public partial class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}