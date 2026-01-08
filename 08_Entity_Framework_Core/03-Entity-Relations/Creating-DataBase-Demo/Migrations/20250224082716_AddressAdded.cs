using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Creating_DataBase_Demo.Migrations
{
    public partial class AddressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "uni",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "uni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Town = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "uni",
                        principalTable: "Students",
                        principalColumn: "StudentPk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                schema: "uni",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                schema: "uni",
                table: "Addresses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressId",
                schema: "uni",
                table: "Students",
                column: "AddressId",
                principalSchema: "uni",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                schema: "uni",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "uni");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressId",
                schema: "uni",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "uni",
                table: "Students");
        }
    }
}
