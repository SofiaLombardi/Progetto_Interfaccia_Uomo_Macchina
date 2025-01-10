using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_App_copia_1.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allerte",
                columns: table => new
                {
                    AllerteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoAllerta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allerte", x => x.AllerteId);
                });

            migrationBuilder.CreateTable(
                name: "Consigli",
                columns: table => new
                {
                    ConsiglioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitoloConsiglio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consigli", x => x.ConsiglioId);
                });

            migrationBuilder.CreateTable(
                name: "IdeeCasa",
                columns: table => new
                {
                    IdeeCasaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitoloIdea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeeCasa", x => x.IdeeCasaId);
                });

            migrationBuilder.CreateTable(
                name: "Tossicità",
                columns: table => new
                {
                    TossicitàId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    ÈEdibile = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tossicità", x => x.TossicitàId);
                });

            migrationBuilder.CreateTable(
                name: "Piante",
                columns: table => new
                {
                    IdPianta = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeScientifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPianta = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Esposizione = table.Column<int>(type: "int", nullable: false),
                    DescrizioneEsposizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terreno = table.Column<int>(type: "int", nullable: false),
                    PesantezzaDelTerreno = table.Column<int>(type: "int", nullable: false),
                    AciditàTerreno = table.Column<int>(type: "int", nullable: false),
                    DescrizioneTerreno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fioritura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescrizioneFioritura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Irrigazione = table.Column<int>(type: "int", nullable: false),
                    DescrizioneIrrigazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concime = table.Column<int>(type: "int", nullable: false),
                    DescrizioneConcimazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Potatura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescrizionePotatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ambiente = table.Column<bool>(type: "bit", nullable: false),
                    DescrizioneAmbiente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdeeCasaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConsigliId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piante", x => x.IdPianta);
                    table.ForeignKey(
                        name: "FK_Piante_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Piante_Consigli_ConsigliId",
                        column: x => x.ConsigliId,
                        principalTable: "Consigli",
                        principalColumn: "ConsiglioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Piante_IdeeCasa_IdeeCasaId",
                        column: x => x.IdeeCasaId,
                        principalTable: "IdeeCasa",
                        principalColumn: "IdeeCasaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trattamenti",
                columns: table => new
                {
                    IdTrattamento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ripetizioni = table.Column<int>(type: "int", nullable: false),
                    IdPianta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PiantaIdPianta = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AllerteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trattamenti", x => x.IdTrattamento);
                    table.ForeignKey(
                        name: "FK_Trattamenti_Allerte_AllerteId",
                        column: x => x.AllerteId,
                        principalTable: "Allerte",
                        principalColumn: "AllerteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trattamenti_Piante_PiantaIdPianta",
                        column: x => x.PiantaIdPianta,
                        principalTable: "Piante",
                        principalColumn: "IdPianta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piante_ConsigliId",
                table: "Piante",
                column: "ConsigliId");

            migrationBuilder.CreateIndex(
                name: "IX_Piante_IdeeCasaId",
                table: "Piante",
                column: "IdeeCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Piante_UserId",
                table: "Piante",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trattamenti_AllerteId",
                table: "Trattamenti",
                column: "AllerteId");

            migrationBuilder.CreateIndex(
                name: "IX_Trattamenti_PiantaIdPianta",
                table: "Trattamenti",
                column: "PiantaIdPianta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tossicità");

            migrationBuilder.DropTable(
                name: "Trattamenti");

            migrationBuilder.DropTable(
                name: "Allerte");

            migrationBuilder.DropTable(
                name: "Piante");

            migrationBuilder.DropTable(
                name: "Consigli");

            migrationBuilder.DropTable(
                name: "IdeeCasa");
        }
    }
}
