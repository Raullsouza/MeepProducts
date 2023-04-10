using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeepProducts.Migrations
{
    /// <inheritdoc />
    public partial class BasePopulada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PortalId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preco",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PortalId",
                table: "Produtos",
                column: "PortalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Portais_PortalId",
                table: "Produtos",
                column: "PortalId",
                principalTable: "Portais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Portais_PortalId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PortalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PortalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Produtos");
        }
    }
}
