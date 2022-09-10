using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addedProgrammingTechnologyV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "ProgrammingTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingLanguageId",
                table: "ProgrammingTechnologies");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguageId",
                table: "ProgrammingTechnologies");

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingTechnologiesId" },
                values: new object[] { 1, "WFP", 3 });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingTechnologiesId" },
                values: new object[] { 2, "Pygame", 7 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingTechnologiesId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingTechnologiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingTechnologies_ProgrammingLanguages_ProgrammingTechnologiesId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingTechnologiesId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingTechnologies_ProgrammingLanguages_ProgrammingTechnologiesId",
                table: "ProgrammingTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingTechnologiesId",
                table: "ProgrammingTechnologies");

            migrationBuilder.DeleteData(
                table: "ProgrammingTechnologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProgrammingTechnologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ProgrammingLanguageId",
                table: "ProgrammingTechnologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingLanguageId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
