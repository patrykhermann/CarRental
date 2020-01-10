using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    PricePerDay = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PickUpDate = table.Column<DateTimeOffset>(nullable: false),
                    DropOffDate = table.Column<DateTimeOffset>(nullable: false),
                    PickUpLocation = table.Column<string>(maxLength: 50, nullable: false),
                    DropOffLocation = table.Column<string>(maxLength: 50, nullable: false),
                    FullPrice = table.Column<decimal>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Model", "PricePerDay" },
                values: new object[,]
                {
                    { new Guid("55c1b270-2b89-481a-8efe-43e4c1d8a083"), "Skoda", "Citigo", 59m },
                    { new Guid("4027a68c-5cf7-4b07-9fbd-fdd2fec85e5c"), "Opel", "Corsa", 89m },
                    { new Guid("1399ac00-8d3c-40e6-82a6-218ad13613ba"), "Skoda", "Fabia", 89m },
                    { new Guid("5bf2ce55-2f36-426d-b6b8-1243532b7700"), "Opel", "Astra", 109m },
                    { new Guid("ce6cb2d4-a123-4958-82eb-96d13d961219"), "Seat", "Leon", 109m },
                    { new Guid("29c4e1e9-1689-4c3f-9546-2ba17c6f4219"), "Volkswagen", "Passat", 149m },
                    { new Guid("ae939b70-1834-4ece-8cda-182694c2b6e8"), "Kia", "Sportage", 169m },
                    { new Guid("28439609-b9a3-46c5-85d3-fa9de41b93c2"), "BMW", "530", 229m }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("01b1df53-aa1e-4de3-94e8-fc5db416d1ab"), new DateTimeOffset(new DateTime(1972, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "jan.kowalski@gmail.com", "Jan", "Kowalski", "123456789" },
                    { new Guid("b703b28b-f6a3-48a7-bc30-843e1432067f"), new DateTimeOffset(new DateTime(1990, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "piotr.nowak@gmail.com", "Piotr", "Nowak", "123456789" },
                    { new Guid("0b52188f-6c5d-4b88-aaa9-bb0b977191b2"), new DateTimeOffset(new DateTime(1962, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "w.mazur@gmail.com", "Wojciech", "Mazur", "123456789" },
                    { new Guid("63c8753b-31a6-4cda-be54-344285573086"), new DateTimeOffset(new DateTime(1987, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "a.zolc@gmail.com", "Artur", "Żółć", "123456789" },
                    { new Guid("c89e32ee-b112-468f-8f35-47dd669c4476"), new DateTimeOffset(new DateTime(1969, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "ryszard_malinowski@gmail.com", "Ryszard", "Malinowski", "123456789" },
                    { new Guid("39d51b08-4175-4a35-83ef-764385e33b4a"), new DateTimeOffset(new DateTime(1992, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "k.nowicki@gmail.com", "Kacper", "Nowicki", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "ClientId", "Discount", "DropOffDate", "DropOffLocation", "FullPrice", "PickUpDate", "PickUpLocation" },
                values: new object[] { new Guid("ca96e8a7-2b4d-43af-90d1-09b701473c4c"), new Guid("4027a68c-5cf7-4b07-9fbd-fdd2fec85e5c"), new Guid("0b52188f-6c5d-4b88-aaa9-bb0b977191b2"), 0, new DateTimeOffset(new DateTime(2020, 1, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Warszawa, lotnisko Chopina", 623m, new DateTimeOffset(new DateTime(2020, 1, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Poznań, lotnisko Ławica" });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ClientId",
                table: "Rentals",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
