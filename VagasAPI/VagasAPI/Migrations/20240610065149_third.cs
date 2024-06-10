using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VagasAPI.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailCandidato",
                table: "Inscricoes");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Inscricoes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_UserId",
                table: "Inscricoes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_AspNetUsers_UserId",
                table: "Inscricoes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_AspNetUsers_UserId",
                table: "Inscricoes");

            migrationBuilder.DropIndex(
                name: "IX_Inscricoes_UserId",
                table: "Inscricoes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inscricoes");

            migrationBuilder.AddColumn<string>(
                name: "emailCandidato",
                table: "Inscricoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
