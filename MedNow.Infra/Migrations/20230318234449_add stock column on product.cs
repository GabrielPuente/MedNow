using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedNow.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addstockcolumnonproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InStock",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Product");
        }
    }
}
