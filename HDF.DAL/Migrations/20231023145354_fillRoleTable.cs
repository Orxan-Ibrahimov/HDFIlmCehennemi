using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDF.DAL.Migrations
{
    public partial class fillRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "61456c61-336c-4ff3-82af-68a0bdadd02a", "Admin", null },
                    { 2, "5c6ef8b5-dae6-4598-a6f0-25ca95d85514", "Supervisor", null },
                    { 3, "d846a883-42ae-4dbf-863c-add751c3828a", "Project Manager", null },
                    { 4, "00f525ea-7aa4-4490-bb87-b22e576491e5", "Worker", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
