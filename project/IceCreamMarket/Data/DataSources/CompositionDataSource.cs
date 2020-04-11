using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class CompositionDataSource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}