using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.TuristickaAgenija.Migrations
{
    /// <inheritdoc />
    public partial class addcitydestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Destination",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Destination_CityID",
                table: "Destination",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destination_City_CityID",
                table: "Destination",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destination_City_CityID",
                table: "Destination");

            migrationBuilder.DropIndex(
                name: "IX_Destination_CityID",
                table: "Destination");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Destination");
        }
    }
}
