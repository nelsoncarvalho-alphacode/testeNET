using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VagasAPI.Migrations
{
    /// <inheritdoc />
    public partial class Forth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Vagas",
                newName: "StatusVaga");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusVaga",
                table: "Vagas",
                newName: "Status");
        }
    }
}
