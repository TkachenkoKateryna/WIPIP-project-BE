using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class IdentitySeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "63d91dfe-9f1f-4dff-91e8-9487abd77115");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "7e3d4247-aadc-423c-a867-651923540359");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8e50d829-33c6-4af0-acba-92b6cc586d93", "jane@text.com", "AQAAAAEAACcQAAAAEN0Vdgx4n0dL9BiOI6qabOPb490U2va6wnwr2bc3rrLpEY5kOBFjcQfzcfen95/jbQ==", "092db806-4534-4a33-87d8-d8d4dcd04f08", "jane" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd2f90e1-ec84-4cd8-8e01-7ed3c5fb6225", "bob@text.com", "AQAAAAEAACcQAAAAEMtKM4fxtBDqo+hkN12/1YfAweHhOvJqFHJPNXnz1N4TO9ELw1KAYl9V2UJEbuK65Q==", "40d5761c-9ed4-49f1-af63-1050d594fef6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "36911024-6688-40f0-b2b5-3bff97226890");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "8797d3af-0b0c-4801-a1da-df6a471c806b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8c61b837-d44b-482d-887d-7ee5f29bb22a", null, "AQAAAAEAACcQAAAAELlYtQLuMPpA6Sydw13EsisM/Lhwa8/MLyz0995sDFt/pfWcKwLDwg0Xbdvu3FIH+Q==", "e25e4d1a-9e27-4c52-8258-632a5d5a53b0", "jabe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97cb39b3-781b-45d1-aa45-e6285209aee9", null, "AQAAAAEAACcQAAAAEP9jlpayU0ykeNNtY0Oh+ViyfmAjy5klowa3YWmNJHLUVIXN6u3Q7bsin+/k8aJNUQ==", "a069aab9-f563-4499-a7ce-1a6ae617e98d" });
        }
    }
}
