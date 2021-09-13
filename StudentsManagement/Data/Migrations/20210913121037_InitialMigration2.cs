using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsManagement.Data.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageSize",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsModelId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentsModelId",
                table: "Students",
                column: "StudentsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_StudentsModelId",
                table: "Students",
                column: "StudentsModelId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_StudentsModelId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentsModelId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PageSize",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentsModelId",
                table: "Students");
        }
    }
}
