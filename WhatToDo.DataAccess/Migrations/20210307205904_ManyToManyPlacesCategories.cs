using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatToDo.DataAccess.Migrations
{
    public partial class ManyToManyPlacesCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Places_PlaceId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PlaceId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "PlaceCategories",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceCategories", x => new { x.PlaceId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PlaceCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceCategories_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceCategories_CategoryId",
                table: "PlaceCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceCategories");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PlaceId",
                table: "Categories",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Places_PlaceId",
                table: "Categories",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
