using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace szerzodeskezelo_api.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szerzodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Azonosito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KotesDatuma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LejaratDatuma = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Megjegyzes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Osszeg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UgyfelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DokumentumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szerzodes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Szerzodes");
        }
    }
}
