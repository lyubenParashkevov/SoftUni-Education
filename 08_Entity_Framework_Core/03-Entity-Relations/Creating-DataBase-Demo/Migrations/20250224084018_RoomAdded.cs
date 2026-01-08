using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Creating_DataBase_Demo.Migrations
{
    public partial class RoomAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                schema: "uni",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "uni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomId",
                schema: "uni",
                table: "Students",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Rooms_RoomId",
                schema: "uni",
                table: "Students",
                column: "RoomId",
                principalSchema: "uni",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Rooms_RoomId",
                schema: "uni",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "uni");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoomId",
                schema: "uni",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoomId",
                schema: "uni",
                table: "Students");
        }
    }
}
