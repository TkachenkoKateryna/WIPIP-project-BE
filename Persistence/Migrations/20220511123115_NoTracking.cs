using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class NoTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "3e1de645-d6dd-49f6-9283-4e15bafb8fd7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "99822b81-0337-4949-a337-d8c830c7ed77");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f28534b-42fc-44cd-b67d-c0b7662fae59", "AQAAAAEAACcQAAAAEG968wbNEEdaiDO8ikXNWWSmbJRqZ0m+V0tbDfJneRd7TkxA2o9t1frYHHfz2HZq7w==", "b2a00f76-70e1-48e8-84c6-d8c8e3f1acac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "412174f8-d672-45e4-8fb3-cd2f420d10e5", "AQAAAAEAACcQAAAAEN29DsRP+JcSMDCIKjfgdBMzOzDEHD4LdHr0JA5mFeN0bPVWiD37CIepGX0C1MJ+tg==", "45bbc867-48e2-4a76-865f-7871ca9674d5" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 27, 12, 31, 14, 45, DateTimeKind.Utc).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 27, 12, 31, 14, 45, DateTimeKind.Utc).AddTicks(3419));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 25, 12, 31, 14, 45, DateTimeKind.Utc).AddTicks(3400));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "2df16128-e338-44ed-88f4-2aed31fa1d46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "5e151fa5-f09b-44b4-82d3-745b1ffd2a37");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9f55f8f-8707-4c51-8a22-8abc7f9eab9d", "AQAAAAEAACcQAAAAEJxj0FVfhIlmPFp9syCVhA3VUiSiiDGNasu218meNZj3hrfBfVKq296QoLE1KRHGJw==", "d82e55d3-a6f8-4686-9aa7-7c3237f15595" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b053bfd0-7310-453d-b4c8-1504d2865932", "AQAAAAEAACcQAAAAEG7CTgwn308ns9ciCYbeuIuB1iWOxMTa1q2S8kvprJ4Z/U82THXKy89cH7DuPigcgQ==", "6d7c804e-71d8-4e5a-89a5-b662594fef75" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 25, 18, 42, 30, 701, DateTimeKind.Utc).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 25, 18, 42, 30, 701, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 23, 18, 42, 30, 701, DateTimeKind.Utc).AddTicks(1501));
        }
    }
}
