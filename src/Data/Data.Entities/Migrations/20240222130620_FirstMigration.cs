using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace devdeer.AssetsManager.Data.Entities.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AssetData");

            migrationBuilder.EnsureSchema(
                name: "BaseData");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "BaseData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "BaseData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "BaseData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                schema: "BaseData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workplace",
                schema: "BaseData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                schema: "AssetData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    WorkplaceId = table.Column<long>(type: "bigint", nullable: false),
                    WorkerId = table.Column<long>(type: "bigint", nullable: false),
                    AssetKey = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssetState = table.Column<int>(type: "int", nullable: false),
                    AcquisitionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    Ownership = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimaryImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SecondaryImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "BaseData",
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BaseData",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "BaseData",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "BaseData",
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asset_Workplace_WorkplaceId",
                        column: x => x.WorkplaceId,
                        principalSchema: "BaseData",
                        principalTable: "Workplace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_BrandId",
                schema: "AssetData",
                table: "Asset",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CategoryId",
                schema: "AssetData",
                table: "Asset",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_LocationId",
                schema: "AssetData",
                table: "Asset",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_WorkerId",
                schema: "AssetData",
                table: "Asset",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_WorkplaceId",
                schema: "AssetData",
                table: "Asset",
                column: "WorkplaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset",
                schema: "AssetData");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "BaseData");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "BaseData");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "BaseData");

            migrationBuilder.DropTable(
                name: "Worker",
                schema: "BaseData");

            migrationBuilder.DropTable(
                name: "Workplace",
                schema: "BaseData");
        }
    }
}
