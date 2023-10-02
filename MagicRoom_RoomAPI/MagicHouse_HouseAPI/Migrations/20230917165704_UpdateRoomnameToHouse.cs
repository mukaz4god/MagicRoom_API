using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicHouse_HouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomnameToHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseNumbers");

            migrationBuilder.CreateTable(
                name: "RoomNumbers",
                columns: table => new
                {
                    RoomNo = table.Column<int>(type: "int", nullable: false),
                    HouseID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomNumbers", x => x.RoomNo);
                    table.ForeignKey(
                        name: "FK_RoomNumbers_Houses_HouseID",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 57, 4, 169, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 57, 4, 169, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 57, 4, 169, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 57, 4, 169, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 57, 4, 169, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.CreateIndex(
                name: "IX_RoomNumbers_HouseID",
                table: "RoomNumbers",
                column: "HouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomNumbers");

            migrationBuilder.CreateTable(
                name: "HouseNumbers",
                columns: table => new
                {
                    HouseNo = table.Column<int>(type: "int", nullable: false),
                    HouseID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNumbers", x => x.HouseNo);
                    table.ForeignKey(
                        name: "FK_HouseNumbers_Houses_HouseID",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 40, 0, 115, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 40, 0, 115, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 40, 0, 115, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 40, 0, 115, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 40, 0, 115, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.CreateIndex(
                name: "IX_HouseNumbers_HouseID",
                table: "HouseNumbers",
                column: "HouseID");
        }
    }
}
