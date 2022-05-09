using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddForeignKeyNullforDeliverable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assumptions",
                keyColumn: "Id",
                keyValue: new Guid("4015cea3-66ad-4785-8920-411ca82f74f5"));

            migrationBuilder.DeleteData(
                table: "Assumptions",
                keyColumn: "Id",
                keyValue: new Guid("8ce94c91-3b5d-460a-82b3-64b067e7aff6"));

            migrationBuilder.DeleteData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("d8bb0809-08bc-4dfe-a89c-9577bb2ca1e0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MilestoneId",
                table: "Deliverables",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                columns: new[] { "MilestoneId", "TimeOfComplition" },
                values: new object[] { null, new DateTime(2022, 11, 22, 12, 59, 8, 484, DateTimeKind.Utc).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                columns: new[] { "MilestoneId", "TimeOfComplition" },
                values: new object[] { null, new DateTime(2022, 5, 20, 12, 59, 8, 484, DateTimeKind.Utc).AddTicks(9234) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MilestoneId",
                table: "Deliverables",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "adfc7857-cd3f-466e-bcc9-76783c95ee38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "e53bbe93-0084-4e71-a521-cdb91d83bc05");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "102bd020-60da-43fb-b634-8ab1b508b44a", "AQAAAAEAACcQAAAAELH0IwVWQ8AuWmZn60+q35FY/6gO2dX3+jgfG8qZxEsrqfF9GHA+NYMLHlA3LoOqJQ==", "ecf48c8f-0891-427b-8cc4-38c5d39491be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15bd996f-946e-4b97-a4d7-f87399802702", "AQAAAAEAACcQAAAAEF1SuiwpH/fvjRzG4/YoIZyOggiGR4s5vluk0qdBMccr5ufDl8cESQPTa3CQBork0w==", "a1556bc5-a69b-4ed2-8f01-aac4350e023e" });

            migrationBuilder.InsertData(
                table: "Assumptions",
                columns: new[] { "Id", "Description", "IsDeleted", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("4015cea3-66ad-4785-8920-411ca82f74f5"), "Project pilot phase will take 2 weeks.", false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f") },
                    { new Guid("8ce94c91-3b5d-460a-82b3-64b067e7aff6"), "Project architect may be partly taken to another project.", false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f") }
                });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                columns: new[] { "MilestoneId", "TimeOfComplition" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 11, 22, 12, 45, 49, 350, DateTimeKind.Utc).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                columns: new[] { "MilestoneId", "TimeOfComplition" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2022, 5, 20, 12, 45, 49, 350, DateTimeKind.Utc).AddTicks(9171) });

            migrationBuilder.InsertData(
                table: "Deliverables",
                columns: new[] { "Id", "Description", "IsDeleted", "MilestoneId", "ProjectId", "TimeOfComplition", "Title" },
                values: new object[] { new Guid("d8bb0809-08bc-4dfe-a89c-9577bb2ca1e0"), "IOS Mobile application.", false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}
