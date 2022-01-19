using Microsoft.EntityFrameworkCore.Migrations;

namespace Samsung.Web.Data.Migrations
{
    public partial class AddDeveloperSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name", "Skills", "TeamId" },
                values: new object[] { 2518, "Raihan Nishat", "OOP, Design Pattern, C#, .NET Core, AWS", 584 });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name", "Skills", "TeamId" },
                values: new object[] { 2548, "Asif Abdullah", "C++, Algorithm, Data Structure", 149 });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name", "Skills", "TeamId" },
                values: new object[] { 2545, "Zihad Muhammad", "C++, Degital Device, Robotics", 275 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2518);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2545);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2548);
        }
    }
}
