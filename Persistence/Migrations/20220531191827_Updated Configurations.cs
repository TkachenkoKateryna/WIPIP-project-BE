using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdatedConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStakeholders",
                table: "ProjectStakeholders");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRisks_ProjectId",
                table: "ProjectRisks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stakeholders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Stakeholders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Activity",
                table: "Milestones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Deliverables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assumptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProjectStakeholders_ProjectId_StakeholderId",
                table: "ProjectStakeholders",
                columns: new[] { "ProjectId", "StakeholderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStakeholders",
                table: "ProjectStakeholders",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProjectRisks_ProjectId_RiskId",
                table: "ProjectRisks",
                columns: new[] { "ProjectId", "RiskId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_EmployeeSkills_EmployeeId_SkillId",
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "5a7a40ed-a80e-4757-a880-e0deae9e8c05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "ab559085-0da4-402c-b953-7e006184219b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "541595b7-bccd-45f3-9a13-f412c9de6b01", "AQAAAAEAACcQAAAAELDieJW+u8iu9k6KjQDMYgsRpmCNs8TQRbYKVhpPyA1uS9AVud7xHASNKD5B2LaSQQ==", "0317882e-cfb6-4676-a65b-eeff0c28567d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "404c51f8-2171-4e55-a09a-233d6a8cb174", "AQAAAAEAACcQAAAAEKQSeUpgAl585jmf/QVb6h83zWVSPaP5WZt8mhBxIwtkhp0JBVErs9qN399xIXuWdg==", "7bfcb299-1335-4f2c-8ca9-46907b99f658" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 17, 19, 18, 25, 866, DateTimeKind.Utc).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 17, 19, 18, 25, 866, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 14, 19, 18, 25, 866, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("51f67073-ea0d-4163-bc41-232216202152"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("cbd8a2e4-8a49-4e5f-8f7f-84e12f812b9e"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("d39437ed-a986-4d8e-8fe5-ca62722fc4ee"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("ffde9e00-0166-4114-8f81-5cfece9989ac"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") }
                });

            migrationBuilder.UpdateData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: new Guid("137edc09-5547-4eb0-8b60-ab4608cae052"),
                column: "Title",
                value: "Number of websites clients");

            migrationBuilder.UpdateData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: new Guid("68bf002d-69f8-4d6d-8f15-6da8483767a2"),
                column: "Title",
                value: "Number of websites users");

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("14e6c1c3-1601-446a-a31d-b8ad03b7953b"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("3036ed00-4ba9-42b7-a6e7-c0d39d828a49"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") },
                    { new Guid("859f268e-b9fd-48cf-9212-443a1bcaf387"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("e550fe27-cd76-4ab0-9990-eee12879817b"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProjectStakeholders_ProjectId_StakeholderId",
                table: "ProjectStakeholders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStakeholders",
                table: "ProjectStakeholders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProjectRisks_ProjectId_RiskId",
                table: "ProjectRisks");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_EmployeeSkills_EmployeeId_SkillId",
                table: "EmployeeSkills");

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("51f67073-ea0d-4163-bc41-232216202152"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("cbd8a2e4-8a49-4e5f-8f7f-84e12f812b9e"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("d39437ed-a986-4d8e-8fe5-ca62722fc4ee"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("ffde9e00-0166-4114-8f81-5cfece9989ac"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("14e6c1c3-1601-446a-a31d-b8ad03b7953b"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("3036ed00-4ba9-42b7-a6e7-c0d39d828a49"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("859f268e-b9fd-48cf-9212-443a1bcaf387"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("e550fe27-cd76-4ab0-9990-eee12879817b"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stakeholders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Stakeholders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Activity",
                table: "Milestones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Deliverables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assumptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.UpdateData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: new Guid("137edc09-5547-4eb0-8b60-ab4608cae052"),
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: new Guid("68bf002d-69f8-4d6d-8f15-6da8483767a2"),
                column: "Title",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRisks_ProjectId",
                table: "ProjectRisks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId");
        }
    }
}
