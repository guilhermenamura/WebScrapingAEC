using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScrapingAEC.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebScraping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Autor = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DataPublicacao = table.Column<string>(type: "text", nullable: false),
                    RunWebScrapingAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebScraping", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebScraping_Area",
                table: "WebScraping",
                column: "Area");

            migrationBuilder.CreateIndex(
                name: "IX_WebScraping_Autor",
                table: "WebScraping",
                column: "Autor");

            migrationBuilder.CreateIndex(
                name: "IX_WebScraping_DataPublicacao",
                table: "WebScraping",
                column: "DataPublicacao");

            migrationBuilder.CreateIndex(
                name: "IX_WebScraping_Descricao",
                table: "WebScraping",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_WebScraping_Titulo",
                table: "WebScraping",
                column: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebScraping");
        }
    }
}
