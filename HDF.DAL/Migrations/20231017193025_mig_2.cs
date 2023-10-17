using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDF.DAL.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmOrSerieId",
                table: "Movies");

            migrationBuilder.AlterColumn<decimal>(
                name: "MoviePoint",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MoviePoint",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmOrSerieId",
                table: "Movies",
                type: "int",
                nullable: true);
        }
    }
}
