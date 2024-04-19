using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4632440-a390-4f8c-8f7a-e076fe4977da", 0, "b762b67a-76ca-4fea-8de5-11fe0748ccda", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEA/nt12sVi0dU+qRKnEYfuca5HZCn7jXSvzStm3b8ZjH/KMu94RbSHuysQDEAIbofQ==", null, false, "36fb3c3d-e286-47df-aafc-7b94957794cb", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 29, 10, 8, 15, 208, DateTimeKind.Utc).AddTicks(5884), "e4632440-a390-4f8c-8f7a-e076fe4977da" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 11, 10, 8, 15, 208, DateTimeKind.Utc).AddTicks(5919), "e4632440-a390-4f8c-8f7a-e076fe4977da" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 15, 10, 8, 15, 208, DateTimeKind.Utc).AddTicks(5921), "e4632440-a390-4f8c-8f7a-e076fe4977da" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 15, 10, 8, 15, 208, DateTimeKind.Utc).AddTicks(5923), "e4632440-a390-4f8c-8f7a-e076fe4977da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4632440-a390-4f8c-8f7a-e076fe4977da");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf", 0, "b75a3a65-8453-4660-9ab6-034a36d26f66", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEJI+5m2L9A191O2cIuIxCE8h35dbnOhlL6jKe8cOnoBiNZrpCgGl/piYxJNgG3slHg==", null, false, "9705abf3-212e-4a92-9714-e06dc117c407", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 25, 13, 58, 58, 900, DateTimeKind.Local).AddTicks(246), "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 7, 13, 58, 58, 900, DateTimeKind.Local).AddTicks(285), "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 11, 13, 58, 58, 900, DateTimeKind.Local).AddTicks(288), "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 4, 11, 13, 58, 58, 900, DateTimeKind.Local).AddTicks(290), "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf" });
        }
    }
}
