using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class editView1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 17, 56, 32, 679, DateTimeKind.Local).AddTicks(7413),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 7, 17, 47, 6, 440, DateTimeKind.Local).AddTicks(7188));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EventDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 7, 17, 47, 6, 440, DateTimeKind.Local).AddTicks(7188),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 7, 17, 56, 32, 679, DateTimeKind.Local).AddTicks(7413));
        }
    }
}
