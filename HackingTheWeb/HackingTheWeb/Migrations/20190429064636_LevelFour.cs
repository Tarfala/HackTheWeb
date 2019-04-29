using Microsoft.EntityFrameworkCore.Migrations;

namespace HackingTheWeb.Migrations
{
    public partial class LevelFour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LevelThree",
                columns: table => new
                {
                    PassWord = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelThree", x => x.PassWord);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelThree");
        }
    }
}
