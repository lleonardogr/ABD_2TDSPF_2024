using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeiraAppWeb_2TDSPF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boardgames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boardgames", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Boardgames",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { -3, "Build your railroad across North America to connect cities and complete tickets. ", "Ticket to Ride" },
                    { -2, "Shape the medieval landscape of France, claiming cities, monasteries and farms. ", "Carcassonne" },
                    { -1, "Collect and trade resources to build up the island of Catan in this modern classic. ", "Catan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boardgames");
        }
    }
}
