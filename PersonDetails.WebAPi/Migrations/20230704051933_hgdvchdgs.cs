using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDetails.WebAPi.Migrations
{
    /// <inheritdoc />
    public partial class hgdvchdgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "PersonDetails",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "PersonDetails",
                newName: "ToFloor");

            migrationBuilder.AddColumn<string>(
                name: "FromFloor",
                table: "PersonDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromFloor",
                table: "PersonDetails");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "PersonDetails",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "ToFloor",
                table: "PersonDetails",
                newName: "FirstName");
        }
    }
}
