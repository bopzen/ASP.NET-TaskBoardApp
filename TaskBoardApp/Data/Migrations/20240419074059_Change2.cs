using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class Change2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4632440-a390-4f8c-8f7a-e076fe4977da");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99d88d0a-abf6-42f0-bf88-54db455bcfa5", 0, "41cf2f40-3005-469e-8014-f61f1e78b264", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEH17uTb1lTdIrnirH567KRNtIhs3pGO89MMj3t/dIMzV3XEk2Z+ILCv7343Z3wCGAA==", null, false, "6cc85ac3-31fa-491a-9d16-8d4b4605aabb", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 10, 2, 10, 40, 59, 554, DateTimeKind.Utc).AddTicks(2717), "99d88d0a-abf6-42f0-bf88-54db455bcfa5" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 14, 10, 40, 59, 554, DateTimeKind.Utc).AddTicks(2748), "99d88d0a-abf6-42f0-bf88-54db455bcfa5" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 18, 10, 40, 59, 554, DateTimeKind.Utc).AddTicks(2751), "99d88d0a-abf6-42f0-bf88-54db455bcfa5" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 18, 10, 40, 59, 554, DateTimeKind.Utc).AddTicks(2753), "99d88d0a-abf6-42f0-bf88-54db455bcfa5" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_OwnerId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99d88d0a-abf6-42f0-bf88-54db455bcfa5");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tasks",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4632440-a390-4f8c-8f7a-e076fe4977da", 0, "b762b67a-76ca-4fea-8de5-11fe0748ccda", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEA/nt12sVi0dU+qRKnEYfuca5HZCn7jXSvzStm3b8ZjH/KMu94RbSHuysQDEAIbofQ==", null, false, "36fb3c3d-e286-47df-aafc-7b94957794cb", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 29, 10, 8, 15, 208, DateTimeKind.Local).AddTicks(5884), "e4632440-a390-4f8c-8f7a-e076fe4977da" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 11, 10, 8, 15, 208, DateTimeKind.Local).AddTicks(5919), "e4632440-a390-4f8c-8f7a-e076fe4977da" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 15, 10, 8, 15, 208, DateTimeKind.Local).AddTicks(5921), "e4632440-a390-4f8c-8f7a-e076fe4977da" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 15, 10, 8, 15, 208, DateTimeKind.Local).AddTicks(5923), "e4632440-a390-4f8c-8f7a-e076fe4977da" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
