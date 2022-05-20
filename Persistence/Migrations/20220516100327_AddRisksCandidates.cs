using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddRisksCandidates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("0fe39191-3525-4eae-a370-f90889f8ea38"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("4968a747-704b-4f35-ba0d-bc4437335b98"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("ae16f52a-7f6d-4499-b6d3-6d6ef80dc95d"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("e5fafb9d-fd32-4f7c-8efc-2cda225e7c2b"));

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "ProjectCandidates");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProjectCandidates",
                newName: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "ProjectCandidates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Proficiency",
                table: "ProjectCandidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                table: "ProjectCandidates",
                columns: new[] { "Id", "Comment", "EmployeeId", "EnglishLevel", "ExternalRate", "FTE", "InternalRate", "IsDeleted", "Proficiency", "ProjectId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("540d5334-8cf1-40ee-a88e-640b5e78dc2c"), null, null, 3, 45, 1.0, 30, false, 2, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("be1aa540-754b-4563-accb-b907fc1ae742"), null, null, 3, 45, 0.5, 30, false, 2, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("be8ea9f3-640a-4079-a576-17836c78c82b"), null, null, 3, 45, 0.5, 30, false, 2, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") }
                });

            migrationBuilder.InsertData(
                table: "Risks",
                columns: new[] { "Id", "Impact", "IsDeleted", "Likelihood", "Mitigation", "RiskCategoryId", "Title" },
                values: new object[,]
                {
                    { new Guid("24b91b47-9e30-4080-b386-dd708f959de9"), 3, false, 0, "Identify stakeholders, analyze power and influence and create a stakeholder engagement plan. Project Board to authorise the plan. Revisit the plan at regular intervals to check all stakeholders are managed.", new Guid("6e11c76b-648a-4778-a11e-c21db56e7c52"), "Stakeholder action delays project" },
                    { new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e"), 3, false, 0, "Write a communication plan. Identify stakeholders early and make sure they are considered in the communication plan. Use most appropriate channel of communication for audience", new Guid("3c4d64e1-fac2-4cc4-87fd-0186bec6429a"), "Lack of communication" },
                    { new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326"), 3, false, 0, "Attend project scheduling workshops.Document all assumptions made in planning and communicate to the project manager before project kick off.", new Guid("6d464351-efef-43db-9113-0b2de42ef20d"), "Unplanned work that must be accommodated" },
                    { new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39"), 3, false, 0, "Plan project team. Acknowledge problems to the HR team. Talk to other project managers whether their team members' fte is full.", new Guid("0124991d-1191-4914-afb7-02ab237dc2a6"), "Lack of resources" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "ProjectCandidates",
                keyColumn: "Id",
                keyValue: new Guid("540d5334-8cf1-40ee-a88e-640b5e78dc2c"));

            migrationBuilder.DeleteData(
                table: "ProjectCandidates",
                keyColumn: "Id",
                keyValue: new Guid("be1aa540-754b-4563-accb-b907fc1ae742"));

            migrationBuilder.DeleteData(
                table: "ProjectCandidates",
                keyColumn: "Id",
                keyValue: new Guid("be8ea9f3-640a-4079-a576-17836c78c82b"));

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

            migrationBuilder.DeleteData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("24b91b47-9e30-4080-b386-dd708f959de9"));

            migrationBuilder.DeleteData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e"));

            migrationBuilder.DeleteData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326"));

            migrationBuilder.DeleteData(
                table: "Risks",
                keyColumn: "Id",
                keyValue: new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39"));

            migrationBuilder.DropColumn(
                name: "Proficiency",
                table: "ProjectCandidates");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "ProjectCandidates",
                newName: "Title");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "ProjectCandidates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Experience",
                table: "ProjectCandidates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "ef92d0ec-31d2-4335-81c0-d06c0133ce15");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "f05ae9ac-c0c1-48b7-92ff-1345f3579b17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c68eead3-b81d-4a3f-9abb-e95217f854b1", "AQAAAAEAACcQAAAAEIKw4q8NFfs+s7piLWVvvNe+BDJfQ1mKEWhTATlI5haUqKKx0KVzhDhFmmKELatuWA==", "b928e32c-ad33-48ed-a186-7b6650801946" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f4b9c62-1c2b-4cdc-a89d-7ef5f1f57736", "AQAAAAEAACcQAAAAEDAk55P3OAXzs5w7i9vTF9ljnfx7AKifBAZD1NvsydUVUNc84mZ44ID35mxCHGxq4w==", "e717e8cf-e401-462c-ab35-678c33021d67" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 30, 21, 24, 45, 786, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 30, 21, 24, 45, 786, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 28, 21, 24, 45, 786, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("0fe39191-3525-4eae-a370-f90889f8ea38"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") },
                    { new Guid("4968a747-704b-4f35-ba0d-bc4437335b98"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("ae16f52a-7f6d-4499-b6d3-6d6ef80dc95d"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("e5fafb9d-fd32-4f7c-8efc-2cda225e7c2b"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") }
                });
        }
    }
}
