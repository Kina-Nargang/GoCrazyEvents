using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class check4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 20, 49, 48, 980, DateTimeKind.Local).AddTicks(4551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 7, 20, 47, 28, 580, DateTimeKind.Local).AddTicks(7344));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 20, 47, 28, 580, DateTimeKind.Local).AddTicks(7344),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 7, 20, 49, 48, 980, DateTimeKind.Local).AddTicks(4551));
        }
    }
}
