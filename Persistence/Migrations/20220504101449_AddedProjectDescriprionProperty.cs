using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedProjectDescriprionProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "IsDeleted" },
                values: new object[] { new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"), "Planmykids project that helps parents with building itineraries for kids to different camps.", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("340cf520-35e7-47f3-ad61-5e15d705cb6f"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "5b6b0d94-bc12-40a9-b63d-0cd3d9304e08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "23484b6b-e8ff-4e12-96ca-faa1b1f8cd21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "833d756a-0a57-467b-b5c6-3c443711a2cd", "AQAAAAEAACcQAAAAEKAELEX3mXzZOvMrWKx9WlSQE0Q1kPWrtXxbJB7RBJSdZa2cpulXY9Ncf4MuHajIww==", "e8b00630-4e6a-4218-be41-726f679cef0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54aa4d36-81eb-420e-b38b-71d4593cfb3c", "AQAAAAEAACcQAAAAEJShRqkr8BtPy/6oCxkAtUDi2LTwbYb3PYo/7er19g7MfshReRP+ZYS+5mjeOAOa5Q==", "e82133eb-da58-413e-99fb-d763e4baad77" });
        }
    }
}
