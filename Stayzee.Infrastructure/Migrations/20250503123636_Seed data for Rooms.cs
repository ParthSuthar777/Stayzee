using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Stayzee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeeddataforRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Villa_Id = table.Column<int>(type: "int", nullable: false),
                    VillaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Villas_Villa_Id",
                        column: x => x.Villa_Id,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "SpecificDetails", "VillaName", "Villa_Id" },
                values: new object[,]
                {
                    { 101, "Ocean view, private balcony", "Royal Villa", 1 },
                    { 102, "Ground floor, garden access", "Royal Villa", 1 },
                    { 201, "Direct beach access", "Beachfront Villa", 2 },
                    { 202, "Upper floor, sea view", "Beachfront Villa", 2 },
                    { 301, "Private pool, king bed", "Luxury Pool Villa", 3 },
                    { 302, "Jacuzzi, garden view", "Luxury Pool Villa", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 3, 18, 6, 35, 315, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 3, 18, 6, 35, 316, DateTimeKind.Local).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 3, 18, 6, 35, 316, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Villa_Id",
                table: "Rooms",
                column: "Villa_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 23, 22, 3, 38, 54, DateTimeKind.Local).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 23, 22, 3, 38, 61, DateTimeKind.Local).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 12, 23, 22, 3, 38, 61, DateTimeKind.Local).AddTicks(4338));
        }
    }
}
