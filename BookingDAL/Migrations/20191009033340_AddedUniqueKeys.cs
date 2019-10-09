using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingDAL.Migrations
{
    public partial class AddedUniqueKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelModelId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Details_HotelModelId",
                table: "Details");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelModelId_RoomNumber",
                table: "Rooms",
                columns: new[] { "HotelModelId", "RoomNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Details_HotelModelId",
                table: "Details",
                column: "HotelModelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelModelId_RoomNumber",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Details_HotelModelId",
                table: "Details");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelModelId",
                table: "Rooms",
                column: "HotelModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_HotelModelId",
                table: "Details",
                column: "HotelModelId");
        }
    }
}
