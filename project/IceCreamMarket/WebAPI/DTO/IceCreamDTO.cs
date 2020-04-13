using System.Collections.Generic;

namespace WebAPI.DTO
{
    public class IceCreamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CompositionDTO> Compositions { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}