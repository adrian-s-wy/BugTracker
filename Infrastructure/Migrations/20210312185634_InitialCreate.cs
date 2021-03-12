using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    priority_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.priority_id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.project_id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    user_group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.user_group_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    email_address = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectVersions",
                columns: table => new
                {
                    version_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    number = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    deadline = table.Column<DateTime>(type: "datetime", nullable: false),
                    realease_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectVersions", x => x.version_id);
                    table.ForeignKey(
                        name: "FK_project_version_project",
                        column: x => x.project_id,
                        principalTable: "Projects",
                        principalColumn: "project_id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectGroups",
                columns: table => new
                {
                    project_group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    user_group_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectGroups", x => x.project_group_id);
                    table.ForeignKey(
                        name: "FK_project_group_project",
                        column: x => x.project_id,
                        principalTable: "Projects",
                        principalColumn: "project_id");
                    table.ForeignKey(
                        name: "FK_project_group_user_group",
                        column: x => x.user_group_id,
                        principalTable: "UserGroups",
                        principalColumn: "user_group_id");
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => new { x.user_id, x.user_group_id });
                    table.ForeignKey(
                        name: "FK_groupmember_user",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_groupmember_usergroup",
                        column: x => x.user_group_id,
                        principalTable: "UserGroups",
                        principalColumn: "user_group_id");
                });

            migrationBuilder.CreateTable(
                name: "Bugs",
                columns: table => new
                {
                    bug_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false),
                    reproduce = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false),
                    environment = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    suggestion_for_fix = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    priority_id = table.Column<int>(type: "int", nullable: false),
                    project_version_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugs", x => x.bug_id);
                    table.ForeignKey(
                        name: "FK_bug_priority",
                        column: x => x.priority_id,
                        principalTable: "Priorities",
                        principalColumn: "priority_id");
                    table.ForeignKey(
                        name: "FK_bug_project_version",
                        column: x => x.project_version_id,
                        principalTable: "ProjectVersions",
                        principalColumn: "version_id");
                    table.ForeignKey(
                        name: "FK_bug_status",
                        column: x => x.status_id,
                        principalTable: "Statuses",
                        principalColumn: "status_id");
                    table.ForeignKey(
                        name: "FK_Bugs_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    priority_id = table.Column<int>(type: "int", nullable: false),
                    project_version_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.task_id);
                    table.ForeignKey(
                        name: "FK_task_priority",
                        column: x => x.priority_id,
                        principalTable: "Priorities",
                        principalColumn: "priority_id");
                    table.ForeignKey(
                        name: "FK_task_project_version",
                        column: x => x.project_version_id,
                        principalTable: "ProjectVersions",
                        principalColumn: "version_id");
                    table.ForeignKey(
                        name: "FK_task_status",
                        column: x => x.status_id,
                        principalTable: "Statuses",
                        principalColumn: "status_id");
                    table.ForeignKey(
                        name: "FK_task_user",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "RelatedBug",
                columns: table => new
                {
                    related_from_id = table.Column<int>(type: "int", nullable: false),
                    related_to_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedBug", x => new { x.related_from_id, x.related_to_id });
                    table.ForeignKey(
                        name: "FK_relatedbug_bug_from",
                        column: x => x.related_from_id,
                        principalTable: "Bugs",
                        principalColumn: "bug_id");
                    table.ForeignKey(
                        name: "FK_relatedbug_bug_to",
                        column: x => x.related_to_id,
                        principalTable: "Bugs",
                        principalColumn: "bug_id");
                });

            migrationBuilder.CreateTable(
                name: "BugTask",
                columns: table => new
                {
                    task_id = table.Column<int>(type: "int", nullable: false),
                    bug_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTask", x => new { x.bug_id, x.task_id });
                    table.ForeignKey(
                        name: "FK_bugtask_bug",
                        column: x => x.bug_id,
                        principalTable: "Bugs",
                        principalColumn: "bug_id");
                    table.ForeignKey(
                        name: "FK_bugtask_task",
                        column: x => x.task_id,
                        principalTable: "Tasks",
                        principalColumn: "task_id");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    note_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    text = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    note_type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    bug_id = table.Column<int>(type: "int", nullable: true),
                    task_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.note_id);
                    table.ForeignKey(
                        name: "FK_bug_note_bug",
                        column: x => x.bug_id,
                        principalTable: "Bugs",
                        principalColumn: "bug_id");
                    table.ForeignKey(
                        name: "FK_note_user",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_task_note_task",
                        column: x => x.task_id,
                        principalTable: "Tasks",
                        principalColumn: "task_id");
                });

            migrationBuilder.CreateTable(
                name: "RelatedTask",
                columns: table => new
                {
                    related_from_id = table.Column<int>(type: "int", nullable: false),
                    related_to_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedTask", x => new { x.related_from_id, x.related_to_id });
                    table.ForeignKey(
                        name: "FK_relatedtask_task_from",
                        column: x => x.related_from_id,
                        principalTable: "Tasks",
                        principalColumn: "task_id");
                    table.ForeignKey(
                        name: "FK_relatedtask_task_to",
                        column: x => x.related_to_id,
                        principalTable: "Tasks",
                        principalColumn: "task_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_priority_id",
                table: "Bugs",
                column: "priority_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_project_version_id",
                table: "Bugs",
                column: "project_version_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_status_id",
                table: "Bugs",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_user_id",
                table: "Bugs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_BugTask_task_id",
                table: "BugTask",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_user_group_id",
                table: "GroupMember",
                column: "user_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_bug_id",
                table: "Notes",
                column: "bug_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_task_id",
                table: "Notes",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_user_id",
                table: "Notes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGroups_project_id",
                table: "ProjectGroups",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGroups_user_group_id",
                table: "ProjectGroups",
                column: "user_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVersions_project_id",
                table: "ProjectVersions",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedBug_related_to_id",
                table: "RelatedBug",
                column: "related_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedTask_related_to_id",
                table: "RelatedTask",
                column: "related_to_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_priority_id",
                table: "Tasks",
                column: "priority_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_project_version_id",
                table: "Tasks",
                column: "project_version_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_status_id",
                table: "Tasks",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_user_id",
                table: "Tasks",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugTask");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "ProjectGroups");

            migrationBuilder.DropTable(
                name: "RelatedBug");

            migrationBuilder.DropTable(
                name: "RelatedTask");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Bugs");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "ProjectVersions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
