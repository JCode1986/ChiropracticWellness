using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApp.Migrations.StoreDb
{
    public partial class noTildeAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "/Styles/Assets/InitialEvaluation.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "/Styles/Assets/FollowUpConsultation.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "/Styles/Assets/LowBack1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "/Styles/Assets/NeckAdjustment1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "/Styles/Assets/UpperBack1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "/Styles/Assets/LowBack2.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "/Styles/Assets/NeckAdjustment2.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "/Styles/Assets/UpperBack2.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "/Styles/Assets/Massage1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "/Styles/Assets/Massage2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "~/Styles/Assets/InitialEvaluation.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Image",
                value: "~/Styles/Assets/FollowUpConsultation.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Image",
                value: "~/Styles/Assets/LowBack1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 4,
                column: "Image",
                value: "~/Styles/Assets/NeckAdjustment1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 5,
                column: "Image",
                value: "~/Styles/Assets/UpperBack1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 6,
                column: "Image",
                value: "~/Styles/Assets/LowBack2.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 7,
                column: "Image",
                value: "~/Styles/Assets/NeckAdjustment2.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 8,
                column: "Image",
                value: "~/Styles/Assets/UpperBack2.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 9,
                column: "Image",
                value: "~/Styles/Assets/Massage1.jpg");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "ID",
                keyValue: 10,
                column: "Image",
                value: "~/Styles/Assets/Massage2.jpg");
        }
    }
}
