using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class check2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 20, 44, 43, 910, DateTimeKind.Local).AddTicks(7318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 7, 20, 26, 2, 106, DateTimeKind.Local).AddTicks(1084));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 20, 26, 2, 106, DateTimeKind.Local).AddTicks(1084),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 7, 20, 44, 43, 910, DateTimeKind.Local).AddTicks(7318));
        }
    }
}
