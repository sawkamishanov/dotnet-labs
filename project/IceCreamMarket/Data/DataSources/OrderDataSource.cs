using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class OrderDataSource
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<IceCreamDataSource> Orders { get; set; }
    }
}