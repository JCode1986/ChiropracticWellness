using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApp.Migrations.StoreDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "ID", "Description", "Duration", "Image", "Price", "ServiceType" },
                values: new object[,]
                {
                    { 1, "Initial Evaluation where physical therapist will spend time with you to learn about your condition, your previous level of function, and how your condition is affecting your life.", "1 hour", null, 100.00m, "Initial Consultation" },
                    { 2, "Follow up evaluation.", "30 minutes", null, 50.00m, "Follow-up Consultation" },
                    { 3, "Lower back stuff here.", "30 minutes", null, 75.00m, "Lower Back Adjustment" },
                    { 4, "Neck stuff here.", "45 minutes", null, 100.00m, "Neck Adjustment" },
                    { 5, "Upper back stuff here.", "30 minutes", null, 75.00m, "Upper Back Adjustment" },
                    { 6, "Package deal lower back stuff here.", "1 hour 30 minutes", null, 100.00m, "Pack of Lower Back Adjustments" },
                    { 7, "Package deal neck stuff here.", "1 hour 30 minutes", null, 125.00m, "Pack of Neck Adjustments" },
                    { 8, "Package deal lower back stuff here.", "1 hour 30 minutes", null, 100.00m, "Pack of Upper Back Adjustments" },
                    { 9, "60 minute massage description here.", "60 minutes", null, 80.00m, "60 Minute Massage" },
                    { 10, "60 minute massage description here.", "30 minutes", null, 45.00m, "30 Minute Massage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
