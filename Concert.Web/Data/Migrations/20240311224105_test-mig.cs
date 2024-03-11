using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concert.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class testmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConcertId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AppUserId",
                table: "Tickets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserId",
                table: "Tickets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Concerts_ConcertId",
                table: "Tickets",
                column: "ConcertId",
                principalTable: "Concerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AppUserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Concerts_ConcertId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AppUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ConcertId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "Tickets");
        }
    }
}
