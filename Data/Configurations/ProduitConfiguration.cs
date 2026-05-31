using GestStationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestStationService.Data.Configurations
{
    public class ProduitConfiguration:IEntityTypeConfiguration<Produit>
    {
        public void Configure(EntityTypeBuilder<Produit> builder)
        {
            builder.ToTable("table_produit");
            builder.HasKey(p => p.IdProd);
            builder.Property(p => p.NomProd).HasMaxLength(30);
            builder.Property(p => p.PrixUnitaire).HasColumnType("decimal(10,2)");
            builder.Property(p => p.TypeCarb).HasMaxLength(25);
            builder.HasMany(p => p.Cuve).WithOne(c => c.Produit);
            builder.HasMany(p => p.Pompe).WithOne(p => p.Produit);
        }
    }
}
