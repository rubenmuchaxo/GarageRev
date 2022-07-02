using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageRev.Data.Migrations
{
    public partial class addSeedCarros_fotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "1f0dd35b-925f-4333-b2d0-65334dbbaaac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "bb5458d1-13a7-4e3b-920d-3e1b9e3fbd69");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "bmw_i3_120ah.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "bmw_i3_s120ah.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "bmw_i4_M50.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "BMW_i4_eDrive40.jpg");

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
                value: "bmw_F44 Serie 2 gran Coupe_218i.jpg");

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
                keyValue: 13,
                column: "Foto",
                value: "ford_fiesta.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 14,
                column: "Foto",
                value: "honda_civic.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 15,
                column: "Foto",
                value: "mitsubishi_l200.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 16,
                column: "Foto",
                value: "Mitsubishi-Space-Star.jpeg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 17,
                column: "Foto",
                value: "nissan_micra k14.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 18,
                column: "Foto",
                value: "nissan-leaf.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 19,
                column: "Foto",
                value: "nissan_qashqai_J12.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 20,
                column: "Foto",
                value: "nissan_GTR_Nismo.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 21,
                column: "Foto",
                value: "nissan_r33_Skyline.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 22,
                column: "Foto",
                value: "opel_corsa_f.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 23,
                column: "Foto",
                value: "peugeot_108.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 24,
                column: "Foto",
                value: "peugeot_508 II sw.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 25,
                column: "Foto",
                value: "peugeot_208_facelift.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 26,
                column: "Foto",
                value: "renault_clio 5.jpg");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 27,
                column: "Foto",
                value: "ferrari_Laferrari_f70.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "0a46d422-abd9-4d20-aef3-4f64972434c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "89379715-95c9-4b0b-81a7-2a9075804d7c");

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 7,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 8,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 9,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 10,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 11,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 12,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 13,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 14,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 15,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 16,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 17,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 18,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 19,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 20,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 21,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 22,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 23,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 24,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 25,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 26,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Carros",
                keyColumn: "Id",
                keyValue: 27,
                column: "Foto",
                value: null);
        }
    }
}
