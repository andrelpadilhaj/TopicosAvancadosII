using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Data.Migrations
{
    public partial class Included_Pedidos_RelPedidosProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_DBPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DataHoraAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraFechamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DBPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DBPedidos__DBFuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "_DBFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DBPedidos__DBMesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "_DBMesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_DBRelPedidosProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DBRelPedidosProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DBRelPedidosProdutos__DBPedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "_DBPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DBRelPedidosProdutos__DBProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "_DBProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__DBPedidos_FuncionarioId",
                table: "_DBPedidos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX__DBPedidos_MesaId",
                table: "_DBPedidos",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX__DBRelPedidosProdutos_PedidoId",
                table: "_DBRelPedidosProdutos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX__DBRelPedidosProdutos_ProdutoId",
                table: "_DBRelPedidosProdutos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_DBRelPedidosProdutos");

            migrationBuilder.DropTable(
                name: "_DBPedidos");
        }
    }
}
