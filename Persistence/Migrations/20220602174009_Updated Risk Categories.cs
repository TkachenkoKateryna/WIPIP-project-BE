using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdatedRiskCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "d1467058-646c-4c12-bca1-49b2b91b71cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a697ec-3ab1-4c03-9534-d3dd0d797fd6",
                column: "ConcurrencyStamp",
                value: "ebb4f4dd-049a-4ae0-a4cd-029e19296636");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "add7f5de-35f2-4668-8d2e-00c2cf422564");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "251f0a6f-d01c-4eaa-a697-95cb183ff6a9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67af8ccf-def0-4784-8315-22961a3cd77a", "AQAAAAEAACcQAAAAENG3TX5abPs9RUeBedqrjYj7Jn5YvaZWFS0Nu2385ZAngIPu85Jyr2/AmAGCbyrhyA==", "f55f61fe-51b7-4b12-b483-93c35b031d71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aedce570-4627-49a9-8a84-dd742c8076e7", "AQAAAAEAACcQAAAAEMhZ19snLgeY0WZ0LnG35vCF8Q+zMNoCcOgC7XeoaPogDz25VWpoLrntTl2J8bvGbw==", "b435b494-bce4-404a-9821-4f127e95a5a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d76c05c-0432-4c5e-aec7-6c003dbce90b", "AQAAAAEAACcQAAAAEDxLyvD3wbAaSb1fNVtZAvsdSOnfrhZN71tHc74mNxGN8ruKHR+unwDKyXJRgkXvEg==", "48787396-71a5-4693-b8a5-f2226e1d0ff0" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 19, 17, 40, 7, 3, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 19, 17, 40, 7, 3, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 16, 17, 40, 7, 3, DateTimeKind.Utc).AddTicks(1686));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("830c46c5-70bb-4bd3-90d2-e56504601375"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("e8685b4d-37af-44af-acef-8f422caff448"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("fa6785eb-39fa-4790-a2b6-79fda1bff722"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("fdc2c555-b044-48d5-9034-1ad1d4713ed5"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("34388264-24e5-40c2-8aca-442cc082ef6d"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("4693db10-3ed6-4806-85d5-f6e69104003a"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") },
                    { new Guid("73209919-773f-4d06-ab55-c9a7c3cbac73"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("fa97ca1d-3fc2-48e2-9694-3066d1e662c7"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") }
                });

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("0124991d-1191-4914-afb7-02ab237dc2a6"),
                column: "Title",
                value: "Resource Risks");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c4d64e1-fac2-4cc4-87fd-0186bec6429a"),
                column: "Title",
                value: "Communications Risks");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("6d464351-efef-43db-9113-0b2de42ef20d"),
                column: "Title",
                value: "Scope Risks");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("6e11c76b-648a-4778-a11e-c21db56e7c52"),
                column: "Title",
                value: "Stakeholder Risks");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("77dbf4db-8b5c-4b5d-98e5-e8e4f9044713"),
                column: "Title",
                value: "Payment Risks");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("94fd9fef-cbf0-4f34-a33c-dbb16b6b408f"),
                column: "Title",
                value: "Project goals Risks");

            migrationBuilder.InsertData(
                table: "RiskCategories",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[] { new Guid("8c23107a-01d6-488a-b48b-703598b73ef3"), false, "Assumptions Risks" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("830c46c5-70bb-4bd3-90d2-e56504601375"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("e8685b4d-37af-44af-acef-8f422caff448"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("fa6785eb-39fa-4790-a2b6-79fda1bff722"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("fdc2c555-b044-48d5-9034-1ad1d4713ed5"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("34388264-24e5-40c2-8aca-442cc082ef6d"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("4693db10-3ed6-4806-85d5-f6e69104003a"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("73209919-773f-4d06-ab55-c9a7c3cbac73"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("fa97ca1d-3fc2-48e2-9694-3066d1e662c7"));

            migrationBuilder.DeleteData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("8c23107a-01d6-488a-b48b-703598b73ef3"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "b4751275-9a78-40e5-8db2-25f10a566ba1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a697ec-3ab1-4c03-9534-d3dd0d797fd6",
                column: "ConcurrencyStamp",
                value: "585d828e-6ead-4a3d-ab86-1b8e32e079d7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "818feba6-2725-4b55-8684-6346d81dd579");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "251f0a6f-d01c-4eaa-a697-95cb183ff6a9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad281e64-f656-4f9e-8a5d-13534802ee8c", "AQAAAAEAACcQAAAAEEt2kZ2xQjnY71L3rABGxXVkGs8j9BuBbKsgsBvmyleTAL68L2z3ibzpDP3xccFHWQ==", "270f7df2-cc82-47ba-b203-45d1e1dc51a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d17b5091-b38a-48f4-94e2-55cdce4d20a0", "AQAAAAEAACcQAAAAEMWVk+DRfrNCgQQT7bAwWsw7+/mAapzZ21pi9kqQTCnHn0Q73RtxwR3aAkUHuvLY1w==", "871e69f0-747b-4bf3-9add-858cb8481a06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6964a661-e6bf-463d-8123-eaed80275735", "AQAAAAEAACcQAAAAECdXZRZ4PQGP8rBpvyXgpOPDPXejbkeJATrDsQfxWkoQPCKEhm+RltW4poZBjPz4sw==", "c526f89a-abc1-4f8c-8639-7dd4c54f1e6e" });

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
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("0124991d-1191-4914-afb7-02ab237dc2a6"),
                column: "Title",
                value: "Resource Risk");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c4d64e1-fac2-4cc4-87fd-0186bec6429a"),
                column: "Title",
                value: "Communications and Decision Making");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("6d464351-efef-43db-9113-0b2de42ef20d"),
                column: "Title",
                value: "Scope and Requirements Risk");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("6e11c76b-648a-4778-a11e-c21db56e7c52"),
                column: "Title",
                value: "Stakeholder Risk");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("77dbf4db-8b5c-4b5d-98e5-e8e4f9044713"),
                column: "Title",
                value: "Technical Solutions");

            migrationBuilder.UpdateData(
                table: "RiskCategories",
                keyColumn: "Id",
                keyValue: new Guid("94fd9fef-cbf0-4f34-a33c-dbb16b6b408f"),
                column: "Title",
                value: "Operational Risk");
        }
    }
}
