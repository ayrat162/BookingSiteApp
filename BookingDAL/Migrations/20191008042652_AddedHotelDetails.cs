using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingDAL.Migrations
{
    public partial class AddedHotelDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionShort",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MapLink",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotelModelId = table.Column<int>(nullable: false),
                    FullDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Hotels_HotelModelId",
                        column: x => x.HotelModelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_HotelModelId",
                table: "Details",
                column: "HotelModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "DescriptionShort",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "MapLink",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "Hotels");
        }
    }
}
