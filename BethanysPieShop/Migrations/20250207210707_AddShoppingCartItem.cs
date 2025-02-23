using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanysPieShop.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PieId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShoppingCartItemId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Pies_PieId",
                        column: x => x.PieId,
                        principalTable: "Pies",
                        principalColumn: "PieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCartItems_ShoppingCartItemId1",
                        column: x => x.ShoppingCartItemId1,
                        principalTable: "ShoppingCartItems",
                        principalColumn: "ShoppingCartItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pies_ShoppingCartItemId",
                table: "Pies",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShoppingCartItemId",
                table: "Categories",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_PieId",
                table: "ShoppingCartItems",
                column: "PieId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartItemId1",
                table: "ShoppingCartItems",
                column: "ShoppingCartItemId1");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ShoppingCartItems_ShoppingCartItemId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Pies_ShoppingCartItems_ShoppingCartItemId",
                table: "Pies");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Pies_ShoppingCartItemId",
                table: "Pies");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ShoppingCartItemId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId",
                table: "Categories");
        }
    }
}
