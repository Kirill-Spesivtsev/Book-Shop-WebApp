using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.Net_Core_Project.Migrations
{
    public partial class Added_Price_Column_in_Books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");
        }
    }
}
