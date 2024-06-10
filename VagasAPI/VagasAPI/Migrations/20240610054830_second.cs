using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VagasAPI.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_VagaId",
                table: "Inscricoes",
                column: "VagaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_Vagas_VagaId",
                table: "Inscricoes",
                column: "VagaId",
                principalTable: "Vagas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_Vagas_VagaId",
                table: "Inscricoes");

            migrationBuilder.DropIndex(
                name: "IX_Inscricoes_VagaId",
                table: "Inscricoes");
        }
    }
}
