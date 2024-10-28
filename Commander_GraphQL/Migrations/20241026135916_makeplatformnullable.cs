using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commander_GraphQL.Migrations
{
    /// <inheritdoc />
    public partial class makeplatformnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
