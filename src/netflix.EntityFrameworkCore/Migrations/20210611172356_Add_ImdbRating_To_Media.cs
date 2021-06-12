using Microsoft.EntityFrameworkCore.Migrations;

namespace netflix.Migrations
{
    public partial class Add_ImdbRating_To_Media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImdbRating",
                table: "Medias",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbRating",
                table: "Medias");
        }
    }
}
