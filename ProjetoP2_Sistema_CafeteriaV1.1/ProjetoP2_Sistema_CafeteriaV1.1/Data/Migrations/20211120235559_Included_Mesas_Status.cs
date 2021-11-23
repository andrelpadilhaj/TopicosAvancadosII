using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Data.Migrations
{
    public partial class Included_Mesas_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_DBStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DBStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_DBMesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCadeiras = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DBMesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DBMesas__DBStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "_DBStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__DBMesas_StatusId",
                table: "_DBMesas",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_DBMesas");

            migrationBuilder.DropTable(
                name: "_DBStatus");
        }
    }
}
