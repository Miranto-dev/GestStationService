using GestStationService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //Déclaration de mes tables pour EF
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employe> Employes { get; set; }
    public DbSet<Vente> Ventes { get; set; }
    public DbSet<Pompe> Pompes { get; set; }
    public DbSet<Produit> Produits { get; set; }
    public DbSet<Cuve> Cuves { get; set; }
    public DbSet<Paiement> Paiements { get; set; }

    //Mes Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }


}
