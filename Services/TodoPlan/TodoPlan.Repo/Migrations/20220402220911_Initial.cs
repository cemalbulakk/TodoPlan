using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoPlan.Repo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeeklyWorkingHours = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sure = table.Column<int>(type: "int", nullable: false),
                    Zorluk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperBusinessTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    BusinessTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperBusinessTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperBusinessTasks_BusinessTasks_BusinessTaskId",
                        column: x => x.BusinessTaskId,
                        principalTable: "BusinessTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperBusinessTasks_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTodos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    TodoId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TodoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTodos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperTodos_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTodos_Todos_TodoId1",
                        column: x => x.TodoId1,
                        principalTable: "Todos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperBusinessTasks_BusinessTaskId",
                table: "DeveloperBusinessTasks",
                column: "BusinessTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperBusinessTasks_DeveloperId",
                table: "DeveloperBusinessTasks",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTodos_DeveloperId",
                table: "DeveloperTodos",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTodos_TodoId1",
                table: "DeveloperTodos",
                column: "TodoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperBusinessTasks");

            migrationBuilder.DropTable(
                name: "DeveloperTodos");

            migrationBuilder.DropTable(
                name: "BusinessTasks");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
