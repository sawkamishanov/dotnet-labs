using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class CompositionDataSource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<SelectedCompositionDataSource> Compositions { get; set; }
    }
}