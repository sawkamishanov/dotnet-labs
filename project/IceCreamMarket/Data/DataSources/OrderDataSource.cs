using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataSources
{
    public partial class OrderDataSource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public IEnumerable<ActiveOrderDataSource> Orders { get; set; }
    }
}