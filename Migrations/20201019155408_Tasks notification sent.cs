using Microsoft.EntityFrameworkCore.Migrations;

namespace Windows_Notification_API.Migrations
{
    public partial class Tasksnotificationsent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotificationAlreadySent",
                table: "Task",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationAlreadySent",
                table: "Task");
        }
    }
}
