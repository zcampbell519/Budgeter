using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budgeter.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    IsContra = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Transactions_TransactionId1",
                        column: x => x.TransactionId1,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId");
                });

            migrationBuilder.CreateTable(
                name: "TransactionEntries",
                columns: table => new
                {
                    TransactionEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEntries", x => x.TransactionEntryId);
                    table.ForeignKey(
                        name: "FK_TransactionEntries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionEntries_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntries_AccountId",
                table: "TransactionEntries",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionEntries_TransactionId",
                table: "TransactionEntries",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionId1",
                table: "Transactions",
                column: "TransactionId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionEntries");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
