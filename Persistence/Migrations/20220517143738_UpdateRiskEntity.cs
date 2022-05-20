using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateRiskEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("1b11d8bf-e7ea-4266-a52c-184d195cc191"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("30682b1d-9cdd-418a-bf96-0c229c7d065b"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("3b0c2bc9-67be-4ee5-87c3-e60ed51627c8"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("5e25ce9e-dd1b-4442-a5a5-2343c946cb1e"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("35a72c63-6bcd-4e70-9cfa-c842e75610fa"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("c7d58e8e-8163-44ae-ad83-e2571cc86d1a"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("da1a698f-878a-4236-836a-1a998fd1593b"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("fcb3dd07-432c-4f75-9a77-534dc6c71753"));

            migrationBuilder.AddColumn<string>(
                name: "Consequence",
                table: "Risks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Risks",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Consequence",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Risks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "9b3e2698-2c54-4de8-aaf1-07cf82a15220");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "885d5ef2-cd08-4885-86ca-143a8d31109f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f575f51f-eb3b-49c1-9e2e-c09d24c7c8b8", "AQAAAAEAACcQAAAAEDQlM4yslhUgrxHFlz3+mXI9TtAkuCjoMyffd1puG+x9GdvzpdrVkQyXhoufAkU02w==", "f26470fa-fcf7-4d15-9635-104c15313388" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdef6c50-9dd2-42ca-9933-30402edcf443", "AQAAAAEAACcQAAAAEK1sTd8iwNT5RVZXv1oNFnRI3Mm/h04ZcB9HnsCgwyMDAwU1HZaGN4SVE0VrtDoRqw==", "63c5005d-5521-4609-ac45-b879d317efd9" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 2, 10, 3, 25, 762, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 2, 10, 3, 25, 762, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 30, 10, 3, 25, 762, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("1b11d8bf-e7ea-4266-a52c-184d195cc191"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("30682b1d-9cdd-418a-bf96-0c229c7d065b"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("3b0c2bc9-67be-4ee5-87c3-e60ed51627c8"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("5e25ce9e-dd1b-4442-a5a5-2343c946cb1e"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("35a72c63-6bcd-4e70-9cfa-c842e75610fa"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("c7d58e8e-8163-44ae-ad83-e2571cc86d1a"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") },
                    { new Guid("da1a698f-878a-4236-836a-1a998fd1593b"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") },
                    { new Guid("fcb3dd07-432c-4f75-9a77-534dc6c71753"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") }
                });
        }
    }
}
