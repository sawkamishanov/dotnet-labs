using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class IceCreamDataSource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CompositionDataSource> Compositions { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}