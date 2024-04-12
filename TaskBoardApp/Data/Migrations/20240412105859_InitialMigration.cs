using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BoardId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf", 0, "b75a3a65-8453-4660-9ab6-034a36d26f66", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEJI+5m2L9A191O2cIuIxCE8h35dbnOhlL6jKe8cOnoBiNZrpCgGl/piYxJNgG3slHg==", null, false, "9705abf3-212e-4a92-9714-e06dc117c407", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 25, 13, 58, 58, 900, DateTimeKind.Utc).AddTicks(246), "Implement better styling for all public pages", "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf", "Improve CSS styles", null },
                    { 2, 1, new DateTime(2024, 4, 7, 13, 58, 58, 900, DateTimeKind.Utc).AddTicks(285), "Create Android client app for the TaskBoard RESTful API", "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf", "Android Client App", null },
                    { 3, 1, new DateTime(2024, 4, 11, 13, 58, 58, 900, DateTimeKind.Utc).AddTicks(288), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf", "Desktop Client App", null },
                    { 4, 1, new DateTime(2024, 4, 11, 13, 58, 58, 900, DateTimeKind.Utc).AddTicks(290), "Implement [Create Task] page for adding new tasks", "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf", "Create Tasks", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0dfaa587-6987-4b3b-9449-8d5f9ff1d0cf");
        }
    }
}
