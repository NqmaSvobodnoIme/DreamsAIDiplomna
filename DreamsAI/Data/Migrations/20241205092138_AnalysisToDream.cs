using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamsAI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnalysisToDream : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Analysis",
                table: "Dream",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analysis",
                table: "Dream");
        }
    }
}
