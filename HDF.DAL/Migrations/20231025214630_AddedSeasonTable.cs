using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDF.DAL.Migrations
{
    public partial class AddedSeasonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Movies_MovieId",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Episodes",
                newName: "SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_MovieId",
                table: "Episodes",
                newName: "IX_Episodes_SeasonId");

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e512ee45-99ae-43f5-ac68-d9fcd6625bc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "73b47371-dd92-4b31-8185-ef049fba0187");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "944212e4-a7b1-4b53-954e-f5d0ba5672b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6d79fbd6-076e-4689-a6e1-975838de9845");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_MovieId",
                table: "Seasons",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Seasons_SeasonId",
                table: "Episodes",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Seasons_SeasonId",
                table: "Episodes");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "Episodes",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                newName: "IX_Episodes_MovieId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c80151de-4301-4a0b-ae35-5676d8730827");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b0ef1708-b3c1-420b-858e-91d87bf68c61");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "de01d13a-1d7b-4246-9f2c-9bfb0df85e49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "3e3bf5fb-ce86-4c62-871a-12216a8c279e");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Movies_MovieId",
                table: "Episodes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
