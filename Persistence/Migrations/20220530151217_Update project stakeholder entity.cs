using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Updateprojectstakeholderentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStakeholders",
                table: "ProjectStakeholders");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStakeholders_ProjectId",
                table: "ProjectStakeholders");

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("0bb982a1-8a45-4dd1-9661-14faeecd3449"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("10c7b88b-81f3-43a7-b963-9a21a9c50696"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("5c4f8c27-a3cf-4527-b12f-470fc7dfb526"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("b6aad4cc-9d7b-4cc1-8e79-ecdf0e87a5d8"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("22cdbd00-2b21-4736-ae94-b697642222fe"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("5c5f2d41-c7ce-4f71-888a-be097c7f8dd8"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("c72cdfb8-be5e-4201-aa8b-c9e72bcd3f04"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("f4ca66b4-f139-4c27-9749-86e30acaa73e"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStakeholders",
                table: "ProjectStakeholders",
                columns: new[] { "ProjectId", "StakeholderId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "0de0ec90-bceb-4cc3-ae5e-f5525c43b0f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "e7e3ddc8-c2cf-48ff-8e90-4497f0c0a0fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c22251d-5bc3-4ef0-a1e6-805e6a087a2d", "AQAAAAEAACcQAAAAEHI4TNbk0GiKRC2pOJVHyHFQeM8KBYrQgeDXJYn9sN4BAFGjq8DosniIUFukdRnLcQ==", "06de41f5-5c42-470e-bb6b-e6cb40e640b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c488dc9-8418-4a4f-a117-b08aaa807409", "AQAAAAEAACcQAAAAEOkCxHV5uy1smIvW/8k8+FakJaxi7X1Ly1c8OsZ2d7vcDQJKU0c9ZC4VNCyvslVgZg==", "c4b796aa-1cd8-4666-b67b-90c532e29e00" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 16, 15, 12, 16, 553, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 16, 15, 12, 16, 553, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 13, 15, 12, 16, 553, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("1d18e260-4738-4b9a-8cc5-5f0489a42391"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("27dcaac7-3985-449f-a5f7-90ec4f43a336"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("8fb744d7-e65c-4b48-8750-7cca337f3ff9"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("af5a8ab3-a515-46d7-a3a5-59bd2132972c"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("1959e8a6-05f7-4814-a6bf-1e5e47420803"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("1f05d04d-7e19-462f-bc43-66d70256a2e6"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") },
                    { new Guid("760945bb-9cf6-403e-921e-935340ecbbf9"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("b128a813-a8ec-42b9-8bb0-df4d023cf3b0"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStakeholders",
                table: "ProjectStakeholders");

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("1d18e260-4738-4b9a-8cc5-5f0489a42391"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("27dcaac7-3985-449f-a5f7-90ec4f43a336"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("8fb744d7-e65c-4b48-8750-7cca337f3ff9"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("af5a8ab3-a515-46d7-a3a5-59bd2132972c"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("1959e8a6-05f7-4814-a6bf-1e5e47420803"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("1f05d04d-7e19-462f-bc43-66d70256a2e6"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("760945bb-9cf6-403e-921e-935340ecbbf9"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("b128a813-a8ec-42b9-8bb0-df4d023cf3b0"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStakeholders",
                table: "ProjectStakeholders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "26341027-243e-43db-8371-e6af05fc59a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "3073fa77-3c8d-415b-ba1f-7cb127bf37bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7ab545e-6a02-4d61-b19e-27376d670c8d", "AQAAAAEAACcQAAAAEL63VpEyQ1SasQq3mo1yfUUwMzqMd4JFHmn8w/K2el0TzYUe08oWzTEkS60rzD5Nsw==", "f520a1e9-b5ec-44ca-8d24-3360723161fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72f25be9-665c-4775-ac37-c3ce3e4a0cc3", "AQAAAAEAACcQAAAAEBddeASuJuCLwXM5HejMzmjN2KiMheSz7EJd0oNPOrA5jFQoaWaqKd35y7Vzx8RZyw==", "f4ec37c5-dee0-4bd4-84b7-c89eb3596ecc" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 16, 8, 9, 38, 578, DateTimeKind.Utc).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 16, 8, 9, 38, 578, DateTimeKind.Utc).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 13, 8, 9, 38, 578, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("0bb982a1-8a45-4dd1-9661-14faeecd3449"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("10c7b88b-81f3-43a7-b963-9a21a9c50696"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("5c4f8c27-a3cf-4527-b12f-470fc7dfb526"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("b6aad4cc-9d7b-4cc1-8e79-ecdf0e87a5d8"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("22cdbd00-2b21-4736-ae94-b697642222fe"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("5c5f2d41-c7ce-4f71-888a-be097c7f8dd8"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") },
                    { new Guid("c72cdfb8-be5e-4201-aa8b-c9e72bcd3f04"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") },
                    { new Guid("f4ca66b4-f139-4c27-9749-86e30acaa73e"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStakeholders_ProjectId",
                table: "ProjectStakeholders",
                column: "ProjectId");
        }
    }
}
