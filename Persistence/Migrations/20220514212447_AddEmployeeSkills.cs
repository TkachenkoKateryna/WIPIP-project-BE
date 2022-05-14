using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddEmployeeSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Employees",
                columns: new[] { "Id", "DFD", "DOB", "Email", "EnglishLevel", "ImageLink", "IsDeleted", "Name", "Phone", "Specialization" },
                values: new object[,]
                {
                    { new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"), new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sveta@gmail.com", 2, null, false, "Sveta", "0996522147", null },
                    { new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"), new DateTime(2021, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "yura@gmail.com", 2, null, false, "Yura", "0996844525", null },
                    { new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"), new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "kate@gmail.com", 2, null, false, "Kate", "0996522354", null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31"), false, "React" },
                    { new Guid("be8ea9f3-640a-4079-a576-17836c78c82b"), false, "Redux" },
                    { new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c"), false, "C#" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1178ff11-3f8f-49d8-90bf-28090ea5c4fc"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("39ca7391-d752-402e-8ef6-0b255ebefa7f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("db366b85-04ef-4e28-9ef3-24a0174159f3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3b87c66f-9fd8-4ec6-8b36-f49e3f210e31"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("be8ea9f3-640a-4079-a576-17836c78c82b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e69515d6-7b4a-48f1-96f1-a431d4db9c6c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "fb13953b-9091-41dc-bf7e-63a832bfdb52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "dca7963c-e924-493e-83f6-79142e490d07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa8f5457-9fc2-490b-9c9d-66dd3209f0f0", "AQAAAAEAACcQAAAAEMBsa17ERxL7n7AlhkxXNT+frNV7x9/fV+jtyqsINg1EilSJ4gF0LtvtMdmbcCiaKw==", "d39c282b-8b48-4207-b1eb-09b38d5c4ef4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd4a8e89-eb17-48ac-ac70-f18c17623c32", "AQAAAAEAACcQAAAAEJwrb67eoUsJTZdwkZs0Nb1DSmtM9BPJAJHpd2O3Gq0bkaW/U24Z+1AQtUQA8+ijYA==", "71892543-6996-4c30-a003-d03d33ad4237" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 30, 20, 37, 40, 804, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 11, 30, 20, 37, 40, 804, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                column: "TimeOfComplition",
                value: new DateTime(2022, 5, 28, 20, 37, 40, 804, DateTimeKind.Utc).AddTicks(7018));
        }
    }
}
