using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronica.Persistencia.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    LegendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeVice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Legenda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.LegendaId);
                });

            migrationBuilder.CreateTable(
                name: "Votos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    DataDeVoto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "LegendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Candidatos",
                columns: new[] { "LegendaId", "DataDeRegistro", "Legenda", "Nome", "NomeVice" },
                values: new object[] { 1, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Branco", null });

            migrationBuilder.InsertData(
                table: "Candidatos",
                columns: new[] { "LegendaId", "DataDeRegistro", "Legenda", "Nome", "NomeVice" },
                values: new object[] { 2, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Nulo", null });

            migrationBuilder.CreateIndex(
                name: "IX_Votos_CandidatoId",
                table: "Votos",
                column: "CandidatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votos");

            migrationBuilder.DropTable(
                name: "Candidatos");
        }
    }
}
