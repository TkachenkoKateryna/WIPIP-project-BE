using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class IdentitySeedUpdateNormalizedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "4b1f3c7a-7148-48ab-abd0-cfe2a7c07402");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "1bbfa048-50d9-4a76-a8a8-5ed3bc030b8b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffded98f-33a8-4b82-ac89-af022d492bb0", "JANE@TEXT.COM", "AQAAAAEAACcQAAAAEAJ22RCj+O9SzGYFQaAlEgZGp9ZNsAtfjX0dl4Dev6Ut5UoE65h1JbTo6Zw/L/dYIg==", "11358788-bfcf-4d34-a758-21c708db0e1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ff97a92-4264-4def-9d9a-859b4e9d7274", "BOB@TEXT.COM", "AQAAAAEAACcQAAAAEB/4k+wCLEToFHPSjbyLfH22f1krWctGNSwIpu/qdLaCyhtumz8QePanhrqiMRQnBQ==", "78e8c6e2-0c38-4e15-b567-049c77f1c9c9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "63d91dfe-9f1f-4dff-91e8-9487abd77115");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "7e3d4247-aadc-423c-a867-651923540359");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e50d829-33c6-4af0-acba-92b6cc586d93", null, "AQAAAAEAACcQAAAAEN0Vdgx4n0dL9BiOI6qabOPb490U2va6wnwr2bc3rrLpEY5kOBFjcQfzcfen95/jbQ==", "092db806-4534-4a33-87d8-d8d4dcd04f08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd2f90e1-ec84-4cd8-8e01-7ed3c5fb6225", null, "AQAAAAEAACcQAAAAEMtKM4fxtBDqo+hkN12/1YfAweHhOvJqFHJPNXnz1N4TO9ELw1KAYl9V2UJEbuK65Q==", "40d5761c-9ed4-49f1-af63-1050d594fef6" });
        }
    }
}
