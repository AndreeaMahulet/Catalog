using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Migrations
{
    public partial class tutors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TutoreID",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tutore",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeTutore = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutore", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_TutoreID",
                table: "Student",
                column: "TutoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Tutore_TutoreID",
                table: "Student",
                column: "TutoreID",
                principalTable: "Tutore",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Tutore_TutoreID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Tutore");

            migrationBuilder.DropIndex(
                name: "IX_Student_TutoreID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TutoreID",
                table: "Student");
        }
    }
}
