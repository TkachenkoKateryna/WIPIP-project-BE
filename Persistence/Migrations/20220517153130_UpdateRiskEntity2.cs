using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateRiskEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("28cd0dd0-5de1-4c1f-9685-e46fa4ae1764"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("c041ad67-f04e-4e00-8e28-d14664453c74"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("d194e43e-0e1d-4b65-a1ac-61e8f9c03ada"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("dff84296-70a3-4071-903c-18404ca9a48c"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("0d89c4cb-f48e-4584-bb83-bb51e6176c44"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("1c6512a1-3017-44d2-9b31-fe433deaaf17"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("68c64d92-3486-485b-8fbb-deab0c9dbbba"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("9e3e1604-0724-4478-be33-71f9377779cf"));

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Risks");

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

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("24b91b47-9e30-4080-b386-dd708f959de9"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 4, 1 });

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "210025c3-a098-420b-95bf-6a6ea78147ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "f35b9db7-c223-46b5-a604-c6c51b921795");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0336dce6-7b38-4df5-8a6c-229e6ca78257", "AQAAAAEAACcQAAAAEOY4DA9zDmG97yj3gI0UMZ4OQvqRVy3FCV9/sftaDhwm5DuTBWyklfbNcHw8NpXB6A==", "00a90bd6-4cbb-4ade-b4ff-182a5f0c3e6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ae35acf-2c6b-4582-a549-e18f4c0e7849", "AQAAAAEAACcQAAAAEJoVoz8z097buEp8gA7S4wqZEKqETRjfbcW3IiDtd9h7o0KwumWl4cKRFuzrgsU3mA==", "fdf9b3dc-1fd7-4967-af75-d2dfb07467c3" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 3, 14, 37, 36, 630, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 3, 14, 37, 36, 630, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 31, 14, 37, 36, 630, DateTimeKind.Utc).AddTicks(9103));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("28cd0dd0-5de1-4c1f-9685-e46fa4ae1764"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("c041ad67-f04e-4e00-8e28-d14664453c74"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("d194e43e-0e1d-4b65-a1ac-61e8f9c03ada"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("dff84296-70a3-4071-903c-18404ca9a48c"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("0d89c4cb-f48e-4584-bb83-bb51e6176c44"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") },
                    { new Guid("1c6512a1-3017-44d2-9b31-fe433deaaf17"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("68c64d92-3486-485b-8fbb-deab0c9dbbba"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("9e3e1604-0724-4478-be33-71f9377779cf"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") }
                });

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("24b91b47-9e30-4080-b386-dd708f959de9"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 3, 0 });

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 3, 0 });

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 3, 0 });

            migrationBuilder.UpdateData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39"),
                columns: new[] { "Impact", "Likelihood" },
                values: new object[] { 3, 0 });
        }
    }
}
