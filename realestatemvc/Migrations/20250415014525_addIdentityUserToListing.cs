using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace realestatemvc.Migrations
{
    /// <inheritdoc />
    public partial class addIdentityUserToListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_IdentityUserId",
                table: "Listings",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_IdentityUserId",
                table: "Listings",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_IdentityUserId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_IdentityUserId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Listings");
        }
    }
}
