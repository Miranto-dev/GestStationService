using GestStationService.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GestStationService.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur
builder.Services.AddRazorPages();

// On dit à ASP.NET d'utiliser la chaîne de connexion lié à SQLServer dans le fichier : appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

//C'est ici qu'on précise qu'on souhaite ajouter une authentification de base avec UI pour pouvoir Personnaliser les pages de connexion
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    // Désactiver la confirmation d'email pour le développement
    options.SignIn.RequireConfirmedAccount = true;

    // Ici on spécifie le mot de passe
    options.Password.RequireDigit = true; // au moins un chiffre
    options.Password.RequiredLength = 6;    // au moins 6 caractères
    options.Password.RequireNonAlphanumeric = false;    //les caractères spéciaux ne sont pas obligatoire
    options.Password.RequireUppercase = true;   //au moins un caractère en majuscule
    options.Password.RequireLowercase = true;   //au moins un caractère en miniscule

    //Un email = un compte
    options.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()                           //Ici on active les rôles
.AddEntityFrameworkStores<ApplicationDbContext>()  //Là on dit à Identity d'utiliser la classe de base d'EF : Le DbContext
.AddDefaultTokenProviders();    //... 

// Pour l'interface utilisateur Identity
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/Login");
});

//Ici c'est pour configurer le Cookie 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";                    //chemin mênant vers la page login
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";     //chemin mênant vers la page de notification d' "accès refusé"
    options.ExpireTimeSpan = TimeSpan.FromDays(2);
});

builder.Services.AddControllersWithViews();     //Ajoute le support Controller et View


// Là on construit l'application
var app = builder.Build();

//Gère les erreur au moment de la production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();       //active les fichier dans le dossier wwwroot
app.UseRouting();           //active le système de routeage (une règle de correspondance entre la requête URL et les pages associés

app.UseAuthentication();    //D'abord on s'authentifie , ici le serveur lit le Cookie
app.UseAuthorization();     //Puis on détermine de quoi l'utilisateur à le droit de faire

//Ici on commence le seeding des Rôles et admin
using (var scope = app.Services.CreateScope())
{
    //Configuration des rôles pour les utilisateurs
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string[] roles = { "Admin", "Pompiste", "Caissier" };
    foreach(var role in roles)
    {
        //Là on vérifie si le rôle n'éxiste pas encore -> si oui on la crée
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    //Configuration des comptes utilisateurs
    string adminEmail = "miranto@gmail.com";
    if(await userManager.FindByEmailAsync(adminEmail) == null)
    {
        IdentityUser admin = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        var identityResult = await userManager.CreateAsync(admin, "Miranto2007");
        if (identityResult.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }

}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");     //La route par défaut

app.MapRazorPages();        //Important pour les pages Razor d'Identity (login, register etc...)



app.Run();
