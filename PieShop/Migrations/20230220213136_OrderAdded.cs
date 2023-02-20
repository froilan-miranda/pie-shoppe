﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PieShop.Migrations
{
    /// <inheritdoc />
    public partial class OrderAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    OrderTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Pies_PieId",
                        column: x => x.PieId,
                        principalTable: "Pies",
                        principalColumn: "PieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_PieId",
                table: "OrderDetail",
                column: "PieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
