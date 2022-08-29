using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorTbl",
                columns: table => new
                {
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTbl", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookTbl",
                columns: table => new
                {
                    BookId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTbl", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_BookTbl_AuthorTbl_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorTbl",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTbl",
                columns: table => new
                {
                    PaymentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTbl", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymentTbl_BookTbl_BookId",
                        column: x => x.BookId,
                        principalTable: "BookTbl",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTbl_AuthorId",
                table: "BookTbl",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTbl_BookId",
                table: "PaymentTbl",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTbl");

            migrationBuilder.DropTable(
                name: "BookTbl");

            migrationBuilder.DropTable(
                name: "AuthorTbl");
        }
    }
}
