using GestStationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestStationService.Data.Configurations
{
    public class VenteConfiguration : IEntityTypeConfiguration<Vente>
    {
        public void Configure(EntityTypeBuilder<Vente> builder)
        {
            builder.ToTable("table_vente");
            builder.HasKey(v => v.IdVente);
            builder.Property(v => v.MontantV).HasColumnType("decimal(10,2)");
            builder.Property(v => v.StatutFact).HasMaxLength(20);
            builder.HasOne(v => v.Client).WithMany(c => c.Vente).HasForeignKey(v => v.IdCli);
            builder.HasOne(v => v.Employe).WithMany(e => e.Vente).HasForeignKey(v => v.IdEmp);
            builder.HasOne(v => v.Pompe).WithMany(p => p.Vente).HasForeignKey(v => v.IdPompe);
            builder.HasMany(v => v.Paiement).WithOne(p => p.Vente);
        }
    }
}
