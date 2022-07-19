using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Migrations
{
    public partial class fixnomesfotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "ba896104-9c30-46de-a399-06b6b7317977");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "ae1018fb-4c6f-413c-a7ea-fb076c7db515");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: "bmw_F40_Serie1_116i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: "bmw_F40_Serie1_118i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 7,
                column: "Foto",
                value: "bmw_F40_Serie1_128i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 8,
                column: "Foto",
                value: "bmw_F40_Serie1_m135i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 9,
                column: "Foto",
                value: "bmw_G02_X4_LCI.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 10,
                column: "Foto",
                value: "bmw_f44_Serie2_gran_Coupe_218i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 11,
                column: "Foto",
                value: "bmw_g21_serie3_touring_318i_auto.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 12,
                column: "Foto",
                value: "bmw_g23_serie4_cabrio.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 17,
                column: "Foto",
                value: "nissan_micra_k14.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 24,
                column: "Foto",
                value: "peugeot_508_II_sw.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 26,
                column: "Foto",
                value: "renault_clio_5.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: "bmw_F40 Serie 1_116i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: "bmw_F40 Serie 1_118i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 7,
                column: "Foto",
                value: "bmw_F40 Serie 1_128i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 8,
                column: "Foto",
                value: "bmw_F40 Serie 1_m135i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 9,
                column: "Foto",
                value: "bmw_G02_X4 LCI.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 10,
                column: "Foto",
                value: "bmw_f44 Serie2 gran Coupe_218i.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 11,
                column: "Foto",
                value: "bmw_g21 serie3 touring_318i auto.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 12,
                column: "Foto",
                value: "bmw g23 serie 4 cabrio.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 17,
                column: "Foto",
                value: "nissan_micra k14.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 24,
                column: "Foto",
                value: "peugeot_508 II sw.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 26,
                column: "Foto",
                value: "renault_clio 5.jpg");
        }
    }
}
