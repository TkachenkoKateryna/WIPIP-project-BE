using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddRiskCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "fb13953b-9091-41dc-bf7e-63a832bfdb52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "dca7963c-e924-493e-83f6-79142e490d07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa8f5457-9fc2-490b-9c9d-66dd3209f0f0", "AQAAAAEAACcQAAAAEMBsa17ERxL7n7AlhkxXNT+frNV7x9/fV+jtyqsINg1EilSJ4gF0LtvtMdmbcCiaKw==", "d39c282b-8b48-4207-b1eb-09b38d5c4ef4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd4a8e89-eb17-48ac-ac70-f18c17623c32", "AQAAAAEAACcQAAAAEJwrb67eoUsJTZdwkZs0Nb1DSmtM9BPJAJHpd2O3Gq0bkaW/U24Z+1AQtUQA8+ijYA==", "71892543-6996-4c30-a003-d03d33ad4237" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 30, 20, 37, 40, 804, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 30, 20, 37, 40, 804, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 28, 20, 37, 40, 804, DateTimeKind.Utc).AddTicks(7018));

            migrationBuilder.InsertData(
                table: "RiskCategories",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("0124991d-1191-4914-afb7-02ab237dc2a6"), false, "Resource Risk" },
                    { new Guid("072d2488-b193-4322-8132-dac1a5741a19"), false, "Budget Risk" },
                    { new Guid("3c4d64e1-fac2-4cc4-87fd-0186bec6429a"), false, "Communications and Decision Making" },
                    { new Guid("6d464351-efef-43db-9113-0b2de42ef20d"), false, "Scope and Requirements Risk" },
                    { new Guid("6e11c76b-648a-4778-a11e-c21db56e7c52"), false, "Stakeholder Risk" },
                    { new Guid("73723c0a-935d-46f0-a580-d05d17c20fc6"), false, "Schedule Risk" },
                    { new Guid("77dbf4db-8b5c-4b5d-98e5-e8e4f9044713"), false, "Technical Solutions" },
                    { new Guid("94fd9fef-cbf0-4f34-a33c-dbb16b6b408f"), false, "Operational Risk" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("0124991d-1191-4914-afb7-02ab237dc2a6"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("072d2488-b193-4322-8132-dac1a5741a19"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c4d64e1-fac2-4cc4-87fd-0186bec6429a"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("6d464351-efef-43db-9113-0b2de42ef20d"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("6e11c76b-648a-4778-a11e-c21db56e7c52"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("73723c0a-935d-46f0-a580-d05d17c20fc6"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("77dbf4db-8b5c-4b5d-98e5-e8e4f9044713"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("94fd9fef-cbf0-4f34-a33c-dbb16b6b408f"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "387d98fb-8f0a-4728-94dd-c104d19ced01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "b06f54cb-50e0-4341-9cff-17051ebf883d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d319a2e-14de-43a0-8fca-bf0b18371f8a", "AQAAAAEAACcQAAAAEOGZzGHpOEDkPAF0GqmgYcjPZl6mnMyPDe8HV6Q8Px2YmcQgHuwfeAdjkOLEJb1zBQ==", "441d7945-3dc5-4ae0-b674-459a057a36e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "373bf7ad-1be5-4419-b737-357b56ed3c9e", "AQAAAAEAACcQAAAAENyM9ZwWax8n+azD/lltuZRS2lRDjRNW90lhGPemnhlLUGc4QBMynjXttmBUPFslEA==", "fdc241cf-471e-4672-a623-365cfdff968e" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 29, 7, 58, 4, 461, DateTimeKind.Utc).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 29, 7, 58, 4, 461, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 27, 7, 58, 4, 461, DateTimeKind.Utc).AddTicks(5591));
        }
    }
}
