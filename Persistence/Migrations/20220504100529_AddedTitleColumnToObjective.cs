using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedTitleColumnToObjective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Objectives",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Objectives");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09afe919-59ff-44b8-b656-c5e320c163a7",
                column: "ConcurrencyStamp",
                value: "8d89a051-eb1f-4130-8be0-45c06695734a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "967e08ad-b71e-46e8-8e80-ffdce9ab9e74",
                column: "ConcurrencyStamp",
                value: "67503d8d-e9a7-4b0a-8a79-db42a836fca4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f12-9168-49b1-9f17-b87904564904",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf5f1522-e0f1-4485-81af-97f7878c9a7a", "AQAAAAEAACcQAAAAEKbC6NEDEFVDRLtsiKvKsk3UAXZZgGwycki+C8AK3O0LjURVF0HbfAqPjid3dpo2DQ==", "16b09de5-8dce-48eb-bdaa-84a18835015c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23651cbd-eef8-4de8-b5a9-eb797f6d4e0b", "AQAAAAEAACcQAAAAEH47BEaycv/6GgBkFxFv/buzPxpOuL2XrSTxEAsNvI7SjeP3J8O6xWl3/6g4aqXmHw==", "413f07cc-afee-42cd-b3db-c90f38ad247c" });
        }
    }
}
