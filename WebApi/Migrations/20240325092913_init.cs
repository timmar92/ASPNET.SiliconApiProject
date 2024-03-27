using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DownloadResource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false),
                    LikesInNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesInPercent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyNews = table.Column<bool>(type: "bit", nullable: false),
                    Advertising = table.Column<bool>(type: "bit", nullable: false),
                    WeekReview = table.Column<bool>(type: "bit", nullable: false),
                    Events = table.Column<bool>(type: "bit", nullable: false),
                    Startups = table.Column<bool>(type: "bit", nullable: false),
                    Podcasts = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Courses_CourseEntityId",
                        column: x => x.CourseEntityId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailsLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailsLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailsLists_Courses_CourseEntityId",
                        column: x => x.CourseEntityId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pointLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point_10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pointLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pointLists_Courses_CourseEntityId",
                        column: x => x.CourseEntityId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullStarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmptyStarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_CourseEntityId",
                        column: x => x.CourseEntityId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CourseEntityId",
                table: "Authors",
                column: "CourseEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detailsLists_CourseEntityId",
                table: "detailsLists",
                column: "CourseEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pointLists_CourseEntityId",
                table: "pointLists",
                column: "CourseEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseEntityId",
                table: "Reviews",
                column: "CourseEntityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "detailsLists");

            migrationBuilder.DropTable(
                name: "pointLists");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
