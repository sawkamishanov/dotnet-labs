using Data.DataSources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context.Configuration
{
    public class OrderConfiguration: IEntityTypeConfiguration<OrderDataSource>
    {
        public void Configure(EntityTypeBuilder<OrderDataSource> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}