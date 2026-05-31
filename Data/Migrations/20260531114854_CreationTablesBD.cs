using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestStationService.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreationTablesBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "table_client",
                columns: table => new
                {
                    IdCli = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCli = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrenomCli = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TelCli = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_client", x => x.IdCli);
                });

            migrationBuilder.CreateTable(
                name: "table_employe",
                columns: table => new
                {
                    IdEmp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEmp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrenomEmp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MDPHash = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    RoleEmp = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_employe", x => x.IdEmp);
                });

            migrationBuilder.CreateTable(
                name: "table_produit",
                columns: table => new
                {
                    IdProd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TypeCarb = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_produit", x => x.IdProd);
                });

            migrationBuilder.CreateTable(
                name: "table_cuve",
                columns: table => new
                {
                    IdCuve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapaciteMax = table.Column<int>(type: "int", nullable: false),
                    NiveauActu = table.Column<int>(type: "int", nullable: false),
                    IdProd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_cuve", x => x.IdCuve);
                    table.CheckConstraint("NiveauActu_inf_CapaciteMax", "[NiveauActu] <= [CapaciteMax]");
                    table.ForeignKey(
                        name: "FK_table_cuve_table_produit_IdProd",
                        column: x => x.IdProd,
                        principalTable: "table_produit",
                        principalColumn: "IdProd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_pompe",
                columns: table => new
                {
                    IdPompe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibelleP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EtatP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VolTotalDist = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdProd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_pompe", x => x.IdPompe);
                    table.ForeignKey(
                        name: "FK_table_pompe_table_produit_IdProd",
                        column: x => x.IdProd,
                        principalTable: "table_produit",
                        principalColumn: "IdProd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_vente",
                columns: table => new
                {
                    IdVente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateHeure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QteLitre = table.Column<int>(type: "int", nullable: false),
                    MontantV = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NumFact = table.Column<int>(type: "int", nullable: false),
                    DateEmis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatutFact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdCli = table.Column<int>(type: "int", nullable: false),
                    IdEmp = table.Column<int>(type: "int", nullable: false),
                    IdPompe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_vente", x => x.IdVente);
                    table.ForeignKey(
                        name: "FK_table_vente_table_client_IdCli",
                        column: x => x.IdCli,
                        principalTable: "table_client",
                        principalColumn: "IdCli",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_table_vente_table_employe_IdEmp",
                        column: x => x.IdEmp,
                        principalTable: "table_employe",
                        principalColumn: "IdEmp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_table_vente_table_pompe_IdPompe",
                        column: x => x.IdPompe,
                        principalTable: "table_pompe",
                        principalColumn: "IdPompe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_paiement",
                columns: table => new
                {
                    IdPaye = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePaye = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontantPaye = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ModePaye = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IdVente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_paiement", x => x.IdPaye);
                    table.ForeignKey(
                        name: "FK_table_paiement_table_vente_IdVente",
                        column: x => x.IdVente,
                        principalTable: "table_vente",
                        principalColumn: "IdVente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_table_cuve_IdProd",
                table: "table_cuve",
                column: "IdProd");

            migrationBuilder.CreateIndex(
                name: "IX_table_paiement_IdVente",
                table: "table_paiement",
                column: "IdVente");

            migrationBuilder.CreateIndex(
                name: "IX_table_pompe_IdProd",
                table: "table_pompe",
                column: "IdProd");

            migrationBuilder.CreateIndex(
                name: "IX_table_vente_IdCli",
                table: "table_vente",
                column: "IdCli");

            migrationBuilder.CreateIndex(
                name: "IX_table_vente_IdEmp",
                table: "table_vente",
                column: "IdEmp");

            migrationBuilder.CreateIndex(
                name: "IX_table_vente_IdPompe",
                table: "table_vente",
                column: "IdPompe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_cuve");

            migrationBuilder.DropTable(
                name: "table_paiement");

            migrationBuilder.DropTable(
                name: "table_vente");

            migrationBuilder.DropTable(
                name: "table_client");

            migrationBuilder.DropTable(
                name: "table_employe");

            migrationBuilder.DropTable(
                name: "table_pompe");

            migrationBuilder.DropTable(
                name: "table_produit");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
