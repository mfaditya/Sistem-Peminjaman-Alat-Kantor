using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPi.Migrations
{
    public partial class Add_Notes_RequestItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "RequestItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "RequestItems");
        }
    }
}
