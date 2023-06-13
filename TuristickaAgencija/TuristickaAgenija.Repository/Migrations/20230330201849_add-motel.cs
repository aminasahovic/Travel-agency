using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.TuristickaAgenija.Migrations
{
    /// <inheritdoc />
    public partial class addmotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Accommodation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "Accommodation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "Accommodation",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "Accommodation");
        }
    }
}
