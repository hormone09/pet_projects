using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsTeacher = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "registrationApplications",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTeacher = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrationApplications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numberOfAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateOfBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsHasGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    curatorId = table.Column<int>(type: "int", nullable: false),
                    IsNowNumerator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_groups_teachers_curatorId",
                        column: x => x.curatorId,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    groupid = table.Column<int>(type: "int", nullable: true),
                    teacherid = table.Column<int>(type: "int", nullable: true),
                    numberOfBorders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_courses_groups_groupid",
                        column: x => x.groupid,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_courses_teachers_teacherid",
                        column: x => x.teacherid,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "denominatorSchedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_denominatorSchedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_denominatorSchedules_groups_groupId",
                        column: x => x.groupId,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "numeratorSchedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numeratorSchedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_numeratorSchedules_groups_groupId",
                        column: x => x.groupId,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    groupid = table.Column<int>(type: "int", nullable: true),
                    pageNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numberOfAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateOfBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsHasGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_groups_groupid",
                        column: x => x.groupid,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "borders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseid = table.Column<int>(type: "int", nullable: true),
                    dateOfBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateOfFinish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numberOfPairs = table.Column<int>(type: "int", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    IsNow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borders", x => x.id);
                    table.ForeignKey(
                        name: "FK_borders_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schoolDays",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secondCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thirdCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secondTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thirdTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeratorid = table.Column<int>(type: "int", nullable: true),
                    denominatorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolDays", x => x.id);
                    table.ForeignKey(
                        name: "FK_schoolDays_denominatorSchedules_denominatorid",
                        column: x => x.denominatorid,
                        principalTable: "denominatorSchedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_schoolDays_numeratorSchedules_numeratorid",
                        column: x => x.numeratorid,
                        principalTable: "numeratorSchedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "finallyMarks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseid = table.Column<int>(type: "int", nullable: true),
                    valueOfMark = table.Column<double>(type: "float", nullable: false),
                    studentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finallyMarks", x => x.id);
                    table.ForeignKey(
                        name: "FK_finallyMarks_courses_courseid",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_finallyMarks_students_studentid",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    head = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    Teacherid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notifications_teachers_Teacherid",
                        column: x => x.Teacherid,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "borderMarks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    borderid = table.Column<int>(type: "int", nullable: true),
                    valueOfMark = table.Column<double>(type: "float", nullable: false),
                    studentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borderMarks", x => x.id);
                    table.ForeignKey(
                        name: "FK_borderMarks_borders_borderid",
                        column: x => x.borderid,
                        principalTable: "borders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_borderMarks_students_studentid",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    task = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    borderid = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time = table.Column<TimeSpan>(type: "time", nullable: false),
                    timeBorderForAnswer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    IsToday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_subjects_borders_borderid",
                        column: x => x.borderid,
                        principalTable: "borders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subjectid = table.Column<int>(type: "int", nullable: true),
                    studentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.id);
                    table.ForeignKey(
                        name: "FK_answers_students_studentid",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_answers_subjects_subjectid",
                        column: x => x.subjectid,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "answerMarks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    answerId = table.Column<int>(type: "int", nullable: false),
                    valueOfMark = table.Column<double>(type: "float", nullable: false),
                    studentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answerMarks", x => x.id);
                    table.ForeignKey(
                        name: "FK_answerMarks_answers_answerId",
                        column: x => x.answerId,
                        principalTable: "answers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_answerMarks_students_studentid",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_answerMarks_answerId",
                table: "answerMarks",
                column: "answerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_answerMarks_studentid",
                table: "answerMarks",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_answers_studentid",
                table: "answers",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_answers_subjectid",
                table: "answers",
                column: "subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_borderMarks_borderid",
                table: "borderMarks",
                column: "borderid");

            migrationBuilder.CreateIndex(
                name: "IX_borderMarks_studentid",
                table: "borderMarks",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_borders_courseid",
                table: "borders",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_courses_groupid",
                table: "courses",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_courses_teacherid",
                table: "courses",
                column: "teacherid");

            migrationBuilder.CreateIndex(
                name: "IX_denominatorSchedules_groupId",
                table: "denominatorSchedules",
                column: "groupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_finallyMarks_courseid",
                table: "finallyMarks",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_finallyMarks_studentid",
                table: "finallyMarks",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_groups_curatorId",
                table: "groups",
                column: "curatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_studentId",
                table: "notifications",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_Teacherid",
                table: "notifications",
                column: "Teacherid");

            migrationBuilder.CreateIndex(
                name: "IX_numeratorSchedules_groupId",
                table: "numeratorSchedules",
                column: "groupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_schoolDays_denominatorid",
                table: "schoolDays",
                column: "denominatorid");

            migrationBuilder.CreateIndex(
                name: "IX_schoolDays_numeratorid",
                table: "schoolDays",
                column: "numeratorid");

            migrationBuilder.CreateIndex(
                name: "IX_students_groupid",
                table: "students",
                column: "groupid");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_borderid",
                table: "subjects",
                column: "borderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answerMarks");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "borderMarks");

            migrationBuilder.DropTable(
                name: "finallyMarks");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "registrationApplications");

            migrationBuilder.DropTable(
                name: "schoolDays");

            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "denominatorSchedules");

            migrationBuilder.DropTable(
                name: "numeratorSchedules");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "borders");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
