using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_categories_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_detail_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_location_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_organizer_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LocationName = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(maxLength: 200, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventOrganizers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    OrganizerName = table.Column<string>(maxLength: 150, nullable: false),
                    OrganizerDescription = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false, defaultValue: "1000"),
                    PictureUrl = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    isFree = table.Column<string>(maxLength: 10, nullable: false, defaultValue: "Free"),
                    isPublic = table.Column<string>(maxLength: 10, nullable: false, defaultValue: "Public"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 6, 16, 13, 34, 831, DateTimeKind.Local).AddTicks(8814)),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventCategoryId = table.Column<int>(nullable: false),
                    EventLocationId = table.Column<int>(nullable: false),
                    EventOrganizerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDetails_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetails_EventLocations_EventLocationId",
                        column: x => x.EventLocationId,
                        principalTable: "EventLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetails_EventOrganizers_EventOrganizerId",
                        column: x => x.EventOrganizerId,
                        principalTable: "EventOrganizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetails_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventCategoryId",
                table: "EventDetails",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventLocationId",
                table: "EventDetails",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventOrganizerId",
                table: "EventDetails",
                column: "EventOrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventTypeId",
                table: "EventDetails",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "EventLocations");

            migrationBuilder.DropTable(
                name: "EventOrganizers");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropSequence(
                name: "event_categories_hilo");

            migrationBuilder.DropSequence(
                name: "event_detail_hilo");

            migrationBuilder.DropSequence(
                name: "event_location_hilo");

            migrationBuilder.DropSequence(
                name: "event_organizer_hilo");

            migrationBuilder.DropSequence(
                name: "event_type_hilo");
        }
    }
}
