using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsManagement.Data.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemCodeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemCodeId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OrderNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemCodeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemCodeDetails_SystemCodes_SystemCodeId",
                        column: x => x.SystemCodeId,
                        principalTable: "SystemCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    CountyId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    EducationLevelId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    TelephoneNo = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    CitizenshipId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecturers_SystemCodeDetails_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_SystemCodeDetails_CountryId",
                        column: x => x.CountryId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_SystemCodeDetails_CountyId",
                        column: x => x.CountyId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_SystemCodeDetails_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_SystemCodeDetails_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_SystemCodeDetails_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_SystemCodeDetails_GenderId",
                        column: x => x.GenderId,
                        principalTable: "SystemCodeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CitizenshipId",
                table: "Lecturers",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CountryId",
                table: "Lecturers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CountyId",
                table: "Lecturers",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CourseId",
                table: "Lecturers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_DepartmentId",
                table: "Lecturers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_EducationLevelId",
                table: "Lecturers",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_EthnicityId",
                table: "Lecturers",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_GenderId",
                table: "Lecturers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemCodeDetails_SystemCodeId",
                table: "SystemCodeDetails",
                column: "SystemCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "SystemCodeDetails");

            migrationBuilder.DropTable(
                name: "SystemCodes");
        }
    }
}
