using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhysiscalPersonDirectory.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationPersonSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RelationPeople",
                columns: new[] { "Id", "ContactType", "PersonId", "RelatedPersonId" },
                values: new object[] { 1, 1, 1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RelationPeople",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
