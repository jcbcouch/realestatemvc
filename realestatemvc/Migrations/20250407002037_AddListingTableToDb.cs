using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace realestatemvc.Migrations
{
    /// <inheritdoc />
    public partial class AddListingTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Garage = table.Column<int>(type: "int", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<double>(type: "float", nullable: false),
                    LotSize = table.Column<double>(type: "float", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    PhotoMain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoFive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoSix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
