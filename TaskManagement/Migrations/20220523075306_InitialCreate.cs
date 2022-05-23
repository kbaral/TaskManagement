using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "DueDate", "EndDate", "Name", "Priority", "StartDate", "Status" },
                values: new object[] { 1, "First description of seed", new DateTime(2022, 5, 23, 7, 53, 6, 252, DateTimeKind.Utc).AddTicks(9281), new DateTime(2022, 6, 22, 7, 53, 6, 252, DateTimeKind.Utc).AddTicks(9285), "First Seed", 0, new DateTime(2022, 5, 23, 7, 53, 6, 252, DateTimeKind.Utc).AddTicks(9284), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
