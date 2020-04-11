using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataSources    
{
    [Table("clients")]
    public partial class ClientDataSource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OrderDataSource> Orders { get; set; }
    }
}