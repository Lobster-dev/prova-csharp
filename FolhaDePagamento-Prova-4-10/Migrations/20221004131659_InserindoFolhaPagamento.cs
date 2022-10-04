using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FolhaDePagamento.Migrations
{
    public partial class InserindoFolhaPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedAt",
                table: "funcionarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "funcionarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "folhaPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorHora = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeDeHoras = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    imporstoRenda = table.Column<double>(type: "REAL", nullable: false),
                    impostoInss = table.Column<double>(type: "REAL", nullable: false),
                    impostoFgts = table.Column<double>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<double>(type: "REAL", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folhaPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_folhaPagamentos_funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_folhaPagamentos_FuncionarioId",
                table: "folhaPagamentos",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "folhaPagamentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "funcionarios",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "funcionarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
