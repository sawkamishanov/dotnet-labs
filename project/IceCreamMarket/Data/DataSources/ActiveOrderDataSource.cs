using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataSources
{
    public partial class ActiveOrderDataSource
    {
        public int OrderId { get; set; }
        public int IceCreamId { get; set; }
        
        public OrderDataSource Order { get; set; }
        public IceCreamDataSource IceCream { get; set; }
        public DateTime OrderTime { get; set; }
    }
}