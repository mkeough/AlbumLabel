using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbumLabel.Migrations
{
    public partial class UpdatedSongLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Lyrics",
                table: "Songs",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Songs",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Lyrics",
                table: "Songs",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "Songs",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
