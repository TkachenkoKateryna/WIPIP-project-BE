using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdatedMilestoneEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Milestones",
                newName: "DueDate");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "d23b248a-7f12-47a0-b2b1-90caa88d0c31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "36bf2f12-ff68-4139-a522-a955981fcf3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc009572-51ef-403c-9416-1f1316f14ec7", "AQAAAAEAACcQAAAAEEugh41FD3avVDMFUtcf7d9DzTXSWrQKRr662DVkCnohVcbDTWO7xe0lFUVlwwFs4Q==", "ef95f462-9d49-40cc-997c-0f7abd193e84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74bcb380-3c46-4904-86f3-3d26b4b8393b", "AQAAAAEAACcQAAAAELbg3kPAdjGjRDPgPL3OfQvJ7hs7H5xy0G0KpCdqXwCjnYpW7nN4sxPSdi761B6w7g==", "47973fb2-6984-4ecc-8ee9-4b320cc46984" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 22, 14, 52, 51, 747, DateTimeKind.Utc).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 22, 14, 52, 51, 747, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 20, 14, 52, 51, 747, DateTimeKind.Utc).AddTicks(7795));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Milestones",
                newName: "DateTime");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "c671688a-7e47-4178-840e-79b39afd46c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "4069de0d-fc3d-4b47-9a42-096a755b8ecc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc14fbbd-7b3a-4142-b575-fe00d6c3d2a7", "AQAAAAEAACcQAAAAEN9GrVc9q74msu1HFRHqgqwaZuo4sQsvkcDMYlQbOyXeDsTwDO2Us28V4Sp5k1svAw==", "623a7179-822d-42c5-b609-d030e7778060" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50c1b518-d9da-4d30-a678-b9b6e9faeaf7", "AQAAAAEAACcQAAAAEMG7iCLXyL9oonB/v+NyfpcSQ4X7VRJFiWNjTsPTaSlsGcaiclZ9YPJKo7B58SWRNQ==", "865c49c3-3524-4d11-9790-82d0a2b814f1" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 22, 13, 2, 26, 687, DateTimeKind.Utc).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 22, 13, 2, 26, 687, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 20, 13, 2, 26, 687, DateTimeKind.Utc).AddTicks(6563));
        }
    }
}
