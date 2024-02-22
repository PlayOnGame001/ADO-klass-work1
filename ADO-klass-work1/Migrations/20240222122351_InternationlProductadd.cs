using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADO_klass_work1.Migrations
{
    /// <inheritdoc />
    public partial class InternationlProductadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InternationlProduct",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17db11d1-f50e-4cf4-9c54-cf1bd45802ea"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21b0f444-2e4f-47d8-80c1-e69bf1c34ca8"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2dca5e44-b06d-4613-bb6a-d3bc91430bfe"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4a550d3b-d1f2-40ef-ae4e-963612c6713a"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64a4df8a-0733-4be9-aaba-c01b4ec3612a"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69b125d7-99cc-42d6-a6fa-46687f333749"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7264d33a-16b9-4e22-b3f1-63d6dae60078"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b08197b-c55f-4389-891f-bf12a575dffb"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("870da1a9-44f4-4018-b7fc-727a2058faf0"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ff90e21-dcdb-4d55-a557-7c6d57dbb029"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("94bc671a-a6b6-417a-bc9f-8ae4871a58ec"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9654271b-ab52-4225-a30c-d75054b1733f"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a8e6be17-5447-4804-ab61-f31abf5a76d3"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6d20749-b495-4b1a-ba1c-80b88e78b7cd"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb29f63d-1261-41f2-89e8-88f44d5ec409"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d17a4442-0a71-4673-b450-36929048adef"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da1e17bb-a90d-4c79-b801-5462fb070f57"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("efc6578a-00b7-4766-a7e3-79cdba8c294b"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2585221-1aca-4efe-a5e8-c2f4534d1f92"),
                column: "InternationlProduct",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f7f1e576-af8d-4749-869e-4a794fe69d42"),
                column: "InternationlProduct",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternationlProduct",
                table: "Products");
        }
    }
}
