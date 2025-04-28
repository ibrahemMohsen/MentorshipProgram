using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorshipProgram.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPicture",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "UserDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "UserDetails",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "UserDetails");

            migrationBuilder.AddColumn<byte[]>(
                name: "CoverPicture",
                table: "UserDetails",
                type: "varbinary(MAX)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
