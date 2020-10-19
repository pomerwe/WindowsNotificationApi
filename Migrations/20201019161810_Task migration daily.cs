using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Windows_Notification_API.Migrations
{
    public partial class Taskmigrationdaily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationAlreadySent",
                table: "Task");

            migrationBuilder.AddColumn<bool>(
                name: "Daily",
                table: "Task",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSentNotification",
                table: "Task",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Daily",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "LastSentNotification",
                table: "Task");

            migrationBuilder.AddColumn<bool>(
                name: "NotificationAlreadySent",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
