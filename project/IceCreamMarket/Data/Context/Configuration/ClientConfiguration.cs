using Data.DataSources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context.Configuration
{
    public class ClientConfiguration: IEntityTypeConfiguration<ClientDataSource>
    {
        public void Configure(EntityTypeBuilder<ClientDataSource> builder)
        {
            builder
                .HasKey(m => m.Id);
        }
    }
}