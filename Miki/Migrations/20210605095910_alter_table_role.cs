using Microsoft.EntityFrameworkCore.Migrations;

namespace Miki.Migrations
{
    public partial class alter_table_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "NameRu");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Roles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKk",
                table: "Roles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NameKk",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "NameRu",
                table: "Roles",
                newName: "Name");
        }
    }
}
