using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGNet002_Week_7_8_Task.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicIdColumnToProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Projects");
        }
    }
}
