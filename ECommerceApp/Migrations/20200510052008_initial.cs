using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptOrders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    CartItemQuantity = table.Column<string>(nullable: true),
                    ServiceList = table.Column<string>(nullable: true),
                    ServicePriceList = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptOrders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ServicesID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Inventories_ServicesID",
                        column: x => x.ServicesID,
                        principalTable: "Inventories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "ID", "Description", "Duration", "Image", "Price", "ServiceType" },
                values: new object[,]
                {
                    { 1, "Initial Evaluation where the Chiropractor will spend time with you to learn about your condition, your previous level of function, and how your condition is affecting your life. He will then perform an examination and perform a treatment.", "1 hour", "/Styles/Assets/InitialEvaluation.jpg", 250.00m, "Initial Consultation" },
                    { 2, "A Follow-up Evaluation where the Chiropractor will spend time with you to see how you are doing and how you are meeting your functional goals. He will then perform an mini-examination and perform a treatment. Note: This service is only available after you have had a full initial consultation", "45-60 minutes", "/Styles/Assets/FollowUpConsultation.jpg", 150.00m, "Follow-up Consultation" },
                    { 3, "A follow up visit for targetted adjustment of the lower back.", "30 minutes", "/Styles/Assets/LowBack1.jpg", 75.00m, "Lower Back Adjustment" },
                    { 4, "A follow up visit for targetted adjustment of the neck.", "30 minutes", "/Styles/Assets/NeckAdjustment1.jpg", 85.00m, "Neck Adjustment" },
                    { 5, "A follow up visit for targetted adjustment of the upper back/thoracic region.", "30 minutes", "/Styles/Assets/UpperBack1.jpg", 75.00m, "Upper Back Adjustment" },
                    { 6, "Reguar adjustments are sometimes necessary to maintain pain free postural alignment. This service allows you to purchase 5 low back adjustments at a discounted rate that may be used within the next 6 months.", "30 minutes each", "/Styles/Assets/LowBack2.jpg", 300.00m, "5-Pack of Lower Back Adjustments" },
                    { 7, "Reguar adjustments are sometimes necessary to maintain pain free postural alignment. This service allows you to purchase 5 neck adjustments at a discounted rate that may be used within the next 6 months.", "30 minutes each", "/Styles/Assets/NeckAdjustment2.jpg", 325.00m, "5-Pack of Neck Adjustments" },
                    { 8, "Reguar adjustments are sometimes necessary to maintain pain free postural alignment. This service allows you to purchase 5 upper back/thoracic region adjustments at a discounted rate that may be used within the next 6 months.", "30 minutes each", "/Styles/Assets/UpperBack2.jpg", 300.00m, "5-Pack of Upper Back Adjustments" },
                    { 9, "A 60-minute Orthopedic massage allowing for deep tissue therapy of problem areas. The massage may incorporate Shiatzu, Swedish or trigger point techniques.", "60 minutes", "/Styles/Assets/Massage1.jpg", 80.00m, "60 Minute Massage" },
                    { 10, "A 30-minute Orthopedic massage providing an overall massage. The massage may incorporate Shiatzu or Swedish techniques. This massage is best suited before a Chiropractic adjustment. If you are seeking deep tissue or have a specific problem area, consider a 60-minute massage instead.", "30 minutes", "/Styles/Assets/Massage2.jpg", 45.00m, "30 Minute Massage" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ServicesID",
                table: "CartItems",
                column: "ServicesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ReceiptOrders");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
