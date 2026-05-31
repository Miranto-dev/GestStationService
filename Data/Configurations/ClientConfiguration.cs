using GestStationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestStationService.Data.Configurations
{
    public class ClientConfiguration:IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("table_client");
            builder.HasKey(c => c.IdCli);
            builder.Property(c => c.NomCli).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PrenomCli).HasMaxLength(100);
            builder.Property(c => c.TelCli).HasMaxLength(13);
            builder.HasMany(c => c.Vente).WithOne(v => v.Client);
        }
    }
}
