using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRoadmap.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roadmaps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PriorityLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Goal = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadmapItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    LastRequiredItemId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadmapItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoadmapItems_Roadmaps_LastRequiredItemId",
                        column: x => x.LastRequiredItemId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TopicOfInterestId = table.Column<long>(type: "INTEGER", nullable: false),
                    RoadmapId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roadmaps_RoadmapId",
                        column: x => x.RoadmapId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Topics_TopicOfInterestId",
                        column: x => x.TopicOfInterestId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoadmapItems_LastRequiredItemId",
                table: "RoadmapItems",
                column: "LastRequiredItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoadmapId",
                table: "Users",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TopicOfInterestId",
                table: "Users",
                column: "TopicOfInterestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoadmapItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roadmaps");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
