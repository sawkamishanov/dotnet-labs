using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class IceCreamDataSource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<ActiveOrders> Orders { get; set; }
        public IEnumerable<CompositionDataSource> Compositions { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
    }
}