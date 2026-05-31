using GestStationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestStationService.Data.Configurations
{
    public class CuveConfiguration : IEntityTypeConfiguration<Cuve>
    {
        public void Configure(EntityTypeBuilder<Cuve> builder)
        {
            builder.ToTable("table_cuve");
            builder.HasKey(c => c.IdCuve);
            builder.HasOne(c => c.Produit).WithMany(p => p.Cuve).HasForeignKey(c => c.IdProd);
            builder.ToTable(c => c.HasCheckConstraint(
                "NiveauActu_inf_CapaciteMax",
                "[NiveauActu] <= [CapaciteMax]"));
            
        }
    } 
}
