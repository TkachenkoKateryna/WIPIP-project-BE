using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedObjectivesMilestonsAssumptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "2df16128-e338-44ed-88f4-2aed31fa1d46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "5e151fa5-f09b-44b4-82d3-745b1ffd2a37");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9f55f8f-8707-4c51-8a22-8abc7f9eab9d", "AQAAAAEAACcQAAAAEJxj0FVfhIlmPFp9syCVhA3VUiSiiDGNasu218meNZj3hrfBfVKq296QoLE1KRHGJw==", "d82e55d3-a6f8-4686-9aa7-7c3237f15595" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b053bfd0-7310-453d-b4c8-1504d2865932", "AQAAAAEAACcQAAAAEG7CTgwn308ns9ciCYbeuIuB1iWOxMTa1q2S8kvprJ4Z/U82THXKy89cH7DuPigcgQ==", "6d7c804e-71d8-4e5a-89a5-b662594fef75" });

            migrationBuilder.InsertData(
                table: "Assumptions",
                columns: new[] { "Id", "Description", "IsDeleted", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("1c7ba364-c16a-454b-a325-a88af2c0640e"), "End users will be available to test during the time they agree to.", false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f") },
                    { new Guid("7aeb7618-859a-4fb8-841d-de44920b7a1a"), "Project will follow agile methodology throughout execution.", false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f") }
                });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                columns: new[] { "Description", "TimeOfComplition", "Title" },
                values: new object[] { "Desktop Application with full functionality described in documentation.", new DateTime(2022, 11, 25, 18, 42, 30, 701, DateTimeKind.Utc).AddTicks(1517), "Desktop Application." });

            migrationBuilder.InsertData(
                table: "Milestones",
                columns: new[] { "Id", "Activity", "DueDate", "IsDeleted", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("e1969bcb-49eb-4d16-9d9e-50bd016516df"), "Project documentation approved", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f") },
                    { new Guid("f05dce1f-ba10-46a8-9266-9bdc8335520a"), "Web version release", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f") }
                });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Description", "IsDeleted", "Priority", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("137edc09-5547-4eb0-8b60-ab4608cae052"), "Increase the number of clients to 5 in first month", false, 0, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), null },
                    { new Guid("68bf002d-69f8-4d6d-8f15-6da8483767a2"), "Increase the number of website users to 100 in first three month", false, 1, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), null }
                });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                columns: new[] { "Description", "MilestoneId", "TimeOfComplition", "Title" },
                values: new object[] { "Web Application with full functionality described in documentation.", new Guid("f05dce1f-ba10-46a8-9266-9bdc8335520a"), new DateTime(2022, 11, 25, 18, 42, 30, 701, DateTimeKind.Utc).AddTicks(1514), "Web application" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                columns: new[] { "Description", "MilestoneId", "TimeOfComplition", "Title" },
                values: new object[] { "Detailed description of project activities and their delivery process.", new Guid("e1969bcb-49eb-4d16-9d9e-50bd016516df"), new DateTime(2022, 5, 23, 18, 42, 30, 701, DateTimeKind.Utc).AddTicks(1501), "Project Plan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assumptions",
                keyColumn: "Id",
                keyValue: new Guid("1c7ba364-c16a-454b-a325-a88af2c0640e"));

            migrationBuilder.DeleteData(
                table: "Assumptions",
                keyColumn: "Id",
                keyValue: new Guid("7aeb7618-859a-4fb8-841d-de44920b7a1a"));

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: new Guid("e1969bcb-49eb-4d16-9d9e-50bd016516df"));

            migrationBuilder.DeleteData(
                table: "Milestones",
                keyColumn: "Id",
                keyValue: new Guid("f05dce1f-ba10-46a8-9266-9bdc8335520a"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: new Guid("137edc09-5547-4eb0-8b60-ab4608cae052"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: new Guid("68bf002d-69f8-4d6d-8f15-6da8483767a2"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "f36e9826-53a2-4ec5-ac9b-80f0cb0a301c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "fc83cd54-fbd0-454c-8e61-9e940b2ed9c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d8909ba-a2b8-4938-84ec-1411b926c1c1", "AQAAAAEAACcQAAAAEGEe+RAua9F6W9GyvvPzf0ElrLNdL/pdzE19eup9cf/dAdzJZuK3tNzpA0JdyJ+gGg==", "939549bf-44df-4074-af68-650252d0831e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8117f36-7699-442b-a43d-64197e5fb10a", "AQAAAAEAACcQAAAAEJvIaj/oV5hNFcwSWwrPJnBmhWKmKPY2ck4SZP/rzN59rzFz9L+wfTuBpC5FY8J/5g==", "75191382-8d48-4527-83ad-a378b094eec7" });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("657981a2-355e-4e26-a5c9-2b585cd4d8a4"),
                columns: new[] { "Description", "TimeOfComplition", "Title" },
                values: new object[] { "Desktop Application.", new DateTime(2022, 11, 25, 14, 31, 2, 213, DateTimeKind.Utc).AddTicks(4650), null });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("edd2bd33-fb25-40ec-98ed-48b0adb4be7a"),
                columns: new[] { "Description", "MilestoneId", "TimeOfComplition", "Title" },
                values: new object[] { "Web application.", null, new DateTime(2022, 11, 25, 14, 31, 2, 213, DateTimeKind.Utc).AddTicks(4645), null });

            migrationBuilder.UpdateData(
                table: "Deliverables",
                keyColumn: "Id",
                keyValue: new Guid("f454ef57-8b35-499b-801a-fdf733c88a5f"),
                columns: new[] { "Description", "MilestoneId", "TimeOfComplition", "Title" },
                values: new object[] { "Project Plan.", null, new DateTime(2022, 5, 23, 14, 31, 2, 213, DateTimeKind.Utc).AddTicks(4622), null });
        }
    }
}
