using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class SelectedCompositionDataSource
    {
        public int IceCreamId { get; set; }
        public int CompositionId { get; set; }
        
        public IceCreamDataSource IceCream { get; set; }
        public CompositionDataSource Composition { get; set; }
    }
}