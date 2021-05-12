using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpTutorialEntities.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCompany",
                columns: table => new
                {
                    FoodCompanyID = table.Column<Guid>(nullable: false),
                    FoodComanyName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCompany", x => x.FoodCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "PersonEntity",
                columns: table => new
                {
                    PersonEntityID = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEntity", x => x.PersonEntityID);
                });

            migrationBuilder.CreateTable(
                name: "CarCompany",
                columns: table => new
                {
                    CarID = table.Column<Guid>(nullable: false),
                    CarCompanyName = table.Column<string>(nullable: false),
                    PersonEntityID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCompany", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_CarCompany_PersonEntity_PersonEntityID",
                        column: x => x.PersonEntityID,
                        principalTable: "PersonEntity",
                        principalColumn: "PersonEntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCompany_PersonEntityID",
                table: "CarCompany",
                column: "PersonEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCompany");

            migrationBuilder.DropTable(
                name: "FoodCompany");

            migrationBuilder.DropTable(
                name: "PersonEntity");
        }
    }
}
