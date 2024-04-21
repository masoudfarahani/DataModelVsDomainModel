using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDateTimeInPersianFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress_Number = table.Column<int>(type: "int", nullable: false),
                    WorkAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddress_Number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidUntile = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersianValidUntil_Year = table.Column<int>(type: "int", nullable: false),
                    PersianValidUntil_Month = table.Column<int>(type: "int", nullable: false),
                    PersianValidUntil_Day = table.Column<int>(type: "int", nullable: false),
                    PersonDataModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Persons_PersonDataModelId",
                        column: x => x.PersonDataModelId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PersonDataModelId",
                table: "Documents",
                column: "PersonDataModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
