using Microsoft.EntityFrameworkCore.Migrations;

namespace HackingTheWeb.Migrations
{
    public partial class changedLoginClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Login",
                newName: "SecretPassWord");

            migrationBuilder.CreateTable(
                name: "LevelFour",
                columns: table => new
                {
                    passForLevelFour = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelFour", x => x.passForLevelFour);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelFour");

            migrationBuilder.RenameColumn(
                name: "SecretPassWord",
                table: "Login",
                newName: "Password");
        }
    }
}
