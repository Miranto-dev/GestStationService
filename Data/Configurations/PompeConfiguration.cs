using GestStationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestStationService.Data.Configurations
{
    public class PompeConfiguration : IEntityTypeConfiguration<Pompe>
    {
        public void Configure(EntityTypeBuilder<Pompe> builder)
        {
            builder.ToTable("table_pompe");
            builder.HasKey(p => p.IdPompe);
            builder.Property(p => p.LibelleP).HasMaxLength(30);
            builder.Property(p => p.EtatP).HasMaxLength(20);
            builder.Property(p => p.VolTotalDist).HasColumnType("decimal(10,2)");
            builder.HasOne(p => p.Produit).WithMany(p => p.Pompe).HasForeignKey(p => p.IdProd);
            builder.HasMany(p => p.Vente).WithOne(v => v.Pompe);
        } 
    }
}
