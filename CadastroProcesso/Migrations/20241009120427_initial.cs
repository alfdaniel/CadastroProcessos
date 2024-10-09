using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroProcesso.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    ProcessoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProcesso = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Npu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVizualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodMunicipio = table.Column<int>(type: "int", nullable: false),
                    Visualizado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.ProcessoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processos");
        }
    }
}
