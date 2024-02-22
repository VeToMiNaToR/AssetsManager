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
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Brands_BrandId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Categories_CategoryId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Locations_LocationId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Workers_WorkerId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Workplaces_WorkplaceId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Condition",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Workplaces",
                newName: "Workplace",
                newSchema: "BaseData");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Worker",
                newSchema: "BaseData");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location",
                newSchema: "BaseData");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category",
                newSchema: "BaseData");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand",
                newSchema: "BaseData");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "BaseData",
                table: "Workplace",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "BaseData",
                table: "Worker",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "BaseData",
                table: "Location",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "BaseData",
                table: "Category",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "BaseData",
                table: "Brand",
                newName: "Label");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryImagePath",
                schema: "BaseData",
                table: "Asset",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryImagePath",
                schema: "BaseData",
                table: "Asset",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AssetState",
                schema: "BaseData",
                table: "Asset",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workplace",
                schema: "BaseData",
                table: "Workplace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                schema: "BaseData",
                table: "Worker",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                schema: "BaseData",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "BaseData",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                schema: "BaseData",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Brand_BrandId",
                schema: "BaseData",
                table: "Asset",
                column: "BrandId",
                principalSchema: "BaseData",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Category_CategoryId",
                schema: "BaseData",
                table: "Asset",
                column: "CategoryId",
                principalSchema: "BaseData",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Location_LocationId",
                schema: "BaseData",
                table: "Asset",
                column: "LocationId",
                principalSchema: "BaseData",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Worker_WorkerId",
                schema: "BaseData",
                table: "Asset",
                column: "WorkerId",
                principalSchema: "BaseData",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Workplace_WorkplaceId",
                schema: "BaseData",
                table: "Asset",
                column: "WorkplaceId",
                principalSchema: "BaseData",
                principalTable: "Workplace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Brand_BrandId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Category_CategoryId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Location_LocationId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Worker_WorkerId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Workplace_WorkplaceId",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workplace",
                schema: "BaseData",
                table: "Workplace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                schema: "BaseData",
                table: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                schema: "BaseData",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "BaseData",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                schema: "BaseData",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "AssetState",
                schema: "BaseData",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Workplace",
                schema: "BaseData",
                newName: "Workplaces");

            migrationBuilder.RenameTable(
                name: "Worker",
                schema: "BaseData",
                newName: "Workers");

            migrationBuilder.RenameTable(
                name: "Location",
                schema: "BaseData",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "BaseData",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Brand",
                schema: "BaseData",
                newName: "Brands");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Workplaces",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Workers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Locations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Brands",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryImagePath",
                schema: "BaseData",
                table: "Asset",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryImagePath",
                schema: "BaseData",
                table: "Asset",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<bool>(
                name: "Condition",
                schema: "BaseData",
                table: "Asset",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workplaces",
                table: "Workplaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Brands_BrandId",
                schema: "BaseData",
                table: "Asset",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Categories_CategoryId",
                schema: "BaseData",
                table: "Asset",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Locations_LocationId",
                schema: "BaseData",
                table: "Asset",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Workers_WorkerId",
                schema: "BaseData",
                table: "Asset",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Workplaces_WorkplaceId",
                schema: "BaseData",
                table: "Asset",
                column: "WorkplaceId",
                principalTable: "Workplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
