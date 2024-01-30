using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EZTripAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(name: "Full_Name", type: "nvarchar(max)", nullable: false),
                    Nbrpeople = table.Column<int>(name: "Nbr_people", type: "int", nullable: false),
                    Bookedat = table.Column<DateTime>(name: "Booked_at", type: "datetime2", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    FullPrice = table.Column<double>(name: "Full_Price", type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(name: "Hotel_Name", type: "nvarchar(max)", nullable: false),
                    CityHotel = table.Column<string>(name: "City_Hotel", type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbrRooms = table.Column<int>(name: "Nbr_Rooms", type: "int", nullable: false),
                    PricePerPerson = table.Column<double>(name: "Price_Per_Person", type: "float", nullable: false),
                    HotelImage = table.Column<string>(name: "Hotel_Image", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportationName = table.Column<string>(name: "Transportation_Name", type: "nvarchar(max)", nullable: false),
                    TransportationType = table.Column<string>(name: "Transportation_Type", type: "nvarchar(max)", nullable: false),
                    PricePerPerson = table.Column<double>(name: "Price_Per_Person", type: "float", nullable: false),
                    TransportationImage = table.Column<string>(name: "Transportation_Image", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripName = table.Column<string>(name: "Trip_Name", type: "nvarchar(max)", nullable: false),
                    DestinationName = table.Column<string>(name: "Destination_Name", type: "nvarchar(max)", nullable: false),
                    NightsStay = table.Column<int>(name: "Nights_Stay", type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    TransportationId = table.Column<int>(type: "int", nullable: false),
                    PricePerPerson = table.Column<double>(name: "Price_Per_Person", type: "float", nullable: false),
                    DepartmentDate = table.Column<DateTime>(name: "Department_Date", type: "datetime2", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripImage = table.Column<string>(name: "Trip_Image", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
