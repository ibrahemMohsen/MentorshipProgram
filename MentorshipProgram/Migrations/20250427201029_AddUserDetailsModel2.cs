using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorshipProgram.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDetailsModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    CoverPicture = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
