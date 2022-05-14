using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddUserProjectRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"),
                column: "ManagerId",
                value: "4f555f12-9168-49b1-9f17-b87904564904");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ManagerId",
                table: "Projects",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ManagerId",
                table: "Projects",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ManagerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Projects");

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
    }
}
