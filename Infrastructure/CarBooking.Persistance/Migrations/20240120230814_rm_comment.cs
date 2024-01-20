using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBooking.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class rm_comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogID1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogID1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogID1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlogID",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogID",
                table: "Comments",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogID",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BlogID",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BlogID1",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogID1",
                table: "Comments",
                column: "BlogID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogID1",
                table: "Comments",
                column: "BlogID1",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
