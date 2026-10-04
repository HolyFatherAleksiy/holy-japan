using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseRepository.Migrations
{
    /// <inheritdoc />
    public partial class Update20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "UserDatas",
                newName: "BackgroundImage");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Languages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Languages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Languages");

            migrationBuilder.RenameColumn(
                name: "BackgroundImage",
                table: "UserDatas",
                newName: "Avatar");
        }
    }
}
