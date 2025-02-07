using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flower_App_copia_1.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piante_AspNetUsers_UserId",
                table: "Piante");

            migrationBuilder.DropIndex(
                name: "IX_Piante_UserId",
                table: "Piante");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Piante");

            migrationBuilder.RenameColumn(
                name: "Fioritura",
                table: "Piante",
                newName: "FiorituraMinima");

            migrationBuilder.RenameColumn(
                name: "Descrizione",
                table: "Piante",
                newName: "DescrizionePianta");

            migrationBuilder.AlterColumn<int>(
                name: "Ambiente",
                table: "Piante",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "Colore",
                table: "Piante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FiorituraMassima",
                table: "Piante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clienti_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientePianta",
                columns: table => new
                {
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PiantaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientePiantaId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePianta", x => new { x.ClienteId, x.PiantaId });
                    table.ForeignKey(
                        name: "FK_ClientePianta_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientePianta_Piante_PiantaId",
                        column: x => x.PiantaId,
                        principalTable: "Piante",
                        principalColumn: "IdPianta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientePianta_PiantaId",
                table: "ClientePianta",
                column: "PiantaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_UserId",
                table: "Clienti",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientePianta");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropColumn(
                name: "Colore",
                table: "Piante");

            migrationBuilder.DropColumn(
                name: "FiorituraMassima",
                table: "Piante");

            migrationBuilder.RenameColumn(
                name: "FiorituraMinima",
                table: "Piante",
                newName: "Fioritura");

            migrationBuilder.RenameColumn(
                name: "DescrizionePianta",
                table: "Piante",
                newName: "Descrizione");

            migrationBuilder.AlterColumn<bool>(
                name: "Ambiente",
                table: "Piante",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Piante",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Piante_UserId",
                table: "Piante",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Piante_AspNetUsers_UserId",
                table: "Piante",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
