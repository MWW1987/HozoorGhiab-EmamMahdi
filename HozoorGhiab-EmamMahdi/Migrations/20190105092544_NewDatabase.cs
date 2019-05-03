using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HozoorGhiabEmamMahdi.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ostads",
                columns: table => new
                {
                    OstadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Tell = table.Column<string>(maxLength: 11, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ostads", x => x.OstadId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Tell = table.Column<string>(maxLength: 11, nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Dorooses",
                columns: table => new
                {
                    DoroosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    OstadId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    DarsTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dorooses", x => x.DoroosId);
                    table.ForeignKey(
                        name: "FK_Dorooses_Ostads_OstadId",
                        column: x => x.OstadId,
                        principalTable: "Ostads",
                        principalColumn: "OstadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doroos_Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    DoroosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doroos_Users", x => new { x.DoroosId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Doroos_Users_Dorooses_DoroosId",
                        column: x => x.DoroosId,
                        principalTable: "Dorooses",
                        principalColumn: "DoroosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doroos_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hozoors",
                columns: table => new
                {
                    HozoorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tarikh = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DarsId = table.Column<int>(nullable: false),
                    Hazer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hozoors", x => x.HozoorId);
                    table.ForeignKey(
                        name: "FK_Hozoors_Dorooses_DarsId",
                        column: x => x.DarsId,
                        principalTable: "Dorooses",
                        principalColumn: "DoroosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hozoors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doroos_Users_UserId",
                table: "Doroos_Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dorooses_OstadId",
                table: "Dorooses",
                column: "OstadId");

            migrationBuilder.CreateIndex(
                name: "IX_Hozoors_DarsId",
                table: "Hozoors",
                column: "DarsId");

            migrationBuilder.CreateIndex(
                name: "IX_Hozoors_UserId",
                table: "Hozoors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doroos_Users");

            migrationBuilder.DropTable(
                name: "Hozoors");

            migrationBuilder.DropTable(
                name: "Dorooses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ostads");
        }
    }
}
