using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoPlan.Repo.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperTodos_Todos_TodoId1",
                table: "DeveloperTodos");

            migrationBuilder.DropIndex(
                name: "IX_DeveloperTodos_TodoId1",
                table: "DeveloperTodos");

            migrationBuilder.DropColumn(
                name: "TodoId1",
                table: "DeveloperTodos");

            migrationBuilder.AlterColumn<string>(
                name: "TodoId",
                table: "DeveloperTodos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTodos_TodoId",
                table: "DeveloperTodos",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperTodos_Todos_TodoId",
                table: "DeveloperTodos",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeveloperTodos_Todos_TodoId",
                table: "DeveloperTodos");

            migrationBuilder.DropIndex(
                name: "IX_DeveloperTodos_TodoId",
                table: "DeveloperTodos");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "DeveloperTodos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "TodoId1",
                table: "DeveloperTodos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTodos_TodoId1",
                table: "DeveloperTodos",
                column: "TodoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DeveloperTodos_Todos_TodoId1",
                table: "DeveloperTodos",
                column: "TodoId1",
                principalTable: "Todos",
                principalColumn: "Id");
        }
    }
}
