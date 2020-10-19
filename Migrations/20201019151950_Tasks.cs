using Microsoft.EntityFrameworkCore.Migrations;

namespace Windows_Notification_API.Migrations
{
    public partial class Tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<int>(nullable: false),
                    Minute = table.Column<int>(nullable: false),
                    TaskDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
