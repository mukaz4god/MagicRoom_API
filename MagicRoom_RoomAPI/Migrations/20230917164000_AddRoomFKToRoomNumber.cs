using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicHouse_HouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHouseFKToHouseNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseID",
                table: "HouseNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_HouseNumbers_Houses_HouseID",
                table: "HouseNumbers",
                column: "HouseID",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseNumbers_Houses_HouseID",
                table: "HouseNumbers");

            migrationBuilder.DropIndex(
                name: "IX_HouseNumbers_HouseID",
                table: "HouseNumbers");

            migrationBuilder.DropColumn(
                name: "HouseID",
                table: "HouseNumbers");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 7, 8, 770, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 7, 8, 770, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 7, 8, 770, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 7, 8, 770, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 17, 7, 8, 770, DateTimeKind.Local).AddTicks(2790));
        }
    }
}
