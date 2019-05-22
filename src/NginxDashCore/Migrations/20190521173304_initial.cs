using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace NginxDashCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastConf = table.Column<string>(type: "text", nullable: true),
                    ConfMd5Sum = table.Column<string>(maxLength: 32, nullable: true),
                    TestConf = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ForceHttps = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subdomains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastConf = table.Column<string>(type: "text", nullable: true),
                    ConfMd5Sum = table.Column<string>(maxLength: 32, nullable: true),
                    TestConf = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsDomainRoot = table.Column<bool>(nullable: false),
                    ForceHttps = table.Column<bool>(nullable: false),
                    DomainId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subdomains_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 36, nullable: false),
                    LastConf = table.Column<string>(type: "text", nullable: true),
                    ConfMd5Sum = table.Column<string>(maxLength: 32, nullable: true),
                    TestConf = table.Column<string>(type: "text", nullable: true),
                    Modifier = table.Column<int>(nullable: false),
                    Match = table.Column<string>(maxLength: 100, nullable: false),
                    SubdomainId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Subdomains_SubdomainId",
                        column: x => x.SubdomainId,
                        principalTable: "Subdomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Directive = table.Column<int>(nullable: false),
                    value = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationSetting_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_SubdomainId",
                table: "Location",
                column: "SubdomainId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationSetting_LocationId",
                table: "LocationSetting",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdomains_DomainId",
                table: "Subdomains",
                column: "DomainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationSetting");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Subdomains");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
