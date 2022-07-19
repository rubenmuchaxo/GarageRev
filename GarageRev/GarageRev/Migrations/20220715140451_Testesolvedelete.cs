using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Migrations {
    public partial class Testesolvedelete : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "f20021fd-fcc3-4e35-b88a-23e88dcbeb1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "008f87d1-a20f-42b2-aa4a-afe1e6370f9f");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "2552283f-9dba-430f-a795-98ea5946820f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "a2d23442-8213-4608-b0df-9c2ddaab69e6");
        }
    }
}
