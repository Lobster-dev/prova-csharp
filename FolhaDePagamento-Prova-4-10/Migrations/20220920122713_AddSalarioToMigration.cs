using Microsoft.EntityFrameworkCore.Migrations;

namespace FolhaDePagamento.Migrations
{
    public partial class AddSalarioToMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salario",
                table: "funcionarios",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "funcionarios");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "funcionarios");
        }
    }
}
