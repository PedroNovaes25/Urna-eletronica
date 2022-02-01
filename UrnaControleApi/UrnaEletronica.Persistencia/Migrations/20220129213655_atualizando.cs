using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronica.Persistencia.Migrations
{
    public partial class atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidatos",
                keyColumn: "LegendaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidatos",
                keyColumn: "LegendaId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Candidatos",
                columns: new[] { "LegendaId", "DataDeRegistro", "Legenda", "Nome", "NomeVice" },
                values: new object[] { 8, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Branco", null });

            migrationBuilder.InsertData(
                table: "Candidatos",
                columns: new[] { "LegendaId", "DataDeRegistro", "Legenda", "Nome", "NomeVice" },
                values: new object[] { 9, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Nulo", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidatos",
                keyColumn: "LegendaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Candidatos",
                keyColumn: "LegendaId",
                keyValue: 9);

            migrationBuilder.InsertData(
                table: "Candidatos",
                columns: new[] { "LegendaId", "DataDeRegistro", "Legenda", "Nome", "NomeVice" },
                values: new object[] { 1, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Branco", null });

            migrationBuilder.InsertData(
                table: "Candidatos",
                columns: new[] { "LegendaId", "DataDeRegistro", "Legenda", "Nome", "NomeVice" },
                values: new object[] { 2, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Local), null, "Nulo", null });
        }
    }
}
