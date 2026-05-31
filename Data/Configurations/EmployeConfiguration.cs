using GestStationService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestStationService.Data.Configurations
{
    public class EmployeConfiguration:IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.ToTable("table_employe");
            builder.HasKey(e => e.IdEmp);
            builder.Property(e => e.NomEmp).HasMaxLength(50);
            builder.Property(e => e.PrenomEmp).HasMaxLength(100);
            builder.Property(e => e.MDPHash).HasMaxLength(4);
            builder.Property(e => e.RoleEmp).HasMaxLength(15);
            builder.HasMany(e => e.Vente).WithOne(v => v.Employe);
        } 
    }
}
