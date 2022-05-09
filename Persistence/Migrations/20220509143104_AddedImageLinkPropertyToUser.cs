using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedImageLinkPropertyToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "f36e9826-53a2-4ec5-ac9b-80f0cb0a301c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "fc83cd54-fbd0-454c-8e61-9e940b2ed9c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d8909ba-a2b8-4938-84ec-1411b926c1c1", "AQAAAAEAACcQAAAAEGEe+RAua9F6W9GyvvPzf0ElrLNdL/pdzE19eup9cf/dAdzJZuK3tNzpA0JdyJ+gGg==", "939549bf-44df-4074-af68-650252d0831e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8117f36-7699-442b-a43d-64197e5fb10a", "AQAAAAEAACcQAAAAEJvIaj/oV5hNFcwSWwrPJnBmhWKmKPY2ck4SZP/rzN59rzFz9L+wfTuBpC5FY8J/5g==", "75191382-8d48-4527-83ad-a378b094eec7" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 25, 14, 31, 2, 213, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 25, 14, 31, 2, 213, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 23, 14, 31, 2, 213, DateTimeKind.Utc).AddTicks(4622));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "AspNetUsers");

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
    }
}
