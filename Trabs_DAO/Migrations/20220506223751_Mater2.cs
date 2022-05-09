using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabs_DAO.Migrations
{
    public partial class Mater2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatterID",
                table: "Matter",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Matter",
                newName: "MatterID");
        }
    }
}
