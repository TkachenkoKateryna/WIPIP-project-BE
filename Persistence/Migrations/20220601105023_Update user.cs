using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "967e08ad-b71e-46e8-8e80-ffdce9ab9e74", "4f555f12-9168-49b1-9f17-b87904564904" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09afe919-59ff-44b8-b656-c5e320c163a7", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("063122b5-110a-4539-ab05-e643b9b84522"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("1a80b174-b394-4245-995b-c14baec713af"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("67c98844-03a7-4671-aa44-f3d282c8c8bd"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("8d2612fb-c47c-47c9-bca7-8babc86686c3"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("7d025742-0927-48d1-9140-63272dbf2539"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("a3ba1107-4cf2-4d3e-80a9-4e894ce3fcd1"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("abd1abac-35db-4c01-b549-608caff07457"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("e97513d5-90be-4746-96d0-bc718d0b9a0a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09afe919-59ff-44b8-b656-c5e320c163a7", "b4751275-9a78-40e5-8db2-25f10a566ba1", "Role", "Lead", "LEAD" },
                    { "27a697ec-3ab1-4c03-9534-d3dd0d797fd6", "585d828e-6ead-4a3d-ab86-1b8e32e079d7", "Role", "Admin", "ADMIN" },
                    { "967e08ad-b71e-46e8-8e80-ffdce9ab9e74", "818feba6-2725-4b55-8684-6346d81dd579", "Role", "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 18, 10, 50, 21, 889, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 18, 10, 50, 21, 889, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 15, 10, 50, 21, 889, DateTimeKind.Utc).AddTicks(4561));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("4fac52cd-e383-46a4-9867-3da57615390b"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("51940fc5-f423-4d64-98ee-a550937b39fe"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("72e29ad7-00c1-41c4-b56d-0299a7afbc1c"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("cfceda83-a9ea-4757-a688-a8595ecc1049"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("4bd10284-a4d3-4ab5-93d2-d83a010d365f"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") },
                    { new Guid("60f7155d-538b-4dcb-af91-4b9b2c0fa313"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("732447e8-8c48-4733-89fc-9eddea6d53e0"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("dfac0c6f-cf83-4165-ace4-082dca449ee0"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "d17b5091-b38a-48f4-94e2-55cdce4d20a0", "jane@test.com", "AQAAAAEAACcQAAAAEMWVk+DRfrNCgQQT7bAwWsw7+/mAapzZ21pi9kqQTCnHn0Q73RtxwR3aAkUHuvLY1w==", "09afe919-59ff-44b8-b656-c5e320c163a7", "871e69f0-747b-4bf3-9add-858cb8481a06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "6964a661-e6bf-463d-8123-eaed80275735", "bob@test.com", "AQAAAAEAACcQAAAAECdXZRZ4PQGP8rBpvyXgpOPDPXejbkeJATrDsQfxWkoQPCKEhm+RltW4poZBjPz4sw==", "967e08ad-b71e-46e8-8e80-ffdce9ab9e74", "c526f89a-abc1-4f8c-8639-7dd4c54f1e6e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "251f0a6f-d01c-4eaa-a697-95cb183ff6a9", 0, "ad281e64-f656-4f9e-8a5d-13534802ee8c", "alla@test.com", false, null, false, null, "ALLA@TEST.COM", "ALLA", "AQAAAAEAACcQAAAAEEt2kZ2xQjnY71L3rABGxXVkGs8j9BuBbKsgsBvmyleTAL68L2z3ibzpDP3xccFHWQ==", null, false, "27a697ec-3ab1-4c03-9534-d3dd0d797fd6", "270f7df2-cc82-47ba-b203-45d1e1dc51a7", false, "alla" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "251f0a6f-d01c-4eaa-a697-95cb183ff6a9");

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("4fac52cd-e383-46a4-9867-3da57615390b"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("51940fc5-f423-4d64-98ee-a550937b39fe"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("72e29ad7-00c1-41c4-b56d-0299a7afbc1c"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("cfceda83-a9ea-4757-a688-a8595ecc1049"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("4bd10284-a4d3-4ab5-93d2-d83a010d365f"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("60f7155d-538b-4dcb-af91-4b9b2c0fa313"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("732447e8-8c48-4733-89fc-9eddea6d53e0"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("dfac0c6f-cf83-4165-ace4-082dca449ee0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a697ec-3ab1-4c03-9534-d3dd0d797fd6");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "eb422b23-a778-424a-92c7-ad5aa77ef566");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "1ba845df-3cd9-45c8-8827-d821d2147961");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "967e08ad-b71e-46e8-8e80-ffdce9ab9e74", "4f555f12-9168-49b1-9f17-b87904564904" },
                    { "09afe919-59ff-44b8-b656-c5e320c163a7", "8e445865-a24d-4543-a6c6-9443d048cdb9" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddd85f51-0066-40bc-89bf-66b732f63774", "jane@text.com", "AQAAAAEAACcQAAAAEO0VNu3hmeKQZgLK/5tEmhfrGHcASGfYTAR2RL/NT1z5eXZpy9QEGdIXIwp9EUEe9Q==", "9410e058-b88b-480e-b64f-6376a93abc79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "600a82e6-ba8b-4032-b733-e4ac5afbb1d0", "bob@text.com", "AQAAAAEAACcQAAAAEP4XsOa9K7kilorMMa3yuqU2nk6I/FL/Ln1LxcXgNyEahhA5NS76MmBs6/gC9ZBySw==", "7393b5e1-d68f-49e8-8837-92aad2d9d930" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 17, 20, 53, 23, 347, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 17, 20, 53, 23, 347, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 14, 20, 53, 23, 347, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("063122b5-110a-4539-ab05-e643b9b84522"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("1a80b174-b394-4245-995b-c14baec713af"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("67c98844-03a7-4671-aa44-f3d282c8c8bd"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("8d2612fb-c47c-47c9-bca7-8babc86686c3"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("7d025742-0927-48d1-9140-63272dbf2539"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") },
                    { new Guid("a3ba1107-4cf2-4d3e-80a9-4e894ce3fcd1"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("abd1abac-35db-4c01-b549-608caff07457"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") },
                    { new Guid("e97513d5-90be-4746-96d0-bc718d0b9a0a"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") }
                });
        }
    }
}
