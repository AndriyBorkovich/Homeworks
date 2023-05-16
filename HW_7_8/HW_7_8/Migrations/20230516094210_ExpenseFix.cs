using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW_7_8.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Expenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Expenses",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");
        }
    }
}
