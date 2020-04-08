using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class check3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 20, 47, 28, 580, DateTimeKind.Local).AddTicks(7344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 7, 20, 44, 43, 910, DateTimeKind.Local).AddTicks(7318));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 20, 44, 43, 910, DateTimeKind.Local).AddTicks(7318),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 7, 20, 47, 28, 580, DateTimeKind.Local).AddTicks(7344));
        }
    }
}
