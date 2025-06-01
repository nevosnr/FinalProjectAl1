using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectAl1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Requesttypesinclusion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8e92c7-6cd0-4f24-b53e-c2b6a110a67d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833fc580-1c54-49e8-89bf-3dd66dac69db");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3389c9d2-0835-47a7-846f-258a00182a1d", "bcc2dfed-07c8-40ef-a859-a8ec736d3a70" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3389c9d2-0835-47a7-846f-258a00182a1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcc2dfed-07c8-40ef-a859-a8ec736d3a70");

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Request_TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Request_DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Request_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Request_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Request_EmailAdd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Request_TeamSelect = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Request_TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Request_TaskId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b8e92c7-6cd0-4f24-b53e-c2b6a110a67d", null, "Employee", "EMPLOYEE" },
                    { "3389c9d2-0835-47a7-846f-258a00182a1d", null, "Administrator", "ADMINISTRATOR" },
                    { "833fc580-1c54-49e8-89bf-3dd66dac69db", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcc2dfed-07c8-40ef-a859-a8ec736d3a70", 0, "cdc1f34b-2f5d-4d19-a61f-6ce3969171f6", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAECjc/XQxth+sOTwS4VnzWBpZuLVjWP8vMiQNr2iu8aRWwjuGg+zXrHT7Q32OLcxu1Q==", null, false, "79c38758-e339-4beb-9eb8-43a76e1a12cd", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3389c9d2-0835-47a7-846f-258a00182a1d", "bcc2dfed-07c8-40ef-a859-a8ec736d3a70" });
        }
    }
}
