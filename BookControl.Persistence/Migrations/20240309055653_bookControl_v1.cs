using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookControl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bookControl_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BookControl");

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "BookControl",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "BookControl",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "BookControl",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "BookControl",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "BookControl",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BooksId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrdersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Book_BooksId",
                        column: x => x.BooksId,
                        principalSchema: "BookControl",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "BookControl",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BooksId",
                schema: "BookControl",
                table: "OrderDetail",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrdersId",
                schema: "BookControl",
                table: "OrderDetail",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "BookControl",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "BookControl");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "BookControl");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "BookControl");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "BookControl");
        }
    }
}
