using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeAPI.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginItems",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginItems", x => x.Username);
                });
        }
    }
}
