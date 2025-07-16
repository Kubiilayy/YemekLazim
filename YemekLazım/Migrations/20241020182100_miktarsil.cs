using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesiDeneme2.Migrations
{
    /// <inheritdoc />
    public partial class miktarsil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miktar",
                table: "TarifMalzemeleri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Miktar",
                table: "TarifMalzemeleri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
