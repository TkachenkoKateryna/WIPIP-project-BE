using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddDeliverable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Deliverables",
                columns: new[] { "Id", "Description", "IsDeleted", "MilestoneId", "ProjectId", "TimeOfComplition", "Title" },
                values: new object[] { new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"), "Desktop Application.", false, null, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new DateTime(2022, 11, 22, 13, 2, 26, 687, DateTimeKind.Utc).AddTicks(6580), null });

            migrationBuilder.InsertData(
               table: "Deliverables",
               columns: new[] { "Id", "Description", "IsDeleted", "MilestoneId", "ProjectId", "TimeOfComplition", "Title" },
               values: new object[] { new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"), "Web Application.", false, null, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new DateTime(2022, 11, 22, 13, 2, 26, 687, DateTimeKind.Utc).AddTicks(6580), null });

            migrationBuilder.InsertData(
               table: "Deliverables",
               columns: new[] { "Id", "Description", "IsDeleted", "MilestoneId", "ProjectId", "TimeOfComplition", "Title" },
               values: new object[] { new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"), "Mobile Application.", false, null, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new DateTime(2022, 11, 22, 13, 2, 26, 687, DateTimeKind.Utc).AddTicks(6580), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"));

            migrationBuilder.DeleteData(
                    table: "Deliverables",
                    keyColumn: "Id",
                    keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"));

            migrationBuilder.DeleteData(
                    table: "Deliverables",
                    keyColumn: "Id",
                    keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"));

            migrationBuilder.UpdateData(
                    table: "AspNetRoles",
                    keyColumn: "Id",
                    keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                    column: "ConcurrencyStamp",
                    value: "9836f59f-1afc-4e2e-8c06-d404e1add102");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "ef86e5f6-3625-441e-9185-958d4d3dc9fb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a1f6255-f364-4981-bdbe-7117e8005960", "AQAAAAEAACcQAAAAEPI6Evsh4mBOsp+I+6h3IfufaU00CeB6+lbAdfWtu2fAeWKNY/aBQEIN2K7YeKC17w==", "1efa8050-5dda-4ce0-9e6c-10790b84f153" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3a5a31a-eb10-46dd-9c0d-5a3e2b21c9bd", "AQAAAAEAACcQAAAAEGlgvQi/9WBjlZ6XpstPDKR5gKuCyZ++LsqHhNFigYW+KaNrkV9R7hLAOoTii3w9zQ==", "bccfa99c-da30-49d4-9d6b-4689f1115586" });
        }
    }
}
