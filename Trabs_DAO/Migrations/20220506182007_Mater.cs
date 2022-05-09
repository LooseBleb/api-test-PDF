using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabs_DAO.Migrations
{
    public partial class Mater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matter",
                columns: table => new
                {
                    MatterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Icon = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matter", x => x.MatterID);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatterId = table.Column<int>(type: "int", nullable: false),
                    PDF = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Matter_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matter",
                        principalColumn: "MatterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matter_Name",
                table: "Matter",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_MatterId",
                table: "Works",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_Name",
                table: "Works",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Matter");
        }
    }
}
