using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class SeedProjectStakeholderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "c4cb39ca-41b0-4e9b-9236-1ddc5f484ec8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "29a38b68-04e3-4090-b160-c9d5afa2213c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8e95f85-e09f-44a0-9b16-0dd425fa4eca", "AQAAAAEAACcQAAAAEA7l3T+r7aaTaX9mC3HTB8ni7J+oDBYUZeb+aKzyfl9VmxT9wPcQpLhhAF71siJA7A==", "8464b3f4-5c7f-4520-a662-7d52d6639089" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "734bf560-6ee7-4ff9-80cc-fb6b09612ce3", "AQAAAAEAACcQAAAAEPw4Kqr0LPtUWbfre+UVq328uru2V8ubs2bKhoP2ZMaGPve6+CvVdbHOZRt7uxUmrA==", "72a7f7d0-3289-444d-be34-69b27c0b78e2" });

            migrationBuilder.InsertData(
                table: "Stakeholders",
                columns: new[] { "Id", "Address", "Class", "Email", "Engagement", "IsDeleted", "Name", "Notes", "Payment" },
                values: new object[,]
                {
                    { new Guid("d0203d35-a1f3-4dda-bca6-f6da30177102"), "Miami, Florida 92A", 1, "gil@test.com", 1, false, "Gil Spencor", null, 1 },
                    { new Guid("d9b199e5-263e-4e59-bb38-9420f5acdfc0"), "Miami, Florida 92A", 0, "amanda@test.com", 0, false, "Amanda Froid", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectStakeholders",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "StakeholderId" },
                values: new object[] { new Guid("c32fee26-6fb9-4140-8354-db07140c6f28"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d0203d35-a1f3-4dda-bca6-f6da30177102") });

            migrationBuilder.InsertData(
                table: "ProjectStakeholders",
                columns: new[] { "Id", "IsDeleted", "ProjectId", "StakeholderId" },
                values: new object[] { new Guid("dddada16-713b-4a0c-a6e5-5462304f4a18"), false, new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), new Guid("d9b199e5-263e-4e59-bb38-9420f5acdfc0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectStakeholders",
                keyColumn: "Id",
                keyValue: new Guid("c32fee26-6fb9-4140-8354-db07140c6f28"));

            migrationBuilder.DeleteData(
                table: "ProjectStakeholders",
                keyColumn: "Id",
                keyValue: new Guid("dddada16-713b-4a0c-a6e5-5462304f4a18"));

            migrationBuilder.DeleteData(
                table: "Stakeholders",
                keyColumn: "Id",
                keyValue: new Guid("d0203d35-a1f3-4dda-bca6-f6da30177102"));

            migrationBuilder.DeleteData(
                table: "Stakeholders",
                keyColumn: "Id",
                keyValue: new Guid("d9b199e5-263e-4e59-bb38-9420f5acdfc0"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "8b4f34d8-bd89-4b86-b47e-a9d12e3c910e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "4bf269de-fa63-468a-b1e5-9a351aad789b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "062077ef-8c27-4343-a218-11c6b6f2d6b2", "AQAAAAEAACcQAAAAEN17ADOkRsK3h3bC23nPcJwjxyqf6JQPic4cu6wKWWxoVUk3WN7rKm9kTxt/y9Dlqw==", "eb90c08a-6d5a-48ae-b62e-a27e880ce775" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700bfcb2-a703-43dc-a95a-38eb7aadd4ed", "AQAAAAEAACcQAAAAECOfjezfQ4+U0KmRKNWPyVBKcbxDmlPDGISZbM5Efpck7A7HDTTQ3vV21aGn1bZyWQ==", "cdd3ea40-2152-4156-aefd-702f0477de67" });
        }
    }
}
