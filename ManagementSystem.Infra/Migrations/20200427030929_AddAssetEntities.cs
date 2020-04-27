using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Infra.Migrations
{
    public partial class AddAssetEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetPrimaryInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    AssetName = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    RiskPoint = table.Column<double>(nullable: false),
                    AssetPoint = table.Column<double>(nullable: false),
                    AssetType = table.Column<int>(nullable: false),
                    AssetKind = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RegTime = table.Column<DateTime>(nullable: false),
                    SetTime = table.Column<DateTime>(nullable: true),
                    ModTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPrimaryInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetSubInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    SubInfoId = table.Column<int>(nullable: false),
                    OrgName = table.Column<string>(nullable: true),
                    RiskGrade = table.Column<double>(nullable: false),
                    AssetPrimaryInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetSubInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetSubInfos_AssetPrimaryInfos_AssetPrimaryInfoId",
                        column: x => x.AssetPrimaryInfoId,
                        principalTable: "AssetPrimaryInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetSubInfos_AssetPrimaryInfoId",
                table: "AssetSubInfos",
                column: "AssetPrimaryInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetSubInfos");

            migrationBuilder.DropTable(
                name: "AssetPrimaryInfos");
        }
    }
}
