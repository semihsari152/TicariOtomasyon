using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_databaserelation_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currents_SalesMovements_SalesMovementID",
                table: "Currents");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SalesMovements_SalesMovementID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_SalesMovements_SalesMovementID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_SalesMovementID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Products_SalesMovementID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Currents_SalesMovementID",
                table: "Currents");

            migrationBuilder.DropColumn(
                name: "SalesMovementID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "SalesMovementID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesMovementID",
                table: "Currents");

            migrationBuilder.AddColumn<int>(
                name: "CurrentID",
                table: "SalesMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "SalesMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "SalesMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesMovements_CurrentID",
                table: "SalesMovements",
                column: "CurrentID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMovements_ProductID",
                table: "SalesMovements",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesMovements_StaffID",
                table: "SalesMovements",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesMovements_Currents_CurrentID",
                table: "SalesMovements",
                column: "CurrentID",
                principalTable: "Currents",
                principalColumn: "CurrentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesMovements_Products_ProductID",
                table: "SalesMovements",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesMovements_Staffs_StaffID",
                table: "SalesMovements",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesMovements_Currents_CurrentID",
                table: "SalesMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesMovements_Products_ProductID",
                table: "SalesMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesMovements_Staffs_StaffID",
                table: "SalesMovements");

            migrationBuilder.DropIndex(
                name: "IX_SalesMovements_CurrentID",
                table: "SalesMovements");

            migrationBuilder.DropIndex(
                name: "IX_SalesMovements_ProductID",
                table: "SalesMovements");

            migrationBuilder.DropIndex(
                name: "IX_SalesMovements_StaffID",
                table: "SalesMovements");

            migrationBuilder.DropColumn(
                name: "CurrentID",
                table: "SalesMovements");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "SalesMovements");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "SalesMovements");

            migrationBuilder.AddColumn<int>(
                name: "SalesMovementID",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesMovementID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesMovementID",
                table: "Currents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SalesMovementID",
                table: "Staffs",
                column: "SalesMovementID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesMovementID",
                table: "Products",
                column: "SalesMovementID");

            migrationBuilder.CreateIndex(
                name: "IX_Currents_SalesMovementID",
                table: "Currents",
                column: "SalesMovementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Currents_SalesMovements_SalesMovementID",
                table: "Currents",
                column: "SalesMovementID",
                principalTable: "SalesMovements",
                principalColumn: "SalesMovementsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SalesMovements_SalesMovementID",
                table: "Products",
                column: "SalesMovementID",
                principalTable: "SalesMovements",
                principalColumn: "SalesMovementsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_SalesMovements_SalesMovementID",
                table: "Staffs",
                column: "SalesMovementID",
                principalTable: "SalesMovements",
                principalColumn: "SalesMovementsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
