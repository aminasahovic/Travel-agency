using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.TuristickaAgenija.Migrations
{
    /// <inheritdoc />
    public partial class accfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Accommodation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Accommodation");
        }
    }
}
