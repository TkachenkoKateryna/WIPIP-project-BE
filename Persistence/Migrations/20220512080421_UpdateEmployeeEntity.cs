using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateEmployeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "acb45860-2477-456c-96a6-eb0757770f87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "20f676cf-4372-4ddb-9ade-65e2e497adc3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70dffec9-7012-42dd-832a-75d3fea6a873", "AQAAAAEAACcQAAAAED7KhF2vac5JNM4KSK6CDBMyPgGEyZQ+Tz2aym9VeKMtPy7ktnRF3vC3ULSl2eyc4A==", "69f4a74c-6525-4062-9d1e-ec26e2f498d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f65f5bc9-bf46-4232-93fc-66c6afe4f67b", "AQAAAAEAACcQAAAAEM3ova66XRd4/JWVbOlijC1silm4fGcmALUzLfRy/wCKNQlFvNw76HbdhATetQMQeQ==", "b9ddac0d-bc97-4452-816e-0f66c043164e" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 28, 8, 4, 20, 583, DateTimeKind.Utc).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 28, 8, 4, 20, 583, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 26, 8, 4, 20, 583, DateTimeKind.Utc).AddTicks(9148));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Employees");

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
    }
}
