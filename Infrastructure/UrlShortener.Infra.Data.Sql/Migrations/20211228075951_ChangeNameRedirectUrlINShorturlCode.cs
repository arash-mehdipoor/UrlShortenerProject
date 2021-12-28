using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortener.Infra.Data.Sql.Migrations
{
    public partial class ChangeNameRedirectUrlINShorturlCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RedirectUrl",
                table: "ShortUrls",
                newName: "ShorturlCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShorturlCode",
                table: "ShortUrls",
                newName: "RedirectUrl");
        }
    }
}
