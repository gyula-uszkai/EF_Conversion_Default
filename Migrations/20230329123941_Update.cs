using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Conversion_Default.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Cluj");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locations",
                table: "Users");
        }
    }
}
