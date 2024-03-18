using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "People",
                columns: new[] { "Id", "BirthDate", "CityId", "Gender", "Image", "Lastname", "Name", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "", "Solis", "Oliver", "60001138372" },
                    { 2, new DateTime(1999, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "", "Rodriguez", "Joan", "60001138373" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "People",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
