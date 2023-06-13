using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.TuristickaAgenija.Migrations
{
    /// <inheritdoc />
    public partial class AccADD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Accommodation",
                type: "int",
                nullable: true,
                defaultValue: null );

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_CityID",
                table: "Accommodation",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodation_City_CityID",
                table: "Accommodation",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodation_City_CityID",
                table: "Accommodation");

            migrationBuilder.DropIndex(
                name: "IX_Accommodation_CityID",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Accommodation");
        }
    }
}
