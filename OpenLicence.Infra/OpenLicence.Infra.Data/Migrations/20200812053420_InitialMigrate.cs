using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenLicence.Infra.Data.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    VARCHAR128 = table.Column<string>(name: "VARCHAR(128)", nullable: false),
                    VARCHAR14 = table.Column<string>(name: "VARCHAR(14)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareHouses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    VARCHAR128 = table.Column<string>(name: "VARCHAR(128)", nullable: false),
                    VARCHAR14 = table.Column<string>(name: "VARCHAR(14)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareHouses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    VARCHAR128 = table.Column<string>(name: "VARCHAR(128)", nullable: false),
                    SoftwareHouseID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Softwares_SoftwareHouses_SoftwareHouseID",
                        column: x => x.SoftwareHouseID,
                        principalTable: "SoftwareHouses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Expires = table.Column<DateTime>(nullable: false),
                    EnterpriseID = table.Column<Guid>(nullable: false),
                    SoftwareID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Licences_Enterprises_EnterpriseID",
                        column: x => x.EnterpriseID,
                        principalTable: "Enterprises",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licences_Softwares_SoftwareID",
                        column: x => x.SoftwareID,
                        principalTable: "Softwares",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_VARCHAR(14)",
                table: "Enterprises",
                column: "VARCHAR(14)",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_CreatedAt",
                table: "Enterprises",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_VARCHAR(128)",
                table: "Enterprises",
                column: "VARCHAR(128)");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_UpdatedAt",
                table: "Enterprises",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CreatedAt",
                table: "Licences",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_Expires",
                table: "Licences",
                column: "Expires");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_SoftwareID",
                table: "Licences",
                column: "SoftwareID");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_EnterpriseID_SoftwareID",
                table: "Licences",
                columns: new[] { "EnterpriseID", "SoftwareID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareHouses_VARCHAR(14)",
                table: "SoftwareHouses",
                column: "VARCHAR(14)",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareHouses_CreatedAt",
                table: "SoftwareHouses",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareHouses_VARCHAR(128)",
                table: "SoftwareHouses",
                column: "VARCHAR(128)");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_CreatedAt",
                table: "Softwares",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_SoftwareHouseID",
                table: "Softwares",
                column: "SoftwareHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_VARCHAR(128)_SoftwareHouseID",
                table: "Softwares",
                columns: new[] { "VARCHAR(128)", "SoftwareHouseID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Softwares");

            migrationBuilder.DropTable(
                name: "SoftwareHouses");
        }
    }
}
