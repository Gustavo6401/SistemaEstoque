using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoque.Infra.Migrations
{
    public partial class Estoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdEstoque = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdTotal = table.Column<int>(type: "int", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaSolicitada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdSolicitada = table.Column<int>(type: "int", nullable: false),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaSolicitada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaquinaSolicitada_Equipamento_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaquinaSolicitada_Solicitante_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Final = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acesso_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Script de Subida da View;
            migrationBuilder.Sql(
                @"Create View Solicitacao As " +
                    @"Select MaquinaSolicitada.Id As IdSolicitacao, " + 
                    @"MaquinaSolicitada.QtdSolicitada As QtdSolicitada, " + 
                    @"Equipamento.Nome As NomeEquipamento, " + 
                    @"Solicitante.Nome As NomeSolicitante " + 
                    @"From ((MaquinaSolicitada " + 
                    @"Join Equipamento On MaquinaSolicitada.EquipamentoId = Equipamento.Id) " + 
                    @"Join Solicitante On MaquinaSolicitada.SolicitanteId = Solicitante.Id)");

            migrationBuilder.CreateIndex(
                name: "IX_Acesso_UsuarioId",
                table: "Acesso",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MaquinaSolicitada_EquipamentoId",
                table: "MaquinaSolicitada",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MaquinaSolicitada_SolicitanteId",
                table: "MaquinaSolicitada",
                column: "SolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acesso");

            migrationBuilder.DropTable(
                name: "MaquinaSolicitada");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Solicitante");

            migrationBuilder.DropTable(
                name: "Solicitacao");
        }
    }
}
