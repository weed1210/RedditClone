using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reddit.API.Migrations
{
    /// <inheritdoc />
    public partial class _20240611_AddPriorityAndCoperatorToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_MemberId",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "CoperatorId",
                table: "Tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("57ffb575-7c79-4133-8433-aebbcd71f824"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7c5b4c5-57b6-42ad-afe3-669ee4a9e38c", "AQAAAAIAAYagAAAAEJE7TLeowTmt1QX7Y7JAs9frCm/v/EuwlpRpjttg228Z0gjxKvEwkX6bhJ2W0+r3kA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CoperatorId",
                table: "Tasks",
                column: "CoperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_CoperatorId",
                table: "Tasks",
                column: "CoperatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_MemberId",
                table: "Tasks",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_CoperatorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_MemberId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CoperatorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CoperatorId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("57ffb575-7c79-4133-8433-aebbcd71f824"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b290c716-fb8d-4746-909a-550a19710f76", "AQAAAAIAAYagAAAAEJr2usdbtiLgjGsxnP5VrVrex1IbB2TAijZN4o9tjCydKioYh7BZetFyZ+JYOIjCVg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_MemberId",
                table: "Tasks",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
