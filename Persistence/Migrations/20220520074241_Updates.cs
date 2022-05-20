using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("68da3154-e4c8-4ce3-bd93-63d42e4853bc"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("719ed7ed-a2f2-4030-8008-9d1e66fdcc4c"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("a4744d6b-e719-4ac1-89ca-1b9f190c0b57"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("fc95814e-3140-41c5-ac91-a4158c338aa5"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("14d0e90f-c2e3-4f57-a262-35d290de9702"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("21089783-edbb-48bc-95cd-9e32dcea97e8"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("4e24f76a-46f5-4d97-ad7e-ce10e87cdc04"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("538cb3a3-e5b9-477c-b2cf-0e3de2e4a8ed"));

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "8ab8f538-2744-4883-b88b-ef6822906c78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "b093a033-787a-41a8-af73-f52ab481e468");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46b9d07a-27c5-4eb8-a369-83858f0c781f", "AQAAAAEAACcQAAAAELbDSafjtpOHF1Vahdhx3gYgeBFxSZS6s8vDO4RNl0AstDoc2OFzruSYC9pNgupJig==", "e4d5f651-e304-4bcc-aca7-22d203a545ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25cace2f-ecd7-4e5d-85bb-0f4395cf320d", "AQAAAAEAACcQAAAAEFJxFQJdXRAtfwvKoXM2vOvL7+tp/QPMpWLy1UyltP8VfuKkVyI/YzK2B0LBy3Zufg==", "3d1986ad-0eca-439e-8ed1-88752092afb5" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 6, 7, 42, 40, 654, DateTimeKind.Utc).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 6, 7, 42, 40, 654, DateTimeKind.Utc).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 3, 7, 42, 40, 654, DateTimeKind.Utc).AddTicks(9097));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("9cf294a8-3902-4717-b141-a22a484e2b61"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("aa3f402b-f2e4-441d-8651-fe47dd94722e"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("ee90f28f-2741-4337-8a0a-cab3daf32e5f"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("fc5f5159-c361-4976-ba31-e9bf2f83658c"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("16a4000e-8a06-4ce1-a65f-3e475349a0a5"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("5a51b6c3-77cd-4dc4-8b1a-997bc8378187"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") },
                    { new Guid("8b6dee4d-8f76-4a1c-ad4e-481650551cb3"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("a7aa96e7-e047-40f2-bbdf-cf8a53bb2976"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("9cf294a8-3902-4717-b141-a22a484e2b61"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("aa3f402b-f2e4-441d-8651-fe47dd94722e"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("ee90f28f-2741-4337-8a0a-cab3daf32e5f"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("fc5f5159-c361-4976-ba31-e9bf2f83658c"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("16a4000e-8a06-4ce1-a65f-3e475349a0a5"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("5a51b6c3-77cd-4dc4-8b1a-997bc8378187"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("8b6dee4d-8f76-4a1c-ad4e-481650551cb3"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("a7aa96e7-e047-40f2-bbdf-cf8a53bb2976"));

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
                value: "0096745c-8841-43dd-867a-30d7232f14e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "e722bcd1-468e-4245-bb59-d6771f233351");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "146e30d6-30b4-4994-872b-6039c4c5769e", "AQAAAAEAACcQAAAAELALuxTKCofj56cAQM5fwgExjUEcJ1oNFT5cNc8pZ2AqHhLbRKkMeiQH/91nPP8OuA==", "15c3630d-dd60-4e8d-ae0c-c0c61ca2981b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc4e1a09-fd8c-40f5-a566-5715f2e662cf", "AQAAAAEAACcQAAAAEISLyerILC19gcC3erhemg8UnMgSieZF6vSrfgtSIx/MjgNYaDgx3iiNRCM0TBVzfQ==", "86063780-b657-4e7c-9906-f7a1ec67f336" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 3, 15, 31, 28, 266, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 3, 15, 31, 28, 266, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 31, 15, 31, 28, 266, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("68da3154-e4c8-4ce3-bd93-63d42e4853bc"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("719ed7ed-a2f2-4030-8008-9d1e66fdcc4c"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("a4744d6b-e719-4ac1-89ca-1b9f190c0b57"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("fc95814e-3140-41c5-ac91-a4158c338aa5"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("14d0e90f-c2e3-4f57-a262-35d290de9702"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("21089783-edbb-48bc-95cd-9e32dcea97e8"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") },
                    { new Guid("4e24f76a-46f5-4d97-ad7e-ce10e87cdc04"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("538cb3a3-e5b9-477c-b2cf-0e3de2e4a8ed"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") }
                });
        }
    }
}
