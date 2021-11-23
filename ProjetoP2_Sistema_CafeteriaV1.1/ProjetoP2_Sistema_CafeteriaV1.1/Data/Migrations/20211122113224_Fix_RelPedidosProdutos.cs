using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Data.Migrations
{
    public partial class Fix_RelPedidosProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "_DBRelPedidosProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "_DBRelPedidosProdutos");
        }
    }
}
