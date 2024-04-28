using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmaraDesignApis.Migrations
{
    /// <inheritdoc />
    public partial class updateContractTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_financialContracts_AspNetUsers_UserId",
                table: "financialContracts");

            migrationBuilder.DropIndex(
                name: "IX_financialContracts_UserId",
                table: "financialContracts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "financialContracts");

            migrationBuilder.AddColumn<decimal>(
                name: "Payed",
                table: "financialContracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payed",
                table: "financialContracts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "financialContracts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_financialContracts_UserId",
                table: "financialContracts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_financialContracts_AspNetUsers_UserId",
                table: "financialContracts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
