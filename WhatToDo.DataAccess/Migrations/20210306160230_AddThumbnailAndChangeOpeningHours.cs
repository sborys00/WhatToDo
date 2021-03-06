using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatToDo.DataAccess.Migrations
{
    public partial class AddThumbnailAndChangeOpeningHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThumbnailImageId",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_ThumbnailImageId",
                table: "Places",
                column: "ThumbnailImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Images_ThumbnailImageId",
                table: "Places",
                column: "ThumbnailImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Images_ThumbnailImageId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_ThumbnailImageId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ThumbnailImageId",
                table: "Places");
        }
    }
}
