using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class add_mig_staff_and_current_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffMail",
                table: "Staffs",
                type: "Varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptDetailsAmount",
                table: "ReceiptDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<string>(
                name: "CurrentImage",
                table: "Currents",
                type: "Varchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffMail",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "CurrentImage",
                table: "Currents");

            migrationBuilder.AlterColumn<short>(
                name: "ReceiptDetailsAmount",
                table: "ReceiptDetails",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
