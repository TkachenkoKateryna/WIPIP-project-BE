using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Updatestakeholderentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("2cffce8f-ad2f-4235-b273-4f209578f29b"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("4481beb1-2cb9-4677-ba5a-8766c53a5c24"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("8a5cf2bb-de42-4738-b05e-0d2035af93fc"));

            migrationBuilder.DeleteData(
                table: "EmployeeSkills",
                keyColumn: "Id",
                keyValue: new Guid("a85ce865-fa4c-41c7-a2f9-7fbc636f88ff"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("2fc719e1-e538-47f7-971f-e62f40c6ff8c"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("368b3dd0-d8cc-4235-925c-5500de3748bb"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("6a946a85-ab4d-4a36-9530-edb945ca5459"));

            migrationBuilder.DeleteData(
                table: "ProjectRisks",
                keyColumn: "Id",
                keyValue: new Guid("ffbed442-72ff-4891-885b-9ec05ccb3ad4"));

            migrationBuilder.RenameColumn(
                name: "Engagement",
                table: "Stakeholders",
                newName: "Role");

            migrationBuilder.AlterColumn<int>(
                name: "Payment",
                table: "Stakeholders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Class",
                table: "Stakeholders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Stakeholders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommunicationChannel",
                table: "Stakeholders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Stakeholders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Influence",
                table: "Stakeholders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Interest",
                table: "Stakeholders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Stakeholders",
                keyColumn: "Id",
                keyValue: new Guid("d0203d35-a1f3-4dda-bca6-f6da30177102"),
                columns: new[] { "Category", "CommunicationChannel", "Influence", "Interest", "Role" },
                values: new object[] { 1, 3, 1, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Stakeholders",
                keyColumn: "Id",
                keyValue: new Guid("d9b199e5-263e-4e59-bb38-9420f5acdfc0"),
                columns: new[] { "Category", "CommunicationChannel", "Influence" },
                values: new object[] { 1, 0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Stakeholders");

            migrationBuilder.DropColumn(
                name: "CommunicationChannel",
                table: "Stakeholders");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Stakeholders");

            migrationBuilder.DropColumn(
                name: "Influence",
                table: "Stakeholders");

            migrationBuilder.DropColumn(
                name: "Interest",
                table: "Stakeholders");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Stakeholders",
                newName: "Engagement");

            migrationBuilder.AlterColumn<int>(
                name: "Payment",
                table: "Stakeholders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Class",
                table: "Stakeholders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "d66358d4-a1b8-4e6e-82df-25fa55984155");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "a1c6b7ef-0e59-4471-bd98-67a44bb75293");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6af47292-611c-4c7e-999e-4d9ee73384a1", "AQAAAAEAACcQAAAAEF+0r55kLhFVnnoEuDVZymBlIE456z8UBFjLrMVtEpCKzSO3Zs79OfyMeIupmhhYYA==", "e6c5f693-3084-4979-a041-c99ada827287" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9318c0e-cb42-4193-bf07-fa905bf8ae42", "AQAAAAEAACcQAAAAEEN7kKgtbNeZ9CU497GMlfJiSPjrfX+zZ9OQzlrhWUC9iRyeQEHmL25leHvWkSPtmw==", "954ebcbf-90d9-409d-a708-c632a03cee8f" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 14, 9, 40, 18, 270, DateTimeKind.Utc).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 12, 14, 9, 40, 18, 270, DateTimeKind.Utc).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 6, 11, 9, 40, 18, 270, DateTimeKind.Utc).AddTicks(8689));

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "IsDeleted", "Primary", "Proficiency", "SkillId" },
                values: new object[,]
                {
                    { new Guid("2cffce8f-ad2f-4235-b273-4f209578f29b"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("be8ea9f3-640a-4079-a576-17836c78c82b") },
                    { new Guid("4481beb1-2cb9-4677-ba5a-8766c53a5c24"), new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), false, true, 3, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("8a5cf2bb-de42-4738-b05e-0d2035af93fc"), new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), false, true, 1, new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31") },
                    { new Guid("a85ce865-fa4c-41c7-a2f9-7fbc636f88ff"), new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), false, true, 2, new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c") }
                });

            migrationBuilder.InsertData(
                table: "ProjectRisks",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "RiskId" },
                values: new object[,]
                {
                    { new Guid("2fc719e1-e538-47f7-971f-e62f40c6ff8c"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("f31a73d2-d48b-4ac3-95e4-af8e4ec9be39") },
                    { new Guid("368b3dd0-d8cc-4235-925c-5500de3748bb"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d29a25cb-aa62-461e-baf9-2b382cfb5c1e") },
                    { new Guid("6a946a85-ab4d-4a36-9530-edb945ca5459"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("24b91b47-9e30-4080-b386-dd708f959de9") },
                    { new Guid("ffbed442-72ff-4891-885b-9ec05ccb3ad4"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d540c798-13ee-4eea-ba0b-01efa4b86326") }
                });

            migrationBuilder.UpdateData(
                table: "Stakeholders",
                keyColumn: "Id",
                keyValue: new Guid("d0203d35-a1f3-4dda-bca6-f6da30177102"),
                column: "Engagement",
                value: 1);
        }
    }
}
