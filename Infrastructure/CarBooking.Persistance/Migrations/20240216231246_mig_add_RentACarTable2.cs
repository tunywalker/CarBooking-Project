using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBooking.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_RentACarTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOffLocationId",
                table: "RentACars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DropOffLocationId",
                table: "RentACars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
