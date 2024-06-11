using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteDotNetApp.Migrations
{
    /// <inheritdoc />
    public partial class BancoReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NVARCHAR = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    VARCHAR = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vaga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoVaga",
                columns: table => new
                {
                    CandidatosID = table.Column<int>(type: "int", nullable: false),
                    VagaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoVaga", x => new { x.CandidatosID, x.VagaID });
                    table.ForeignKey(
                        name: "FK_CandidatoVaga_Candidato_CandidatosID",
                        column: x => x.CandidatosID,
                        principalTable: "Candidato",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoVaga_Vaga_VagaID",
                        column: x => x.VagaID,
                        principalTable: "Vaga",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoVaga_VagaID",
                table: "CandidatoVaga",
                column: "VagaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoVaga");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Vaga");
        }
    }
}
