using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesiDeneme2.Migrations
{
    /// <inheritdoc />
    public partial class tarifimageadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimUrl",
                table: "Tarifler",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimUrl",
                table: "Tarifler");
        }
    }
}
