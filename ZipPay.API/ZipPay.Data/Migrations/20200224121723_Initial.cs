using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZipPay.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyExpense = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity_EmailAddress", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AccountEntities",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<long>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    IsAccountActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEntity_AccountNumber", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_AccountEntity_UserEntity",
                        column: x => x.UserId,
                        principalTable: "UserEntities",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntities_UserId",
                table: "AccountEntities",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountEntities");

            migrationBuilder.DropTable(
                name: "UserEntities");
        }
    }
}
