using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSchool.Data.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageXXS = table.Column<byte[]>(nullable: true),
                    ImageXS = table.Column<byte[]>(nullable: true),
                    ImageM = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateOfEstablishment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 35, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 35, nullable: false),
                    LastName = table.Column<string>(maxLength: 35, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    Occupation = table.Column<string>(maxLength: 20, nullable: true),
                    AboutMe = table.Column<string>(maxLength: 200, nullable: true),
                    ImageXXS = table.Column<byte[]>(nullable: true),
                    ImageXS = table.Column<byte[]>(nullable: true),
                    ImageM = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ImageXXS = table.Column<byte[]>(nullable: true),
                    ImageXS = table.Column<byte[]>(nullable: true),
                    ImageM = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 35, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 35, nullable: false),
                    LastName = table.Column<string>(maxLength: 35, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    PhoneEmergency = table.Column<string>(maxLength: 15, nullable: false),
                    DateOfEmployment = table.Column<DateTime>(nullable: false),
                    DateOfCareerStart = table.Column<DateTime>(nullable: false),
                    AboutMe = table.Column<string>(maxLength: 200, nullable: true),
                    ImageXXS = table.Column<byte[]>(nullable: true),
                    ImageXS = table.Column<byte[]>(nullable: true),
                    ImageM = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 3, nullable: false),
                    ImageXXS = table.Column<byte[]>(nullable: true),
                    ImageXS = table.Column<byte[]>(nullable: true),
                    ImageM = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ClassMasterTeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_ClassMasterTeacherId",
                        column: x => x.ClassMasterTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubsTeachers",
                columns: table => new
                {
                    ClubId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsTeachers", x => new { x.ClubId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ClubsTeachers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubsTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsTeachers",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsTeachers", x => new { x.SubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectsTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 35, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 35, nullable: false),
                    LastName = table.Column<string>(maxLength: 35, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    NumberInClass = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsSchoolCouncilMember = table.Column<bool>(nullable: false),
                    AboutMe = table.Column<string>(maxLength: 200, nullable: true),
                    ImageXXS = table.Column<byte[]>(nullable: true),
                    ImageXS = table.Column<byte[]>(nullable: true),
                    ImageM = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsClasses",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsClasses", x => new { x.ClassId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectsClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectsClasses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachersClasses",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersClasses", x => new { x.ClassId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeachersClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeachersClasses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubsStudents",
                columns: table => new
                {
                    ClubId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsStudents", x => new { x.ClubId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ClubsStudents_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClubsStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueMark = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Comment = table.Column<string>(maxLength: 200, nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    DateConfirmed = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marks_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marks_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusNote = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    DateConfirmed = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentsParents",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsParents", x => new { x.StudentId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_StudentsParents_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentsParents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassMasterTeacherId",
                table: "Classes",
                column: "ClassMasterTeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClubsStudents_StudentId",
                table: "ClubsStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsTeachers_TeacherId",
                table: "ClubsTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_TeacherId",
                table: "Marks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StudentId",
                table: "Notes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_SubjectId",
                table: "Notes",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TeacherId",
                table: "Notes",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsParents_ParentId",
                table: "StudentsParents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsClasses_SubjectId",
                table: "SubjectsClasses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsTeachers_TeacherId",
                table: "SubjectsTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersClasses_TeacherId",
                table: "TeachersClasses",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubsStudents");

            migrationBuilder.DropTable(
                name: "ClubsTeachers");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "StudentsParents");

            migrationBuilder.DropTable(
                name: "SubjectsClasses");

            migrationBuilder.DropTable(
                name: "SubjectsTeachers");

            migrationBuilder.DropTable(
                name: "TeachersClasses");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
