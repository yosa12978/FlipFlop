using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlipFlop.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PubDate",
                table: "posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "PubDate",
                table: "posts");
        }
    }
}
