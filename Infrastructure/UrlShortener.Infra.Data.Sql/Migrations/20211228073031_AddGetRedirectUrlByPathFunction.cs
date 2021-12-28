using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Infra.Data.Sql.Migrations
{
    public partial class AddGetRedirectUrlByPathFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RedirectUrl",
                table: "ShortUrls",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedirectUrl",
                table: "ShortUrls");
        }
    }
}
