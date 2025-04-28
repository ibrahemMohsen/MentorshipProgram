using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorshipProgram.Migrations
{
    /// <inheritdoc />
    public partial class EditedUserDetailsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "UserDetails");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "UserDetails",
                type: "varbinary(MAX)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
