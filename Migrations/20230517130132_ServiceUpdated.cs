using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDetailing.API.Migrations
{
    /// <inheritdoc />
    public partial class ServiceUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "Services",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_CustomerId",
                table: "Services",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PlateNumber",
                table: "Services",
                column: "PlateNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Cars_PlateNumber",
                table: "Services",
                column: "PlateNumber",
                principalTable: "Cars",
                principalColumn: "PlateNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Customers_CustomerId",
                table: "Services",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Cars_PlateNumber",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Customers_CustomerId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CustomerId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_PlateNumber",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "Services");
        }
    }
}
