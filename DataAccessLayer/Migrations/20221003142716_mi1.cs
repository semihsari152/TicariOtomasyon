using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUsername = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    AdminPassword = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    AdminPermission = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDescription = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseID);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptSerialNumber = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: true),
                    ReceiptLineNumber = table.Column<string>(type: "Varchar(6)", maxLength: 6, nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptTaxAuthority = table.Column<string>(type: "Varchar(60)", maxLength: 60, nullable: true),
                    ReceiptTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptSupplier = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    ReceiptReceiver = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptID);
                });

            migrationBuilder.CreateTable(
                name: "SalesMovements",
                columns: table => new
                {
                    SalesMovementsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesMovementsDate = table.Column<int>(type: "int", nullable: false),
                    SalesMovementsUnit = table.Column<int>(type: "int", nullable: false),
                    SalesMovementsPrice = table.Column<int>(type: "int", nullable: false),
                    SalesMovementsTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMovements", x => x.SalesMovementsID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptDetails",
                columns: table => new
                {
                    ReceiptDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptDetailsDescription = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    ReceiptDetailsAmount = table.Column<int>(type: "int", nullable: false),
                    ReceiptDetailsUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptDetailsTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDetails", x => x.ReceiptDetailsId);
                    table.ForeignKey(
                        name: "FK_ReceiptDetails_Receipts_ReceiptID",
                        column: x => x.ReceiptID,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Currents",
                columns: table => new
                {
                    CurrentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    CurrentSurname = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    CurrentCity = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    CurrentMail = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    SalesMovementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currents", x => x.CurrentID);
                    table.ForeignKey(
                        name: "FK_Currents_SalesMovements_SalesMovementID",
                        column: x => x.SalesMovementID,
                        principalTable: "SalesMovements",
                        principalColumn: "SalesMovementsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    ProductMark = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    ProductStock = table.Column<short>(type: "smallint", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductStatus = table.Column<bool>(type: "bit", nullable: false),
                    ProductImage = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    SalesMovementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SalesMovements_SalesMovementID",
                        column: x => x.SalesMovementID,
                        principalTable: "SalesMovements",
                        principalColumn: "SalesMovementsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    StaffSurname = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    StaffImage = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: true),
                    SalesMovementID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staffs_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffs_SalesMovements_SalesMovementID",
                        column: x => x.SalesMovementID,
                        principalTable: "SalesMovements",
                        principalColumn: "SalesMovementsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currents_SalesMovementID",
                table: "Currents",
                column: "SalesMovementID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SalesMovementID",
                table: "Products",
                column: "SalesMovementID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetails_ReceiptID",
                table: "ReceiptDetails",
                column: "ReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentID",
                table: "Staffs",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SalesMovementID",
                table: "Staffs",
                column: "SalesMovementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Currents");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ReceiptDetails");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "SalesMovements");
        }
    }
}
