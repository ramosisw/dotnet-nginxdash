using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Conf = table.Column<string>(type: "text", nullable: true),
                    ConfMd5Sum = table.Column<string>(maxLength: 32, nullable: true),
                    TestConf = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    UseHttps = table.Column<bool>(nullable: false)
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
                    Conf = table.Column<string>(type: "text", nullable: true),
                    ConfMd5Sum = table.Column<string>(maxLength: 32, nullable: true),
                    TestConf = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(nullable: true),
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
                    Conf = table.Column<string>(type: "text", nullable: true),
                    ConfMd5Sum = table.Column<string>(maxLength: 32, nullable: true),
                    TestConf = table.Column<string>(type: "text", nullable: true),
                    Modifier = table.Column<string>(maxLength: 2, nullable: true),
                    Match = table.Column<string>(maxLength: 100, nullable: true),
                    Settings = table.Column<string>(type: "json", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Location_SubdomainId",
                table: "Location",
                column: "SubdomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdomains_DomainId",
                table: "Subdomains",
                column: "DomainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Subdomains");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
