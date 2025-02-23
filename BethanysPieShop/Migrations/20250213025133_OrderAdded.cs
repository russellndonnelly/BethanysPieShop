using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanysPieShop.Migrations
{
    /// <inheritdoc />
    public partial class OrderAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ShoppingCartItems_ShoppingCartItemId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Pies_ShoppingCartItems_ShoppingCartItemId",
                table: "Pies");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCartItems_ShoppingCartItemId1",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ShoppingCartItemId1",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Pies_ShoppingCartItemId",
                table: "Pies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ShoppingCartItemId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId1",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PieId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Pies_PieId",
                        column: x => x.PieId,
                        principalTable: "Pies",
                        principalColumn: "PieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PieId",
                table: "OrderDetails",
                column: "PieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartItemId1",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartItemId",
                table: "Pies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartItemId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartItemId1",
                table: "ShoppingCartItems",
                column: "ShoppingCartItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pies_ShoppingCartItemId",
                table: "Pies",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShoppingCartItemId",
                table: "Categories",
                column: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ShoppingCartItems_ShoppingCartItemId",
                table: "Categories",
                column: "ShoppingCartItemId",
                principalTable: "ShoppingCartItems",
                principalColumn: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pies_ShoppingCartItems_ShoppingCartItemId",
                table: "Pies",
                column: "ShoppingCartItemId",
                principalTable: "ShoppingCartItems",
                principalColumn: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCartItems_ShoppingCartItemId1",
                table: "ShoppingCartItems",
                column: "ShoppingCartItemId1",
                principalTable: "ShoppingCartItems",
                principalColumn: "ShoppingCartItemId");
        }
    }
}
