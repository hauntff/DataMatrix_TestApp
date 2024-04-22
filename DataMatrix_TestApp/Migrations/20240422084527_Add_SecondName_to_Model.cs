using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMatrix_TestApp.Migrations
{
    /// <inheritdoc />
    public partial class Add_SecondName_to_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ContactUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ContactUsers");
        }
    }
}
