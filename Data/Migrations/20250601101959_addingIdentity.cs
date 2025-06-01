using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProjectAl1.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "bcc2dfed-07c8-40ef-a859-a8ec736d3a70", 0, "6698c39e-c112-4647-9ec0-1a2a0d4876df", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEOfAbaSx7tQ806QanUqplr2Ruvpko6PXwsx9UrmS+1hnQht/H3YeCBzFb798wqAqw==", null, false, "34c4f9e7-dd85-4ae7-b5ef-613a5bb287b4", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3389c9d2-0835-47a7-846f-258a00182a1d", "bcc2dfed-07c8-40ef-a859-a8ec736d3a70" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
