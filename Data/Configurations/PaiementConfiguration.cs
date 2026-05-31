using GestStationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestStationService.Data.Configurations
{
    public class PaiementConfiguration : IEntityTypeConfiguration<Paiement>
    {
        public void Configure(EntityTypeBuilder<Paiement> builder)
        {
            builder.ToTable("table_paiement");
            builder.HasKey(p => p.IdPaye);
            builder.HasOne(p => p.Vente).WithMany(v => v.Paiement).HasForeignKey(p => p.IdVente);
            builder.Property(p => p.MontantPaye).HasColumnType("decimal(10,2)");
            builder.Property(p => p.ModePaye).HasMaxLength(15); 
        }
    }
}
