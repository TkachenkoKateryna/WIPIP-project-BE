using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class IdentitySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09afe919-59ff-44b8-b656-c5e320c163a7", "36911024-6688-40f0-b2b5-3bff97226890", "Lead", "LEAD" },
                    { "967e08ad-b71e-46e8-8e80-ffdce9ab9e74", "8797d3af-0b0c-4801-a1da-df6a471c806b", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4f555f12-9168-49b1-9f17-b87904564904", 0, "8c61b837-d44b-482d-887d-7ee5f29bb22a", null, false, false, null, null, "JANE", "AQAAAAEAACcQAAAAELlYtQLuMPpA6Sydw13EsisM/Lhwa8/MLyz0995sDFt/pfWcKwLDwg0Xbdvu3FIH+Q==", null, false, "e25e4d1a-9e27-4c52-8258-632a5d5a53b0", false, "jabe" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "97cb39b3-781b-45d1-aa45-e6285209aee9", null, false, false, null, null, "BOB", "AQAAAAEAACcQAAAAEP9jlpayU0ykeNNtY0Oh+ViyfmAjy5klowa3YWmNJHLUVIXN6u3Q7bsin+/k8aJNUQ==", null, false, "a069aab9-f563-4499-a7ce-1a6ae617e98d", false, "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "967e08ad-b71e-46e8-8e80-ffdce9ab9e74", "4f555f12-9168-49b1-9f17-b87904564904" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "09afe919-59ff-44b8-b656-c5e320c163a7", "8e445865-a24d-4543-a6c6-9443d048cdb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "967e08ad-b71e-46e8-8e80-ffdce9ab9e74", "4f555f12-9168-49b1-9f17-b87904564904" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09afe919-59ff-44b8-b656-c5e320c163a7", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");
        }
    }
}
