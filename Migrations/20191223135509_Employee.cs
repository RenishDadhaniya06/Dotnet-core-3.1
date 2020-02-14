using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositorywithDI.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OtherContact = table.Column<string>(nullable: true),
                    CurrentSalary = table.Column<string>(nullable: true),
                    LeaveBalance = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    DepartmentId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
