using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Webbanraucu_Ass.Migrations
{
    public partial class N4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Paid",
                table: "Orders",
                newName: "TotoMoney");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotoMoney",
                table: "Orders",
                newName: "Paid");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
