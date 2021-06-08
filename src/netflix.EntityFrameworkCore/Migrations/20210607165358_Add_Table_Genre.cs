using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netflix.Migrations
{
    public partial class Add_Table_Genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Medias");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_GenreId",
                table: "Medias",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Genre_GenreId",
                table: "Medias",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Genre_GenreId",
                table: "Medias");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Medias_GenreId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
