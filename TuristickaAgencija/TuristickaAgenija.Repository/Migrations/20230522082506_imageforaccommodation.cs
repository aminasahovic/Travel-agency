using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.TuristickaAgenija.Migrations
{
    /// <inheritdoc />
    public partial class imageforaccommodation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationImage",
                columns: table => new
                {
                    AccommodationImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccomodationID = table.Column<int>(type: "int", nullable: false),
                    ImageByteArray = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AccommodationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationImage", x => x.AccommodationImageID);
                    table.ForeignKey(
                        name: "FK_AccommodationImage_Accommodation_AccommodationID",
                        column: x => x.AccommodationID,
                        principalTable: "Accommodation",
                        principalColumn: "AccommodationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImage_AccommodationID",
                table: "AccommodationImage",
                column: "AccommodationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationImage");
        }
    }
}
