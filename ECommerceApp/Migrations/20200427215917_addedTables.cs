using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApp.Migrations
{
    public partial class addedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartItemsID",
                table: "Inventories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CartItemsID",
                table: "Inventories",
                column: "CartItemsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_CartItems_CartItemsID",
                table: "Inventories",
                column: "CartItemsID",
                principalTable: "CartItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_CartItems_CartItemsID",
                table: "Inventories");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_CartItemsID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CartItemsID",
                table: "Inventories");
        }
    }
}
