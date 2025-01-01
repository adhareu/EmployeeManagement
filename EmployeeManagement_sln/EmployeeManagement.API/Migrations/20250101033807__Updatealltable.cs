using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class _Updatealltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "dbo",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                schema: "dbo",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Department");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                schema: "dbo",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Employee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "Designation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Designation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                schema: "dbo",
                table: "Designation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Designation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "Department",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                schema: "dbo",
                table: "Department",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "dbo",
                table: "Department",
                type: "datetime2",
                nullable: true);
        }
    }
}
