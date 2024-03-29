﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADO_klass_work1.Migrations
{
    /// <inheritdoc />
    public partial class InternationalName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InternationlName",
                table: "Departments",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("131ef84b-f06e-494b-848f-bb4bc0604266"),
                column: "InternationlName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("1ef7268c-43a8-488c-b761-90982b31df4e"),
                column: "InternationlName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("415b36d9-2d82-4a92-a313-48312f8e18c6"),
                column: "InternationlName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("624b3bb5-0f2c-42b6-a416-099aab799546"),
                column: "InternationlName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8dcc3969-1d93-47a9-8b79-a30c738db9b4"),
                column: "InternationlName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d2469412-0e4b-46f7-80ec-8c522364d099"),
                column: "InternationlName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d3c376e4-bce3-4d85-aba4-e3cf49612c94"),
                column: "InternationlName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternationlName",
                table: "Departments");
        }
    }
}
