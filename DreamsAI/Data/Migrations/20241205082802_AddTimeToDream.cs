using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamsAI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeToDream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Dream",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0)); // Задава време по подразбиране (00:00:00)
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Dream");
        }
    }

}
