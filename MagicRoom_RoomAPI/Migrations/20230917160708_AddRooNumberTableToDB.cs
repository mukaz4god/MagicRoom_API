using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicHouse_HouseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRooNumberTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseNumbers",
                columns: table => new
                {
                    HouseNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNumbers", x => x.HouseNo);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseNumbers");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 11, 56, 28, 579, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 11, 56, 28, 579, DateTimeKind.Local).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 11, 56, 28, 579, DateTimeKind.Local).AddTicks(5587));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 11, 56, 28, 579, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 17, 11, 56, 28, 579, DateTimeKind.Local).AddTicks(5593));
        }
    }
}
