using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.TuristickaAgenija.Migrations
{
    /// <inheritdoc />
    public partial class transportTravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    TransportationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.TransportationId);
                });

            migrationBuilder.CreateTable(
                name: "TravelArrangement",
                columns: table => new
                {
                    TravelArrangementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationID = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false),
                    TransportationId = table.Column<int>(type: "int", nullable: false),
                    AccommodationID = table.Column<int>(type: "int", nullable: false),
                    NumberOfPerson = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelArrangement", x => x.TravelArrangementID);
                    table.ForeignKey(
                        name: "FK_TravelArrangement_Accommodation_AccommodationID",
                        column: x => x.AccommodationID,
                        principalTable: "Accommodation",
                        principalColumn: "AccommodationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelArrangement_Destination_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destination",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TravelArrangement_Transportation_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportation",
                        principalColumn: "TransportationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelArrangement_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "UsersID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelArrangement_AccommodationID",
                table: "TravelArrangement",
                column: "AccommodationID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelArrangement_DestinationID",
                table: "TravelArrangement",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelArrangement_TransportationId",
                table: "TravelArrangement",
                column: "TransportationId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelArrangement_UsersID",
                table: "TravelArrangement",
                column: "UsersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelArrangement");

            migrationBuilder.DropTable(
                name: "Transportation");
        }
    }
}
