using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class DetailsTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title_1",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_10",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_2",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_3",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_4",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_5",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_6",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_7",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_8",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_9",
                table: "detailsLists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title_1",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_10",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_2",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_3",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_4",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_5",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_6",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_7",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_8",
                table: "detailsLists");

            migrationBuilder.DropColumn(
                name: "Title_9",
                table: "detailsLists");
        }
    }
}
