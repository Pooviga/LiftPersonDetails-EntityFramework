using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDetails.WebAPi.Migrations
{
    /// <inheritdoc />
    public partial class pkadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDetails",
                table: "PersonDetails",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDetails",
                table: "PersonDetails");
        }
    }
}
