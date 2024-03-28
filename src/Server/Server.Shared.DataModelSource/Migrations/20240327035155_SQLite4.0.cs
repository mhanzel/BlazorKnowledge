using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Shared.DataModelSource.Migrations
{
    /// <inheritdoc />
    public partial class SQLite40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Id",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id",
                table: "Customer",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Id",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id",
                table: "Customer",
                column: "Id",
                unique: true);
        }
    }
}
