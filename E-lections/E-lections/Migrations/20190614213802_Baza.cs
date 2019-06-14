using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_lections.Migrations
{
    public partial class Baza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JMBG = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BirackoMjesto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kanton = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirackoMjesto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Izbor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pocetak = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(maxLength: 200, nullable: false),
                    KantonOgranicenje = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izbor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    PutanjaSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stranka",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stranka", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GlasackiListic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaxOdabir = table.Column<int>(nullable: false),
                    BrojGlasova = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(maxLength: 100, nullable: false),
                    IzborId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlasackiListic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GlasackiListic_Izbor_IzborId",
                        column: x => x.IzborId,
                        principalTable: "Izbor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    BrojLicneKarte = table.Column<string>(maxLength: 9, nullable: false),
                    JMBG = table.Column<string>(maxLength: 13, nullable: false),
                    Spol = table.Column<int>(nullable: false),
                    Lozinka = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Kanton = table.Column<string>(nullable: true),
                    StrankaId = table.Column<int>(nullable: true),
                    BirackoMjestoID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    brojGlasova = table.Column<int>(nullable: true),
                    ProfilId = table.Column<int>(nullable: true),
                    GlasackiListicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Osoba_GlasackiListic_GlasackiListicId",
                        column: x => x.GlasackiListicId,
                        principalTable: "GlasackiListic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Osoba_Profil_ProfilId",
                        column: x => x.ProfilId,
                        principalTable: "Profil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Osoba_BirackoMjesto_BirackoMjestoID",
                        column: x => x.BirackoMjestoID,
                        principalTable: "BirackoMjesto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Osoba_Stranka_StrankaId",
                        column: x => x.StrankaId,
                        principalTable: "Stranka",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BirackoMjestoKandidat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojGlasova = table.Column<int>(nullable: false),
                    KandidatId = table.Column<int>(nullable: false),
                    BirackoMjestoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirackoMjestoKandidat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BirackoMjestoKandidat_BirackoMjesto_BirackoMjestoID",
                        column: x => x.BirackoMjestoID,
                        principalTable: "BirackoMjesto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BirackoMjestoKandidat_Osoba_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Osoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirackoMjestoKandidat_BirackoMjestoID",
                table: "BirackoMjestoKandidat",
                column: "BirackoMjestoID");

            migrationBuilder.CreateIndex(
                name: "IX_BirackoMjestoKandidat_KandidatId",
                table: "BirackoMjestoKandidat",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_GlasackiListic_IzborId",
                table: "GlasackiListic",
                column: "IzborId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_GlasackiListicId",
                table: "Osoba",
                column: "GlasackiListicId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_ProfilId",
                table: "Osoba",
                column: "ProfilId",
                unique: true,
                filter: "[ProfilId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_BirackoMjestoID",
                table: "Osoba",
                column: "BirackoMjestoID");

            migrationBuilder.CreateIndex(
                name: "IX_Osoba_StrankaId",
                table: "Osoba",
                column: "StrankaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "BirackoMjestoKandidat");

            migrationBuilder.DropTable(
                name: "Osoba");

            migrationBuilder.DropTable(
                name: "GlasackiListic");

            migrationBuilder.DropTable(
                name: "Profil");

            migrationBuilder.DropTable(
                name: "BirackoMjesto");

            migrationBuilder.DropTable(
                name: "Stranka");

            migrationBuilder.DropTable(
                name: "Izbor");
        }
    }
}
